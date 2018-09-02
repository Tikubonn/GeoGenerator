
using System;
using System.Collections.Generic;

namespace GeoGenerator {
  
  public class MapNode {
    
    public Position Position;
    public MapData MapData;
		public List<MapNode> Connections = new List<MapNode>{};
    
    public MapNode (Position position, MapData mapData){
      Position = position;
      MapData = mapData;
			Connections = new List<MapNode>();
    }
		
		public bool Generate (List<MapData> mapDatas, GenericBuffer<bool> buffer, int depth){
			return Generate(mapDatas, buffer, depth, new Random());
		}
    
    public virtual bool Generate (List<MapData> mapDatas, GenericBuffer<bool> buffer, int depth, Random random){
      return GenerateSelf(mapDatas, buffer, depth, random) && 
        GenerateChildNodes(mapDatas, buffer, depth, random);
    }
		
    public virtual bool GenerateSelf (List<MapData> mapDatas, GenericBuffer<bool> buffer, int depth, Random random){
			
			try {
				
				for (int x = 0; x < MapData.Width; x++){
					for (int y = 0; y < MapData.Height; y++){
						if (0 < x && x < Math.Max(MapData.Width -1, 0) && 
								0 < y && y < Math.Max(MapData.Height -1, 0)){
							Position pos = new Position(x, y);
							bool dat1 = MapData.Get(pos);
							bool dat2 = buffer.Get(Position + pos);
							if (dat1 == true && dat2 == true){
								return false;
							}
						}
					}
				}

				for (int x = 0; x < MapData.Width; x++){
					for (int y = 0; y < MapData.Height; y++){
						Position pos = new Position(x, y);
						bool dat = MapData.Get(pos);
						if (dat == true){
							buffer.Set(Position + pos, true);
						}
					}
				}
				
				return true;
				
			}
			
			catch (GenericBufferPositionOutOfRangeException){ // out of ranged
				return false;
			}
    
		}
		
    public virtual bool GenerateChildNodes (List<MapData> mapDatas, GenericBuffer<bool> buffer, int depth, Random random){

      if (depth == 0){
				return MapData.MinConnections == 0;
			}
			
			GenericBuffer<bool> subBuffer = buffer.Copy();
			
			int connectionCount = 0;
      List<MapNode> connections = new List<MapNode>();
			List<Position> randomConnectors = Utility.Copy(MapData.Connectors);
			Utility.Shuffle(randomConnectors, random);
      foreach (Position connector in randomConnectors){
				
				if (MapData.MaxConnections < connectionCount){
					break;
				}
				
        List<MapData> randomMapDatas = Utility.Copy(mapDatas);
				Utility.Shuffle(randomMapDatas, random);
				foreach (MapData mapData in randomMapDatas){
        
					List<Position> randomConnectors2 = Utility.Copy(mapData.Connectors);
					Utility.Shuffle(randomConnectors2, random);
          foreach (Position connector2 in randomConnectors2){
            
						GenericBuffer<bool> subBuffer2 = subBuffer.Copy();
            MapNode mapNode = new MapNode(Position + connector - connector2, mapData);
            
            if (mapNode.Generate(mapDatas, subBuffer2, depth -1, random) == false){
							continue;
            }
            
						subBuffer2.CopyTo(subBuffer);
            connections.Add(mapNode);
						connectionCount++;
						goto NextConnector;
            
          }
					
        }
				
				NextConnector:;
				
      }
			
			if (connectionCount < MapData.MinConnections){
				return false;
			}

			subBuffer.CopyTo(buffer);
      Connections = connections;
      return true;
      
    }
		
		public void WriteTo (GenericBuffer<bool> buffer){
			WriteSelfTo(buffer);
			WriteChildNodesTo(buffer);
		}

		public void WriteSelfTo (GenericBuffer<bool> buffer){
			for (int x = 0; x < MapData.Width; x++){
				for (int y = 0; y < MapData.Height; y++){
					Position pos = new Position(x, y);
					bool dat = MapData.Get(pos);
					if (dat == true){
						buffer.Set(Position + pos, true);
					}
				}
			}
		}
		
		public void WriteChildNodesTo (GenericBuffer<bool> buffer){
			foreach (MapNode mapNode in Connections){
				mapNode.WriteTo(buffer);
			}
		}
		
  }
  
}

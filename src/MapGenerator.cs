
using System;
using System.Collections.Generic;

namespace GeoGenerator {
	
	public class MapGenerator {
		
		private Random random;
		private List<MapData> mapDatas;

		public virtual List<MapData> MapDatas {
			get { return mapDatas; }
		}
		
		public Random Random {
			get { return random; }
		}
		
		public MapGenerator (List<MapData> mapDatas){
			InitMapGenerator(mapDatas, new Random());
		}
		
		public MapGenerator (List<MapData> mapDatas, Random random){
			InitMapGenerator(mapDatas, random);
		}
		
		public void InitMapGenerator (List<MapData> mapDatas, Random random){
			this.random = random;
			this.mapDatas = mapDatas;
		}
		
		public MapData ChoiceRandomMapData (){
			return Utility.Choice(MapDatas, Random);
		}
		
		public MapNode Generate (int size){
			return Generate(size, size);
		}
		
		public MapNode Generate (int width, int height){
			return Generate(width, height, 5);
		}
		
		public MapNode Generate (int width, int height, int depth){
			int w2 = width / 2;
			int w4 = width / 4;
			int h2 = height / 2;
			int h4 = height / 4;
			Position pos = new Position(
				Random.Next(w4, w4 + w2),
				Random.Next(h4, h4 + h2));
			return Generate(width, height, depth, pos);
		}
		
		public virtual MapNode Generate (int width, int height, int depth, Position pos){
			GenericBuffer<bool> buffer = GenericBuffer<bool>.MakeGenericBufferBySize(width, height);
			MapData mapData = ChoiceRandomMapData();
			MapNode mapNode = new MapNode(pos, mapData);
			if (mapNode.Generate(MapDatas, buffer, depth, Random) == false){
				return null;
			}
			return mapNode;
		}
		
	}
	
}

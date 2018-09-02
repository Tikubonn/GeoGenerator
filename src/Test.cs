
using System;
using System.Collections.Generic;

namespace GeoGenerator {

	public class Example1 : MapData {

		public override GenericBuffer<bool> Data {
			get {
				return new GenericBuffer<bool>(
					new bool[,]{
						{true, true, true, true, true},
						{true, true, true, true, true},
						{true, true, true, true, true},
						{true, true, true, true, true},
						{true, true, true, true, true},
					});
			}
		}
		
		public override List<Position> Connectors {
			get {
				return new List<Position>{
					new Position(2, 0),
					new Position(2, 4),
					new Position(0, 2),
					new Position(4, 2),
				};
			}
		}
		
	}
  
	public class Example2 : MapData {
		
		public override GenericBuffer<bool> Data {
			get {
				return new GenericBuffer<bool>(
					new bool[,]{
						{true, true, true, true, true},
						{true, true, true, true, true},
						{true, true, true, true, true},
					});
			}
		}

		public override List<Position> Connectors {
			get {
				return new List<Position>{
					new Position(0, 1),
					new Position(4, 1),
				};
			}
		}
		
	}
  
	public class Example3 : MapData {
		
		public override GenericBuffer<bool> Data { 
			get {
				return new GenericBuffer<bool>(
					new bool[,]{
						{false, false, true, true, true, false, false},
						{false, false, true, true, true, false, false},
						{false, false, true, true, true, false, false},
						{true, true, true, true, true, true, true},
						{true, true, true, true, true, true, true},
						{true, true, true, true, true, true, true},
					});
			}
		}
		
		public override List<Position> Connectors {
			get {
				return new List<Position>{
					new Position(3, 0),
					new Position(0, 4),
					new Position(6, 4),
				};
			}
		}
		
	}
	
  public static class TestCS {
    
		public static void Test (){
			
			Console.Write("width: ");
			int width = 0;
			try {
				width = Convert.ToInt32(Console.ReadLine());
			}
			catch (FormatException){
				width = 64;
				Console.Error.WriteLine("width = " + width + "(default)");
			}
			
			Console.Write("height: ");
			int height = 0;
			try {
				height = Convert.ToInt32(Console.ReadLine());
			}
			catch (FormatException){
				height = 64;
				Console.Error.WriteLine("height = " + height + "(default)");
			}
			
			Console.Write("depth: ");
			int depth = 0;
			try {
				depth = Convert.ToInt32(Console.ReadLine());
			}
			catch (FormatException){
				depth = 16;
				Console.Error.WriteLine("depth = " + depth + "(default)");
			}
			
			Test(width, height, depth);
			
		}
		
    public static void Test (int width, int height, int depth){
			
			List<MapData> mapDatas = new List<MapData>{
				new Example1(),
				new Example2(),
				new Example3(),
			};
			
			/* Random random = new Random();
			GenericBuffer<bool> buffer = GenericBuffer<bool>.MakeGenericBufferBySize(width, height);
			MapData mapData = Utility.Choice(mapDatas);
			MapNode mapNode = new MapNode(buffer.Center, mapData);
			
			if (mapNode.Generate(mapDatas, buffer, depth, random) == false){
				throw new Exception("mapNode.Generate() was failed!");
			}
			
			Debug.DumpBuffer(buffer); */
			
			MapGenerator mapGenerator = new MapGenerator(mapDatas);
			MapNode mapNode = mapGenerator.Generate(width, height, depth);
			
			if (mapNode == null){
				throw new Exception("mapNode.Generate() was failed!");
			}
			
			GenericBuffer<bool> buffer = GenericBuffer<bool>.MakeGenericBufferBySize(width, height);
			mapNode.WriteTo(buffer);
			Debug.DumpBuffer(buffer);
			
    }
		
		public static void Main (){
			
			Test();

		}
    
  }
	
}

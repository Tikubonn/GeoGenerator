
using System;

namespace GeoGenerator {
  
  public class GenericBuffer<Any> {

    private Any[,] data = new Any[,]{};
    
    public int Width {
      get {
        return data.GetLength(1);
      }
    }
    
    public int Height {
      get {
        return data.GetLength(0);
      }
    }
		
		public Position Center {
			get {
				return new Position(Width / 2, Height / 2);
			}
		}
    
    public GenericBuffer (Any[,] dat){
      data = dat;
    }
		
    public static GenericBuffer<Any> MakeGenericBuffer(Any[,] dat){
      return new GenericBuffer<Any>(dat);
    }
    
    public static GenericBuffer<Any> MakeGenericBufferBySize (int width, int height){
      Any[,] dat = Array.CreateInstance(typeof(Any), height, width) as Any[,];
      return new GenericBuffer<Any>(dat);
    }
    
    public Any Get (Position position){
			try {
				return data[position.Y, position.X];
			}
			catch (IndexOutOfRangeException){
				throw new GenericBufferPositionOutOfRangeException(
					"Position (" + position.X + ", " + position.Y + ") was out of ranged!");
			}
    }
    
    public void Set (Position position, Any any){
			try {
				data[position.Y, position.X] = any;
			}
			catch (IndexOutOfRangeException){
				throw new GenericBufferPositionOutOfRangeException(
					"Position (" + position.X + ", " + position.Y + ") was out of ranged!");
			}
    }
    
    public void CopyTo (GenericBuffer<Any> buffer){
      Any[,] dat = data.Clone() as Any[,];
      buffer.data = dat;
    }
    
    public GenericBuffer<Any> Copy (){
      Any[,] dat = data.Clone() as Any[,];
      return new GenericBuffer<Any>(dat);
    }
    
  }
  
}


using System;
using System.Collections.Generic;

namespace GeoGenerator {

  public class MapData {

		public virtual GenericBuffer<bool> Data {
			get { return new GenericBuffer<bool>(new bool[,]{}); }
		}
		
		public virtual List<Position> Connectors { 
			get { return new List<Position>{}; }
		}
		
		public virtual int MinConnections {
			get { return 0; } 
		}
		
		public virtual int MaxConnections {
			get { return /* int.MaxValue */ 4096; }
		}
			
    public int Width {
      get { return Data.Width; }
    }
    
    public int Height {
      get { return Data.Height; }
    }

    public bool Get (Position position){
      return Data.Get(position);
    }
    
    public void Set (Position position, bool dat){
      Data.Set(position, dat);
    }
    
  }
  
}

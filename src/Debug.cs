
using System;
using System.Collections.Generic;

namespace GeoGenerator {
	
	public static class Debug {
		
		public static void DumpBuffer (GenericBuffer<bool> buffer){
			
			for (int y = 0; y < buffer.Height; y++){
				
				for (int x = 0; x < buffer.Width; x++){

					Position pos = new Position(x, y);
					bool dat = buffer.Get(pos);
					Console.Write(dat ? " " : "/");
				
				}

				Console.WriteLine("");
				
			}
			
		}
		
	}
	
}

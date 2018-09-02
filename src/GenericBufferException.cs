
using System;

namespace GeoGenerator {

	public class GenericBufferException : Exception {
		
		public GenericBufferException (){
		}
		
		public GenericBufferException (string message) : base(message){
		}
		
	}
	
	public class GenericBufferPositionOutOfRangeException : GenericBufferException {

		public GenericBufferPositionOutOfRangeException (){
		}
		
		public GenericBufferPositionOutOfRangeException (string message) : base(message){
		}

	}
	
}

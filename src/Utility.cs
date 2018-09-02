
using System;
using System.Collections.Generic;

namespace GeoGenerator {
  
  public class RandomComparer<Any> : IComparer<Any> {
    
    private Random random = null;
    
    public RandomComparer (){
      random = new Random();
    }
    
    public RandomComparer (Random random){
      this.random = random;
    }
    
    public int Compare (Any any1, Any any2){
      return random.Next(-1, 1);
    }
    
  }
  
  public static class Utility {
    
    public static void Shuffle<Any> (List<Any> sequence){
      sequence.Sort(new RandomComparer<Any>());
    }
    
    public static void Shuffle<Any> (List<Any> sequence, Random random){
      sequence.Sort(new RandomComparer<Any>(random));
    }
    
    public static List<Any> Copy<Any> (List<Any> sequence){
      return new List<Any>(sequence);
    }

		public static Any Choice<Any> (List<Any> sequence){
			return Choice(sequence, new Random());
		}

		public static Any Choice<Any> (List<Any> sequence, Random random){
			if (sequence.Count == 0){
				throw new Exception("sequence has no element.");
			}
			int index = random.Next(0, Math.Max(0, sequence.Count -1));
			return sequence[index];
		}
    
  }
  
}

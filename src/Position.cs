
using System;

namespace GeoGenerator {
  
  public class Position {
    
    private int x;
    private int y;
    
    public int X {
      get {
        return this.x;
      }
    }
    
    public int Y {
      get {
        return this.y;
      }
    }
    
    public Position (int x, int y){
      this.x = x;
      this.y = y;
    }
    
    public static Position operator+ (Position position1, Position position2){
      return new Position(
        position1.x + position2.x,
        position1.y + position2.y
      );
    }
    
    public static Position operator- (Position position1, Position position2){
      return new Position(
        position1.x - position2.x,
        position1.y - position2.y
      );
    }
    
    public static Position operator- (Position position){
      return new Position(
        -position.x,
        -position.y
      );
    }
    
  }
  
}

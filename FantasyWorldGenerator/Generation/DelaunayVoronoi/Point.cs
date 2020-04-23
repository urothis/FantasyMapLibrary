using System.Collections.Generic;

namespace Generation.DelaunayVoronoi {
  public class Point {
    public Point(double x, double y) {
      X = x;
      Y = y;
    }

    public double X { get; }
    public double Y { get; }
    public HashSet<Triangle> AdjacentTriangles { get; } = new HashSet<Triangle>();
  }
}
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using static System.Drawing.Pens;
using Point = System.Drawing.Point;
using Generation.DelaunayVoronoi;

namespace ConsolePlayground {
  class Program {
    static void newBitmap() {
      var bmp = new Bitmap(512, 512);
      var g = Graphics.FromImage(bmp);
      g.FillRectangle(Brushes.Transparent, 75, 75, 512, 512);
      g.Dispose();
      bmp.Save("map.png", ImageFormat.Png);
      bmp.Dispose();
    }

    static void Main(string[] args) {
      var delaunay = new DelaunayTriangulator();
      var points = delaunay.GeneratePoints(2500, 512, 512);
      var triangulation = delaunay.BowyerWatson(points);
      newBitmap();
      var image = new Bitmap(Image.FromFile("map.png"));
      using (var g = Graphics.FromImage(image)) {
        foreach (var var in triangulation) {
          g.DrawLines(White, var.Vertices.Select(var2 => new Point((int) var2.X, (int) var2.Y)).ToArray());
        }

        image.Save("map.png");
        image.Dispose();
        Console.WriteLine("world generated!");
      }
    }
  }
}
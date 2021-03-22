using System;

namespace ClassDistance
{
    class Program
    {
        public class Point
        {
            public double x, y;

            private double MaxX = 30.0;
            private double MaxY = 30.0;

            /// <summary>
            /// This constructor places the new point randomly within the allowed coordinates.
            /// </summary>
            public Point()
            {
                Random rand = new Random();
                x = rand.NextDouble() * (rand.NextDouble() > 0.5 ? MaxX : -MaxX);
                y = rand.NextDouble() * (rand.NextDouble() > 0.5 ? MaxY : -MaxY);
            }

            /// <summary>
            /// Constructor which allows for manual placement of the created point.
            /// </summary>
            /// <param name="x">X coordinate of the created point.</param>
            /// <param name="y">Y coordinate of the created point.</param>
            public Point(double x, double y)
            {
                if (Math.Abs(x) > MaxX || Math.Abs(y) > MaxY)
                    throw new Exception("Cannot instantiate Point instance with values outside of acceptable range.");

                this.x = x;
                this.y = y;
            }

            public double DistanceTo(Point point) => Math.Sqrt(Math.Pow(x - point.x, 2) + Math.Pow(y - point.y, 2));
        }

        public static double DistanceBetween(Point point1, Point point2) => Math.Sqrt(Math.Pow(point1.x - point2.x, 2) + Math.Pow(point1.y - point2.y, 2));

        static void Main(string[] args)
        {
            // Create some Point instances demonstrating the overloaded constructor.
            Point point1 = new Point(5, 6);
            Point point2 = new Point(-7, 11);
            Point point3 = new Point();

            // Print a control distance calculation to show that it is correct.
            Console.WriteLine($"{DistanceBetween(point1, point2)} and {point1.DistanceTo(point2)}, should equal 13");
            Console.WriteLine($"Distance from point2 to randomly placed point: {point2.DistanceTo(point3)}");
        }
    }
}

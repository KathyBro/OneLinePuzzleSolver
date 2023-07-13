using System;
namespace OneLinePuzzleSolver
{
	public class Route
	{
		public string Name;
		public Point Destination;

		public Route(string name, Point destination)
		{
			Name = name;
			Destination = destination;
		}
	}
}


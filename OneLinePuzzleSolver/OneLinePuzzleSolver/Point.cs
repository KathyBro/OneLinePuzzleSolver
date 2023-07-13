using System;
namespace OneLinePuzzleSolver
{
	public class Point
	{
		public string Name;
		public List<Route> Routes = new List<Route>();

		public Point(string name)
		{
			Name = name;
		}
	}
}


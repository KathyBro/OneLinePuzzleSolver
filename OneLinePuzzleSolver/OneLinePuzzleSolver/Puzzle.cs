using System;
namespace OneLinePuzzleSolver
{
	public class Puzzle
	{
		public List<Point> Points = new List<Point>();
		public int LineCount;

		public void StartSolving()
		{
			foreach (Point point in this.Points)
			{
				GoDownRoute(point, new List<Route>());
				Console.Write("");
			}
		}

		public List<Route> GoDownRoute(Point pointCurrentlyAt, List<Route> currentSolution)
		{
			//Get all the routes for the point we are currently at

			foreach (Route route in pointCurrentlyAt.Routes)
			{
				//If the route isn't in the current solution, go down that way
				bool doesntHaveRoute = IsValidRoute(currentSolution, route.Name);
				if (doesntHaveRoute)
				{
					currentSolution.Add(route);
					currentSolution = GoDownRoute(route.Destination, currentSolution);
				}
			}

			if (currentSolution.Count == LineCount)
			{
				Console.WriteLine("A Solution:");
				foreach(Route route in currentSolution)
				{
					Console.WriteLine(route.Name + " to " + route.Destination.Name);
				}
				Console.WriteLine("\n------------------------\n");
                if (currentSolution.Count > 0) currentSolution.RemoveAt(currentSolution.Count - 1);
            }
			else
			{
				//Remove the last route from solution
				if (currentSolution.Count > 0) currentSolution.RemoveAt(currentSolution.Count-1);
			}
			return currentSolution;
		}

		public bool IsValidRoute(List<Route> current, string routeName)
		{
			for (int i = 0; i < current.Count; i++)
			{
				if (current[i].Name == routeName)
				{
					return false;
				}
			}
			return true;
		}

		internal Puzzle HousePuzzle()
		{
            //House Puzzle
            Point A = new Point("A");
            Point B = new Point("B");
            Point C = new Point("C");
            Point D = new Point("D");
            Point E = new Point("E");

            Route a1 = new Route("1", B);
            Route a2 = new Route("2", C);
            A.Routes.Add(a1);
            A.Routes.Add(a2);

            Route b1 = new Route("1", A);
            Route b3 = new Route("3", C);
            Route b4 = new Route("4", D);
            B.Routes.Add(b1);
            B.Routes.Add(b3);
            B.Routes.Add(b4);

            Route c2 = new Route("2", A);
            Route c3 = new Route("3", B);
            Route c6 = new Route("6", E);
            C.Routes.Add(c2);
            C.Routes.Add(c3);
            C.Routes.Add(c6);

            Route d4 = new Route("4", B);
            Route d5 = new Route("5", E);
            D.Routes.Add(d4);
            D.Routes.Add(d5);

            Route e6 = new Route("6", C);
            Route e5 = new Route("5", D);
            E.Routes.Add(e6);
            E.Routes.Add(e5);

            Puzzle house = new Puzzle();
            house.Points.Add(A);
            house.Points.Add(B);
            house.Points.Add(C);
            house.Points.Add(D);
            house.Points.Add(E);
            house.LineCount = 6;

			return house;
        }

		internal Puzzle HeartPuzzle()
		{
            Point A = new Point("A");
            Point B = new Point("B");
            Point C = new Point("C");
            Point D = new Point("D");

			Route a1 = new Route("1", B);
			Route a3 = new Route("3", B);
			Route a5 = new Route("5", D);
			A.Routes.Add(a1);
			A.Routes.Add(a3);
			A.Routes.Add(a5);

			Route b1 = new Route("1", A);
			Route b3 = new Route("3", A);
			Route b2 = new Route("2", C);
			Route b4 = new Route("4", C);
			Route b6 = new Route("6", D);
			B.Routes.Add(b1);
			B.Routes.Add(b3);
			B.Routes.Add(b2);
			B.Routes.Add(b4);
			B.Routes.Add(b6);

			Route c2 = new Route("2", B);
			Route c4 = new Route("4", B);
			Route c7 = new Route("7", D);
			C.Routes.Add(c2);
			C.Routes.Add(c4);
			C.Routes.Add(c7);

			Route d5 = new Route("5", A);
			Route d6 = new Route("6", B);
			Route d7 = new Route("7", C);
			D.Routes.Add(d5);
			D.Routes.Add(d6);
			D.Routes.Add(d7);

			Puzzle heart = new Puzzle();
			heart.Points.Add(A);
			heart.Points.Add(B);
			heart.Points.Add(C);
			heart.Points.Add(D);
			heart.LineCount = 7;

			return heart;
        }
    }
}


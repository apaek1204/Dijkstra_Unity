

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

namespace ConsoleApplication1
{
	public class Tuple : IComparable<Tuple>
	{

		/// <summary>
		///  writtened originally by nicholas J Carroll and DOug A SChmieder  copywright 2016 PLEASE DONT STEAL
		/// </summary>
		//public int Item1;
		//public int Item2;
		public string value;

		public Tuple(string a)
		{
			//Item1 = a;
			//Item2 = b;
			value = a;
		}

		public static Tuple Create(string input)
		{

			//return new Tuple(first, second);
			return new Tuple(input);
		}

		public int CompareTo(Tuple other)
		{
			/*
            if (this.Item1 < other.Item1) return -1;
            else if (this.Item1 > other.Item1) return 1;
            else return 0;
            */
			if ((int)Char.GetNumericValue(this.value[0]) < (int)Char.GetNumericValue(other.value[0])) return -1;
			else if ((int)Char.GetNumericValue(this.value[0]) >(int)Char.GetNumericValue(other.value[0])) return 1;
			else return 0;
		}
	}

	public class Node : IComparable<Node>
	{
		public int cost;
		public string target;
		public string source;

		public Node(int x, string t, string s)
		{
			this.cost = x;
			this.target = t;
			this.source = s;
		}

		public int CompareTo(Node other)
		{
			if (this.cost < other.cost) return -1;
			else if (this.cost > other.cost) return 1;
			else return 0;
		}
	} // Node

	/*
    public class Node : IComparable<Node>
    {
        public int cost;
        public Tuple<int, int> target;
        public Tuple<int, int> source;

        public Node(int x, Tuple<int, int> t, Tuple<int, int> s)
        {
            this.cost = x;
            this.target = t;
            this.source = s;
        }

        public int CompareTo(Node other)
        {
            if (this.cost < other.cost) return -1;
            else if (this.cost > other.cost) return 1;
            else return 0;
        }
    } // Node
    */


	class Program
	{


		static bool debugging = false; // Print out various debugging information throughout 
		static bool output = true; // Print output to Console
		static bool fileOutput = true;
		static void Main()
		{
			//string[] map = { "010", "110", "000" };
			string[] map = { "31423", "35472", "32517", "44244", "72233" };
			//string[] map = { "01111", "00111", "00000", "11101", "11111" };

		//	int tmp = AStarAgain(5, 5, 0, 0, 3, 3, map);
			//Console.WriteLine(tmp);
			/*   
            for (int i = 0; i < 4; i++)
            {
                AStar(i.ToString());
                Dijkstra(i.ToString());
            }
            */
		}

		public static void AStarAgain(int row, int col, int s_row, int s_col, int d_row, int d_col, string[] input_grid)
		{
			int i, j, num_tiles, tile_num;
			int mrow, mcol;
			int text_line_num = 0; // Keep track which line the program is working with
			string[] split;
			List<string> outputLines = new List<string>();
			int rstart_row, rstart_col;
			int rend_row, rend_col;
			string tile_name;
			var tiles = new SortedDictionary<string, int>();

			mrow = row;
			mcol = col;

			// Read in the entire grid to tile_grid
			string[] tile_grid = input_grid;

			for (i = 0; i < mrow; i++)
			{
				//  split = text[text_line_num].Split(' ');
				text_line_num++;
				for (j = 0; j < mcol; j++)
				{
					//tile_grid[i, j] = split[j];
				}
			}

			// Determine the starting and ending tiles
			rstart_row = s_row;
			rstart_col = s_col;
			rend_row = d_row;
			rend_col = d_col;
			int costs = 0;
			Node v;

			// Create the frontier and marked for A*
			PriorityQueue<Node> frontier = new PriorityQueue<Node>();
			var marked = new SortedDictionary<string, string>();

			// Create and push the first Node
			string start = rend_row.ToString() + rend_col.ToString();
			v = new Node(0, start, start);
			//v = new Node(0, Tuple.Create(rend_row, rend_col), Tuple.Create(rend_row, rend_col));
			frontier.Enqueue(v);
			//Console.WriteLine(rstart_row + "" + rstart_col);
			//Console.ReadLine();
			// Create the destination Tuple
			string destination = start;

			// Implement A* ♥
			while (frontier.Count() != 0)
			{
				v = frontier.Dequeue();
				//Console.WriteLine(v.target.Item1 + " " + v.target.Item2);

				//Console.WriteLine("Source, Target: " + v.source + " " + v.target);
				/*
                if (String.Compare(v.source, "00"))
                {
                    Console.WriteLine("Source, Target: " + v.source + " " + v.target);
                    Console.ReadLine();
                }
                    //Console.ReadLine();
                */
				// If we have already visited this Node, continue
				/*
                foreach (KeyValuePair<Tuple, Tuple> kvp in marked)
                {
                    Console.WriteLine("Key: " + kvp.Key.Item1 + " " + kvp.Key.Item2);
                    Console.WriteLine("Value: " + kvp.Value.Item1 + " " + kvp.Key.Item2);
                }
                */
				/*
				foreach (KeyValuePair<Tuple, Tuple> kvp in marked)
				{
					bool breaking = false
						if (kvp.Key.Item1 == v.target.Item1 && kvp.Key.Item2 == v.target.Item2 && kvp.Value.Item1 == v.source.Item1 && kvp.Value.Item2 == v.source.Item2)
						{
							Console.WriteLine("Found the Key");
							Console.WriteLine("Key: " + v.target.Item1 + v.target.Item2);
							Console.WriteLine("Value: " + v.source.Item1 + v.target.Item2);
							//Console.ReadLine();
						}
						}
				*/

				//Console.ReadLine();


				if (marked.ContainsKey(v.target))
				{
					Console.WriteLine("Found the Key");
					//Console.WriteLine("Key: " + v.target[0] + v.target[1]);
					//Console.WriteLine("Value: " + v.source[0] + v.target[1]);
					//Console.ReadLine();
					continue;
				}

				//Console.WriteLine("Adding");
				//Console.WriteLine("Key: " + v.target.Item1 + v.target.Item2);
				//Console.WriteLine("Value: " + v.source.Item1 + v.source.Item2);
				//Console.WriteLine("Key: " + v.target[0] + v.target[1]);
				//Console.WriteLine("Value: " + v.source[0] + v.source[1]);
				marked[v.target] = v.source;

				costs = v.cost; // Set equal to the cost it took to get to this point

				// Break if we have reached the destination
				if ((int)Char.GetNumericValue(v.target[0]) == rstart_row && (int)Char.GetNumericValue(v.target[1]) == rstart_col)
				{
					//Console.WriteLine(v.target);
					//Console.ReadLine();
					break;
				}
				// Add in the Nodes that are next to our current Node
				//if ((v.target.Item1 + 1) < mrow)
				if (((int)Char.GetNumericValue(v.target[0]) + 1 < mrow))
				{

					char[] curr_row = tile_grid[((int)Char.GetNumericValue(v.target[0])) + 1].ToCharArray();

					string targeting = (((int)Char.GetNumericValue(v.target[0])) + 1).ToString() + v.target[1].ToString();
					Node m = new Node(v.cost + curr_row[((int)Char.GetNumericValue(v.target[1]))] + priority(v.target, destination), targeting
						, v.target);
					frontier.Enqueue(m);
					//Console.WriteLine("Added Target: " + (v.target.Item1 + 1) +  v.target.Item2);
					//Console.WriteLine("Added Source: " + v.target.Item1 +  v.target.Item2);
				}
				if ((((int)Char.GetNumericValue(v.target[0])) - 1) >= 0)
				{
					//Debug.Log("helpus");

					char[] curr_row = tile_grid[((int)Char.GetNumericValue(v.target[0])) - 1].ToCharArray();
					//Debug.Log("helpus");

					string targeting = (((int)Char.GetNumericValue(v.target[0])) - 1).ToString() + v.target[1].ToString();
					//Node m = new Node(v.cost + curr_row[v.target.Item2] + priority(v.target, destination), Tuple.Create(v.target.Item1 - 1, v.target.Item2)
					//    , Tuple.Create(v.target.Item1, v.target.Item2));
					Node m = new Node(v.cost + curr_row[((int)Char.GetNumericValue(v.target[1]))] + priority(v.target, destination), targeting
						, v.target);
					frontier.Enqueue(m);
					//Console.WriteLine("Added Target: " + (v.target.Item1 - 1) + v.target.Item2);
					//Console.WriteLine("Added Source: " + (v.target.Item1) + v.target.Item2);

				}
				if ((((int)Char.GetNumericValue(v.target[1])) + 1) < mcol)
				{
					char[] curr_row = tile_grid[((int)Char.GetNumericValue(v.target[0]))].ToCharArray();

					string targeting = (v.target[0]).ToString() + (((int)Char.GetNumericValue(v.target[1])) + 1).ToString();

					Node m = new Node(v.cost + curr_row[((int)Char.GetNumericValue(v.target[1])) + 1] + priority(v.target, destination), targeting
						, v.target);
					frontier.Enqueue(m);
					//Console.WriteLine("Added Target: " + v.target.Item1 + (v.target.Item2 + 1));
					//Console.WriteLine("Added Source: " + v.target.Item1 + v.target.Item2);
				}
				if ((((int)Char.GetNumericValue(v.target[1])) - 1) >= 0)
				{
					char[] curr_row = tile_grid[((int)Char.GetNumericValue(v.target[0]))].ToCharArray();

					string targeting = (v.target[0]).ToString() + (((int)Char.GetNumericValue(v.target[1])) - 1).ToString();

					Node m = new Node(v.cost + curr_row[((int)Char.GetNumericValue(v.target[1])) - 1] + priority(v.target, destination), targeting
						, v.target);
					frontier.Enqueue(m);
					//Console.WriteLine("Added Target: " + v.target.Item1 + (v.target.Item2 - 1));
					//Console.WriteLine("Added Source: " + v.target.Item1 +  v.target.Item2);
				}
			}



			foreach(KeyValuePair<string, string> kvp in marked)
			{
				Console.WriteLine("Key: " + kvp.Key);
				Console.WriteLine("Value: " + kvp.Value);
			}


			Console.ReadLine();
			// Traverse through marked to calculate the proper cost
			/*
            string curr_cost = v.target;
            while ((int)Char.GetNumericValue(curr_cost[0]) != rend_row || (int)Char.GetNumericValue(curr_cost[1]) != rend_col)
            {
                curr_cost = marked[curr_cost];
                costs -= priority(curr_cost, destination);
                Console.WriteLine("-: " + priority(curr_cost, destination) + " Costs: " + costs);
            }
            */

			/*
			Tuple searching = Tuple.Create(0, 0);
			if (marked.ContainsKey(searching))
				//Console.WriteLine("Found the correct Key");
				*/
				/*
			if (marked.ContainsKey("00"))
				Console.WriteLine("Found the starting position");
			*/

			Console.WriteLine("Got to the End");
			//Console.WriteLine(v.target);
			// If output, print out to the console


		//	Queue results= new Queue();
			if (output)
			{
				//Console.WriteLine("Cost: " + costs);
				string curr = v.target;
				//Console.WriteLine(rend_row + " " + rend_col);
				//Console.ReadLine();



				while ((int)Char.GetNumericValue(curr[0]) != rend_row || (int)Char.GetNumericValue(curr[1]) != rend_col)
				{
					Console.WriteLine(curr);
					//Console.ReadLine();

					//results.enqueue (curr);


					curr = marked[curr];




				}
				Console.WriteLine(curr);
				Console.WriteLine("End");
				Console.ReadLine();
			}
			//return results;

			//return 0;
			/*
			//Tuple curr = marked [v.target];
			if (curr.Item1 > v.target.Item1)
				return 1;
			else if (curr.Item1 < v.target.Item1)
				return 3;
			else if (curr.Item2 > v.target.Item2)
				return 0;
			else
				return 2;
			*/
		}


		/*
        static void AStar(string numTest)
        {
            int i, j, num_tiles, tile_num;
            int mrow, mcol;
            int text_line_num = 0; // Keep track which line the program is working with
            string[] split;
            List<string> outputLines = new List<string>();
            string path = (@"..\..\Paths\Test_AStar_Output" + numTest + ".txt");
            int rstart_row, rstart_col;
            int rend_row, rend_col;
            StreamWriter sw;
            string tile_name;
            var tiles = new Dictionary<string, int>();

            if (debugging)
                Console.WriteLine(Application.ExecutablePath);

            // Get the Path of the Input0.txt
            string[] text = System.IO.File.ReadAllLines(@"..\..\Paths\Input" + numTest + ".txt");
            num_tiles = int.Parse(text[text_line_num]);
            text_line_num++;
            
            if (fileOutput && !File.Exists(path))
                sw = File.CreateText(path);
            else 
                sw = new StreamWriter(path);

            sw.AutoFlush = true;

            // Increment through to get which types of tiles there are
            for (i = 0; i < num_tiles; i++)
            {
                split = text[text_line_num].Split(' ');
                text_line_num++;
                tile_name = split[0];
                tile_num = int.Parse(split[1]);
                tiles[tile_name] = tile_num;
            }

            if (debugging)
            {
                foreach (KeyValuePair<string, int> kvp in tiles)
                {
                    Console.Out.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
                }
            }
            if (fileOutput && debugging)
            {
                foreach (KeyValuePair<string, int> kvp in tiles)
                {
                    sw.WriteLine("Key = " + kvp.Key + ", Value = " + kvp.Value);
                }
            }
            // Split to figure out how many rows and columns there are
            split = text[text_line_num].Split(' ');
            text_line_num++;
            mrow = int.Parse(split[0]);
            mcol = int.Parse(split[1]);

            // Read in the entire grid to tile_grid
            string[,] tile_grid = new string[mrow, mcol];
            for (i = 0; i < mrow; i++)
            {
                split = text[text_line_num].Split(' ');
                text_line_num++;
                for (j = 0; j < mcol; j++)
                {
                    tile_grid[i, j] = split[j];
                }
            }

            // Determine the starting and ending tiles
            split = text[text_line_num].Split(' ');
            text_line_num++;
            rstart_row = int.Parse(split[0]);
            rstart_col = int.Parse(split[1]);
            split = text[text_line_num].Split(' ');
            text_line_num++;
            rend_row = int.Parse(split[0]);
            rend_col = int.Parse(split[1]);
            int costs = 0;
            Node v;

            // Create the frontier and marked for A*
            PriorityQueue<Node> frontier = new PriorityQueue<Node>();
            var marked = new Dictionary<Tuple<int, int>, Tuple<int, int>>();

            // Create and push the first Node
            v = new Node(0, Tuple.Create(rend_row, rend_col), Tuple.Create(rend_row, rend_col));
            frontier.Enqueue(v);
            if (debugging)
            {
                Console.Out.WriteLine("Target: " + v.target.Item1 + " " + v.target.Item2);
                Console.Out.WriteLine("Source: " + v.source.Item1 + " " + v.target.Item2);
            }
            if (fileOutput && debugging)
            {
                sw.WriteLine("Target: " + v.target.Item1 + " " + v.target.Item2);
                sw.WriteLine("Source: " + v.source.Item1 + " " + v.target.Item2);
            }
            // Create the destination Tuple
            Tuple<int, int> destination = Tuple.Create(rend_row, rend_col);
            // Implement A* ♥
            while (frontier.Count() != 0)
            {
                v = frontier.Dequeue();
                if (debugging)
                {
                    Console.Out.WriteLine("Cost: " + v.cost);
                    Console.Out.WriteLine("Target: " + v.target.Item1 + " " + v.target.Item2);
                    Console.Out.WriteLine("Source: " + v.source.Item1 + " " + v.target.Item2);
                }
                if (fileOutput && debugging)
                {
                    sw.WriteLine("Cost: " + v.cost);
                    sw.WriteLine("Target: " + v.target.Item1 + " " + v.target.Item2);
                    sw.WriteLine("Source: " + v.source.Item1 + " " + v.target.Item2);
                }

                // If we have already visited this Node, continue
                if (marked.ContainsKey(v.target))
                    continue;
                marked[v.target] = v.source;
                costs = v.cost; // Set equal to the cost it took to get to this point

                // Break if we have reached the destination
                if (v.target.Item1 == rstart_row && v.target.Item2 == rstart_col)
                    break;

                // Add in the Nodes that are next to our current Node
                if ((v.target.Item1 + 1) < mrow)
                {
                    Node m = new Node(v.cost + tiles[tile_grid[v.target.Item1 + 1, v.target.Item2]] + priority(v.target, destination), Tuple.Create(v.target.Item1 + 1, v.target.Item2)
                        , Tuple.Create(v.target.Item1, v.target.Item2));
                    frontier.Enqueue(m);
                }
                if ((v.target.Item1 - 1) >= 0)
                {
                    Node m = new Node(v.cost + tiles[tile_grid[v.target.Item1 - 1, v.target.Item2]] + priority(v.target, destination), Tuple.Create(v.target.Item1 - 1, v.target.Item2)
                        , Tuple.Create(v.target.Item1, v.target.Item2));
                    frontier.Enqueue(m);
                }
                if ((v.target.Item2 + 1) < mcol)
                {
                    Node m = new Node(v.cost + tiles[tile_grid[v.target.Item1, v.target.Item2 + 1]] + priority(v.target, destination), Tuple.Create(v.target.Item1, v.target.Item2 + 1)
                        , Tuple.Create(v.target.Item1, v.target.Item2));
                    frontier.Enqueue(m);
                }
                if ((v.target.Item2 - 1) >= 0)
                {
                    Node m = new Node(v.cost + tiles[tile_grid[v.target.Item1, v.target.Item2 - 1]] + priority(v.target, destination), Tuple.Create(v.target.Item1, v.target.Item2 - 1)
                        , Tuple.Create(v.target.Item1, v.target.Item2));
                    frontier.Enqueue(m);
                }
            }

            // Traverse through marked to calculate the proper cost
            Tuple<int, int> curr_cost = v.target;
            while (curr_cost.Item1 != rend_row || curr_cost.Item2 != rend_col)
            {
                curr_cost = marked[curr_cost];
                costs -= priority(curr_cost, destination);
            }

            // If output, print out to the console
            if (output)
            {
                Console.WriteLine(costs);
                Tuple<int, int> curr = v.target;
                while (curr.Item1 != rend_row || curr.Item2 != rend_col)
                {
                    Console.WriteLine("{0} {1}", curr.Item1, curr.Item2);
                    curr = marked[curr];
                }
                Console.WriteLine("{0} {1}", curr.Item1, curr.Item2);
                Console.WriteLine("End");
                Console.ReadLine();
            }
            if (fileOutput)
            {
                sw.WriteLine(costs.ToString());
                Tuple<int, int> curr = v.target;
                int num = 0;
                while (curr.Item1 != rend_row || curr.Item2 != rend_col)
                {
                    sw.WriteLine(num + " " + curr.Item1 + " " + curr.Item2);
                    curr = marked[curr];
                    num++;
                }
                sw.WriteLine(curr.Item1 + " " + curr.Item2);
                sw.WriteLine("End");
            }
        }


        // Dijkstra
        static void Dijkstra(string numTest)
        {
            int i, j, num_tiles, tile_num;
            int mrow, mcol;
            int text_line_num = 0; // Keep track which line the program is working with
            string[] split;
            List<string> outputLines = new List<string>();
            string path = (@"..\..\Paths\Test_Dijkstra_Output" + numTest + ".txt");
            int rstart_row, rstart_col;
            int rend_row, rend_col;
            StreamWriter sw;
            string tile_name;
            var tiles = new Dictionary<string, int>();

            if (debugging)
                Console.WriteLine(Application.ExecutablePath);

            // Get the Path of the Input0.txt
            string[] text = System.IO.File.ReadAllLines(@"..\..\Paths\Input" + numTest + ".txt");
            num_tiles = int.Parse(text[text_line_num]);
            text_line_num++;

            if (fileOutput && !File.Exists(path))
                sw = File.CreateText(path);
            else
                sw = new StreamWriter(path);

            sw.AutoFlush = true;

            // Increment through to get which types of tiles there are
            for (i = 0; i < num_tiles; i++)
            {
                split = text[text_line_num].Split(' ');
                text_line_num++;
                tile_name = split[0];
                tile_num = int.Parse(split[1]);
                tiles[tile_name] = tile_num;
            }

            if (debugging)
            {
                foreach (KeyValuePair<string, int> kvp in tiles)
                {
                    Console.Out.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
                }
            }
            if (fileOutput && debugging)
            {
                foreach (KeyValuePair<string, int> kvp in tiles)
                {
                    sw.WriteLine("Key = " + kvp.Key + ", Value = " + kvp.Value);
                }
            }
            // Split to figure out how many rows and columns there are
            split = text[text_line_num].Split(' ');
            text_line_num++;
            mrow = int.Parse(split[0]);
            mcol = int.Parse(split[1]);

            // Read in the entire grid to tile_grid
            string[,] tile_grid = new string[mrow, mcol];
            for (i = 0; i < mrow; i++)
            {
                split = text[text_line_num].Split(' ');
                text_line_num++;
                for (j = 0; j < mcol; j++)
                {
                    tile_grid[i, j] = split[j];
                }
            }

            // Determine the starting and ending tiles
            split = text[text_line_num].Split(' ');
            text_line_num++;
            rstart_row = int.Parse(split[0]);
            rstart_col = int.Parse(split[1]);
            split = text[text_line_num].Split(' ');
            text_line_num++;
            rend_row = int.Parse(split[0]);
            rend_col = int.Parse(split[1]);
            int costs = 0;
            Node v;

            // Create the frontier and marked for Dijkstra
            PriorityQueue<Node> frontier = new PriorityQueue<Node>();
            var marked = new Dictionary<Tuple<int, int>, Tuple<int, int>>();

            // Create and push the first Node
            v = new Node(0, Tuple.Create(rend_row, rend_col), Tuple.Create(rend_row, rend_col));
            frontier.Enqueue(v);
            if (debugging)
            {
                Console.Out.WriteLine("Target: " + v.target.Item1 + " " + v.target.Item2);
                Console.Out.WriteLine("Source: " + v.source.Item1 + " " + v.target.Item2);
            }
            if (fileOutput && debugging)
            {
                sw.WriteLine("Target: " + v.target.Item1 + " " + v.target.Item2);
                sw.WriteLine("Source: " + v.source.Item1 + " " + v.target.Item2);
            }
            // Create the destination Tuple
            Tuple<int, int> destination = Tuple.Create(rend_row, rend_col);
            // Implement Dijkstra ♥
            while (frontier.Count() != 0)
            {
                v = frontier.Dequeue();
                if (debugging)
                {
                    Console.Out.WriteLine("Cost: " + v.cost);
                    Console.Out.WriteLine("Target: " + v.target.Item1 + " " + v.target.Item2);
                    Console.Out.WriteLine("Source: " + v.source.Item1 + " " + v.target.Item2);
                }
                if (fileOutput && debugging)
                {
                    sw.WriteLine("Cost: " + v.cost);
                    sw.WriteLine("Target: " + v.target.Item1 + " " + v.target.Item2);
                    sw.WriteLine("Source: " + v.source.Item1 + " " + v.target.Item2);
                }

                // If we have already visited this Node, continue
                if (marked.ContainsKey(v.target))
                    continue;
                marked[v.target] = v.source;
                costs = v.cost; // Set equal to the cost it took to get to this point

                // Break if we have reached the destination
                if (v.target.Item1 == rstart_row && v.target.Item2 == rstart_col)
                    break;

                // Add in the Nodes that are next to our current Node
                if ((v.target.Item1 + 1) < mrow)
                {
                    Node m = new Node(v.cost + tiles[tile_grid[v.target.Item1 + 1, v.target.Item2]], Tuple.Create(v.target.Item1 + 1, v.target.Item2)
                        , Tuple.Create(v.target.Item1, v.target.Item2));
                    frontier.Enqueue(m);
                }
                if ((v.target.Item1 - 1) >= 0)
                {
                    Node m = new Node(v.cost + tiles[tile_grid[v.target.Item1 - 1, v.target.Item2]], Tuple.Create(v.target.Item1 - 1, v.target.Item2)
                        , Tuple.Create(v.target.Item1, v.target.Item2));
                    frontier.Enqueue(m);
                }
                if ((v.target.Item2 + 1) < mcol)
                {
                    Node m = new Node(v.cost + tiles[tile_grid[v.target.Item1, v.target.Item2 + 1]], Tuple.Create(v.target.Item1, v.target.Item2 + 1)
                        , Tuple.Create(v.target.Item1, v.target.Item2));
                    frontier.Enqueue(m);
                }
                if ((v.target.Item2 - 1) >= 0)
                {
                    Node m = new Node(v.cost + tiles[tile_grid[v.target.Item1, v.target.Item2 - 1]], Tuple.Create(v.target.Item1, v.target.Item2 - 1)
                        , Tuple.Create(v.target.Item1, v.target.Item2));
                    frontier.Enqueue(m);
                }
            }

            // If output, print out to the console
            if (output)
            {
                Console.WriteLine(costs);
                Tuple<int, int> curr = v.target;
                while (curr.Item1 != rend_row || curr.Item2 != rend_col)
                {
                    Console.WriteLine("{0} {1}", curr.Item1, curr.Item2);
                    curr = marked[curr];
                }
                Console.WriteLine("{0} {1}", curr.Item1, curr.Item2);
                Console.WriteLine("End");
                Console.ReadLine();
            }
            if (fileOutput)
            {
                sw.WriteLine(costs.ToString());
                Tuple<int, int> curr = v.target;
                while (curr.Item1 != rend_row || curr.Item2 != rend_col)
                {
                    sw.WriteLine(curr.Item1 + " " + curr.Item2);
                    curr = marked[curr];
                }
                sw.WriteLine(curr.Item1 + " " + curr.Item2);
                sw.WriteLine("End");
            }
        }
        */

		// Heuristic Function to A* ♥
		static int priority(string current, string destination)
		{
			int xdist, ydist;

			xdist = Math.Abs((int)Char.GetNumericValue(current[0]) - (int)Char.GetNumericValue(destination[1]));
			ydist = Math.Abs((int)Char.GetNumericValue(current[0]) - (int)Char.GetNumericValue(destination[1]));
			return (xdist + ydist);
		}

		/*
        // Heuristic Function to A* ♥
		static int priority(Tuple current, Tuple destination)
		{
			int xdist, ydist;

			xdist = Math.Abs((int)Char.GetNumericValue(current.value[0]) - (int)Char.GetNumericValue(destination.value[1]));
			ydist = Math.Abs((int)Char.GetNumericValue(current.value[0]) - (int)Char.GetNumericValue(destination.value[1]));
			return (xdist + ydist);
		}
		*/
	}

	// Priority Queue 
	// Downloaded from https://visualstudiomagazine.com/Articles/2012/11/01/Priority-Queues-with-C.aspx?Page=2
	public class PriorityQueue<T> where T : IComparable<T>
	{
		private List<T> data;

		public PriorityQueue()
		{
			this.data = new List<T>();
		}

		public void Enqueue(T item)
		{
			data.Add(item);
			int ci = data.Count - 1; // child index; start at end
			while (ci > 0)
			{
				int pi = (ci - 1) / 2; // parent index
				if (data[ci].CompareTo(data[pi]) >= 0) break; // child item is larger than (or equal) parent so we're done
				T tmp = data[ci]; data[ci] = data[pi]; data[pi] = tmp;
				ci = pi;
			}
		}

		public T Dequeue()
		{
			// assumes pq is not empty; up to calling code
			int li = data.Count - 1; // last index (before removal)
			T frontItem = data[0];   // fetch the front
			data[0] = data[li];
			data.RemoveAt(li);

			--li; // last index (after removal)
			int pi = 0; // parent index. start at front of pq
			while (true)
			{
				int ci = pi * 2 + 1; // left child index of parent
				if (ci > li) break;  // no children so done
				int rc = ci + 1;     // right child
				if (rc <= li && data[rc].CompareTo(data[ci]) < 0) // if there is a rc (ci + 1), and it is smaller than left child, use the rc instead
					ci = rc;
				if (data[pi].CompareTo(data[ci]) <= 0) break; // parent is smaller than (or equal to) smallest child so done
				T tmp = data[pi]; data[pi] = data[ci]; data[ci] = tmp; // swap parent and child
				pi = ci;
			}
			return frontItem;
		}

		public T Peek()
		{
			T frontItem = data[0];
			return frontItem;
		}

		public T Top()
		{
			return data[0];
		}

		public int Count()
		{
			return data.Count;
		}

		public override string ToString()
		{
			string s = "";
			for (int i = 0; i < data.Count; ++i)
				s += data[i].ToString() + " ";
			s += "count = " + data.Count;
			return s;
		}

		public bool IsConsistent()
		{
			// is the heap property true for all data?
			if (data.Count == 0) return true;
			int li = data.Count - 1; // last index
			for (int pi = 0; pi < data.Count; ++pi) // each parent index
			{
				int lci = 2 * pi + 1; // left child index
				int rci = 2 * pi + 2; // right child index

				if (lci <= li && data[pi].CompareTo(data[lci]) > 0) return false; // if lc exists and it's greater than parent then bad.
				if (rci <= li && data[pi].CompareTo(data[rci]) > 0) return false; // check the right child too.
			}
			return true; // passed all checks
		} // IsConsistent
	} // PriorityQueue
}
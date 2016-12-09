using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

public class movement : MonoBehaviour {




	public GameObject apple;


	public Vector3 applePosition;

	private string[] map;


	private int currentX;
	private int currentY;


	public Queue name;

	//public Pathfind CurrentPath;

	public float tileSize
	{
		get { return this.GetComponent<SpriteRenderer>().sprite.bounds.size.x; }
	}

	private float threshold;
	private float time;

	// Use this for initialization
	void Start () {

		currentX = 0;
		currentY = 0;
		map = GameObject.Find ("Manager").GetComponent<Manager> ().mapData;
		time = 0;
		threshold = 1.0f;
		applePosition = apple.transform.position;
		name = new Queue();


	///	Pathfind CurrentPath = new Pathfind ();

	
	}





	public void updateQueue(){
		name = new Queue ();

		map = GameObject.Find ("Manager").GetComponent<Manager> ().mapData;

		name = Program.AStarAgain(map.Length, map.Length, currentX, currentY, 1, 3, map);

	}

	void moveRight(){

		Vector3 moveX = new Vector3( tileSize ,0.0f , 0);
	}
	
	// Update is called once per frame
	void Update () {


		//name.Enqueue (1);
		
		//Pathfind hello;
		//hello = new Pathfind();

		map = GameObject.Find ("Manager").GetComponent<Manager> ().mapData;


		string result;
		if (time == 0) {

			//hello = new Pathfind();
	//		int result = // hello.AStarAgain (map.Length, map.Length, currentX, currentY, 2, 2, map);

			//Debug.Log ("result");


			//int result = 0;

			///Debug.Log (result);

			 


			name = Program.AStarAgain(map.Length, map.Length, currentX, currentY, 1, 3, map);
			/*

			//for (int i = 0; i < 5; i++) {	
			//	int tempRand = Random.Range (0, 3);
			//	name.Enqueue (tempRand);
			//}
			//*/
		}


		time += Time.deltaTime;
		Vector3 applePositon = apple.transform.position;


		//Vector3 moveX = new Vector3 ( 0.1f, 0.0f, 0.0f);
		//ector3 moveY = new Vector3 ( 0.0f, 0.1f, 0.0f);

		Vector3 moveX = new Vector3( tileSize ,0.0f , 0);
		Vector3 moveY = new Vector3( 0.0f ,tileSize , 0);


	


		//newPos= curr + direction * tileSize


			//Vector3( tileSize,0.0f, 0);



		if ((time > threshold)&& (name.Count>0)) {
			//Debug.Log (name.Count);

			time = 0.01f;
			//Debug.Log (currentX);
			//Debug.Log (currentY);
			//Pathfind hello = new Pathfind();
			result = (string) name.Dequeue();
			//Random.Range (0, 3);//
			//result = hello.AStar (map.Length, map.Length, currentX, currentY, 2, 2, map);



			int xdest = result [0] - '0';
			int ydest = result [1] - '0' ;
			//if (currentX > xdest)


			//this.transform.position = new Vector3(worldStart.x + (tileSize * xdest), worldStart.y - (tileSize * ydest), -9.0f);
			//int result = Pathfind.AStar (map.Length, map.Length, currentX, currentY, 2, 2, map);

			//Debug.Log (result);

			///00 -> 01 // move right 

			if (currentY< ydest) {  /// right 

				Debug.Log (result[0]);
				Debug.Log (currentX);
				//Debug.Log (currentY);

					currentY+=1;

				this.transform.Translate (moveX);


			} else if (currentY>ydest) { /// left 
					currentY-=1;

				this.transform.Translate (-moveX);
			} else if (currentX>xdest) { // up

					currentX+=1;


				this.transform.Translate (moveY);


			} else if (currentX<xdest) { /// down

					currentX-=1;
				this.transform.Translate (-moveY);
			}


	
		}
	
	}


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



		public static Queue AStarAgain(int row, int col, int s_row, int s_col, int d_row, int d_col, string[] input_grid)
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
				//Console.WriteLine("Source, Target: " + v.source + " " + v.target);


				if (marked.ContainsKey(v.target))
				{
					continue;
				}

				marked[v.target] = v.source;

				costs = v.cost; // Set equal to the cost it took to get to this point

				// Break if we have reached the destination

				if (((int)Char.GetNumericValue(v.target[0])) == rstart_row && ((int)Char.GetNumericValue(v.target[1])) == rstart_col)
				{
					break;
				}

				// Add in the Nodes that are next to our current Node
				if ((((int)Char.GetNumericValue(v.target[0])) + 1) < mrow)
				{
					//Console.WriteLine("here1");
					char[] curr_row = tile_grid[((int)Char.GetNumericValue(v.target[0])) + 1].ToCharArray();

					string targeting = (((int)Char.GetNumericValue(v.target[0])) + 1).ToString() + v.target[1].ToString();
					Node m = new Node(v.cost + (int)Char.GetNumericValue(curr_row[((int)Char.GetNumericValue(v.target[1]))]) + priority(targeting, destination), targeting
						, v.target);
					frontier.Enqueue(m);
				}
				if ((((int)Char.GetNumericValue(v.target[0])) - 1) >= 0)
				{   
					char[] curr_row = tile_grid[((int)Char.GetNumericValue(v.target[0])) - 1].ToCharArray();

					string targeting = (((int)Char.GetNumericValue(v.target[0])) - 1).ToString() + v.target[1].ToString();
					//Node m = new Node(v.cost + curr_row[v.target.Item2] + priority(v.target, destination), Tuple.Create(v.target.Item1 - 1, v.target.Item2)
					//    , Tuple.Create(v.target.Item1, v.target.Item2));
					Node m = new Node(v.cost + (int)Char.GetNumericValue(curr_row[((int)Char.GetNumericValue(v.target[1]))]) + priority(targeting, destination), targeting
						, v.target);
					frontier.Enqueue(m);

				}
				if ((((int)Char.GetNumericValue(v.target[1])) + 1) < mcol)
				{
					char[] curr_row = tile_grid[((int)Char.GetNumericValue(v.target[0]))].ToCharArray();

					string targeting = (v.target[0]).ToString() + (((int)Char.GetNumericValue(v.target[1])) + 1).ToString();

					Node m = new Node(v.cost + (int)Char.GetNumericValue(curr_row[((int)Char.GetNumericValue(v.target[1])) + 1]) + priority(targeting, destination), targeting
						, v.target);
					frontier.Enqueue(m);
				}
				if ((((int)Char.GetNumericValue(v.target[1])) - 1) >= 0)
				{

					char[] curr_row = tile_grid[((int)Char.GetNumericValue(v.target[0]))].ToCharArray();

					string targeting = (v.target[0]).ToString() + (((int)Char.GetNumericValue(v.target[1])) - 1).ToString();

					Node m = new Node(v.cost + (int)Char.GetNumericValue(curr_row[((int)Char.GetNumericValue(v.target[1])) - 1]) + priority(targeting, destination), targeting
						, v.target);
					frontier.Enqueue(m);
					//Console.WriteLine("Added Target: " + v.target.Item1 + (v.target.Item2 - 1));
					//Console.WriteLine("Added Source: " + v.target.Item1 +  v.target.Item2);
				}
			}

			/*
            foreach(KeyValuePair<string, string> kvp in marked)
            {
                Console.WriteLine("Key: " + kvp.Key);
                Console.WriteLine("Value: " + kvp.Value);
            }
            */

			// Traverse through marked to calculate the proper cost

			string curr_cost = v.target;
			while ((int)Char.GetNumericValue(curr_cost[0]) != rend_row || (int)Char.GetNumericValue(curr_cost[1]) != rend_col)
			{
				costs -= priority(curr_cost, destination);
				curr_cost = marked[curr_cost];
			}

			// If output, print out to the console


			Queue returnVal = new Queue();

			if (output)
			{
				Console.WriteLine("Cost: " + costs);
				string curr = v.target;
				while ((int)Char.GetNumericValue(curr[0]) != rend_row || (int)Char.GetNumericValue(curr[1]) != rend_col)
				{
					Debug.Log(curr);

					returnVal.Enqueue (curr);

					curr = marked[curr];
				}
				Console.WriteLine(curr);
				returnVal.Enqueue (curr);

				Console.WriteLine("End");
				//Console.ReadLine();
			}

			return returnVal;
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

			xdist = Math.Abs(((int)Char.GetNumericValue(current[0])) - ((int)Char.GetNumericValue(destination[0])));
			ydist = Math.Abs(((int)Char.GetNumericValue(current[1])) - ((int)Char.GetNumericValue(destination[1])));
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
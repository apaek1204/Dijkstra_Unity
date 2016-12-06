using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApplication1
{

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

    class Program
    {


        /*
        public bool operator <(Node a)const {  
            return a.cost< this->cost; 
        }
        */
        static void Main()
        {
            int i, j, num_tiles, tile_num;
            int mrow, mcol;
            int text_line_num = 0;
            string line;
            string[] split;
            int rstart_row, rstart_col;
            int rend_row, rend_col;
            string tile_name;
            var tiles = new Dictionary<string, int>();
            //cin >> num_tiles;
            //Console.WriteLine(Directory.GetCurrentDirectory);
            string current_path = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            //C:\Users\Douglas\Documents\Visual Studio 2015\Projects\ConsoleApplication2\ConsoleApplication2\bin\Debug
            //Console.WriteLine(Application.ExecutablePath);
            //Console.ReadLine();
            string[] text = System.IO.File.ReadAllLines(@"..\..\..\..\DS_Final\Paths\Input0.txt");
            //C:\Users\Douglas\Documents\Visual Studio 2015\Projects\DS_Final\Paths
            //string[] text = System.IO.File.ReadAllLines(@"C:\Users\Douglas\Documents\Visual Studio 2015\Projects\DS_Final\Input0.txt");
            //string [] text = System.IO.File.ReadAllLines(@"Input0.txt");
            //Console.Out.WriteLine("Enter int for num_tiles"); 
            //line = Console.ReadLine();
            num_tiles = int.Parse(text[text_line_num]);
            text_line_num++;
            //Console.Out.WriteLine(num_tiles);
            //Console.Out.WriteLine("Hello World!");
            //Console.ReadLine();
            //return;

            for (i = 0; i < num_tiles; i++)
            {
                //cin >> tile_name >> tile_num;
                //Console.Out.WriteLine("Give tile_name");
                //line = Console.ReadLine();
                split = text[text_line_num].Split(' ');
                text_line_num++;
                tile_name = split[0];
                tile_num = int.Parse(split[1]);
                tiles[tile_name] = tile_num;
            }
            foreach (KeyValuePair<string, int> kvp in tiles)
            {
                Console.Out.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
            }
            //cin >> mrow >> mcol;
            //line = Console.ReadLine();
            split = text[text_line_num].Split(' ');
            text_line_num++;
            mrow = int.Parse(split[0]);
            mcol = int.Parse(split[1]);
            string[,] tile_grid = new string[mrow, mcol];
            for (i = 0; i < mrow; i++)
            {
                //line = Console.ReadLine();
                split = text[text_line_num].Split(' ');
                text_line_num++;
                for (j = 0; j < mcol; j++)
                {
                    //cin >> tile_grid[i][j];
                    tile_grid[i, j] = split[j];
                }
            }
            //cin >> rstart_row >> rstart_col; 
            //line = Console.ReadLine();
            split = text[text_line_num].Split(' ');
            text_line_num++;
            rstart_row = int.Parse(split[0]);
            rstart_col = int.Parse(split[1]);
            //cin >> rend_row >> rend_col;
            //line = Console.ReadLine();
            split = text[text_line_num].Split(' ');
            text_line_num++;
            rend_row = int.Parse(split[0]);
            rend_col = int.Parse(split[1]);
            int costs = 0;
            Node v;

            // Possible Error?
            //PriorityQueue<Employee> pq = new PriorityQueue<Employee>();
            PriorityQueue<Node> frontier = new PriorityQueue<Node>();
            //SortedSet<Node> frontier = new SortedSet<Node>();

            //map<pair<int, int>, pair<int, int>> marked;
            var marked = new Dictionary<Tuple<int, int>, Tuple<int, int>>();

            v = new Node(0, Tuple.Create(rend_row, rend_col), Tuple.Create(rend_row, rend_col));
            //frontier.Add(v);
            frontier.Enqueue(v);
            //Console.Out.WriteLine("Target: " + v.target.Item1 + " " + v.target.Item2);
            //Console.Out.WriteLine("Source: " + v.source.Item1 + " " + v.target.Item2);

            int jack = 0;
            while (frontier.Count() != 0)
            {
                //v = frontier.First();
                //frontier.Remove(v);
                v = frontier.Dequeue();
                Console.Out.WriteLine("Grabbing the Target and source of " + jack);
                Console.Out.WriteLine("Cost: " + v.cost);
                Console.Out.WriteLine("Target: " + v.target.Item1 + " " + v.target.Item2);
                Console.Out.WriteLine("Source: " + v.source.Item1 + " " + v.target.Item2);
                jack++;
                if (marked.ContainsKey(v.target))
                    continue;
                marked[v.target] = v.source;
                costs = v.cost;
                //cout << "Currently at " << v.target.first << ", " <<       
                //       v.target.second << " with cost of " << endl;       
                //         cout << "The cost is " << costs << endl;   
                // 
                if (v.target.Item1 == rstart_row && v.target.Item2 == rstart_col)
                    break;
                // u.name = new target  
                // v.name = where i came from 
                if ((v.target.Item1 + 1) < mrow)
                {
                    Node m = new Node(v.cost + tiles[tile_grid[v.target.Item1 + 1, v.target.Item2]], Tuple.Create(v.target.Item1 + 1, v.target.Item2)
                        , Tuple.Create(v.target.Item1, v.target.Item2));
                    frontier.Enqueue(m);
                    //frontier.Add(m);
                    // vtarget is the vertex that it is at 
                    // vsource is the vertex that allowed us to get to vtarget  
                }
                if ((v.target.Item1 - 1) >= 0)
                {
                    Node m = new Node(v.cost + tiles[tile_grid[v.target.Item1 - 1, v.target.Item2]], Tuple.Create(v.target.Item1 - 1, v.target.Item2)
                        , Tuple.Create(v.target.Item1, v.target.Item2));
                    //frontier.Add(m);
                    frontier.Enqueue(m);
                    /* 
                    frontier.push({v.cost + 
                        tiles[tile_grid[v.target.first-1][v.target.second]],  
                            {v.target.first-1, v.target.second},  
                            {v.target.first, v.target.second}});
                    */
                }
                if ((v.target.Item2 + 1) < mcol)
                {
                    Console.Out.WriteLine("We're livin");
                    //int tmp = v.target.Item2 + 1;
                    Node m = new Node(v.cost + tiles[tile_grid[v.target.Item1, v.target.Item2 + 1]], Tuple.Create(v.target.Item1, v.target.Item2 + 1)
                        , Tuple.Create(v.target.Item1, v.target.Item2));
                    //frontier.Add(m);
                    frontier.Enqueue(m);
                }
                if ((v.target.Item2 - 1) >= 0)
                {
                    Node m = new Node(v.cost + tiles[tile_grid[v.target.Item1, v.target.Item2 - 1]], Tuple.Create(v.target.Item1, v.target.Item2 - 1)
                        , Tuple.Create(v.target.Item1, v.target.Item2));
                    //frontier.Add(m);
                    frontier.Enqueue(m);
                }
            }

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

            /*
            cout << costs << endl; 
            pair<int, int> curr = v.target;
            while(curr.first != rend_row || curr.second != rend_col) {
                cout << curr.first << " " << curr.second << endl;
                curr = marked[curr];  
            }
            cout << curr.first << " " << curr.second << endl;    
            //return 0;
            }
            */
        }
        /*
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
        }
        */
    }
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectionsReduction
{
    class Program
    {
        //Write a function dirReduc which will take an array of strings and returns an array of strings
        //with the needless directions removed(W<->E or S<->N side by side).
        static void Main(string[] args)
        {
            string[] a = new string[] { "NORTH", "SOUTH", "SOUTH", "EAST", "WEST", "NORTH", "WEST" };
            string[] b = new string[] { "WEST" };


            foreach (var i in dirReduc(a))
            {
                Console.WriteLine(i);
            }
            
            Console.ReadLine();
        }
        public static string[] dirReduc(String[] arr)
        {
            List<string> reduced = new List<string>();
            List<string> reduced2 = new List<string>();
            for (int i = 0; i <= arr.Length; i++)
            {
                
                    if (i < arr.Length - 1)
                    {
                        if (arr[i] == "NORTH" && arr[i + 1] != "SOUTH"
                            || arr[i] == "SOUTH" && arr[i + 1] != "NORTH"
                            || arr[i] == "EAST" && arr[i + 1] != "WEST"
                            || arr[i] == "WEST" && arr[i + 1] != "EAST")
                        {
                            reduced.Add(arr[i]);
                        }
                        else
                        {
                            i++;
                        }
                    }
                    else if (i == arr.Length - 1)
                    {
                        if (arr[i] == "NORTH" && arr[i - 1] != "SOUTH"
                            || arr[i] == "SOUTH" && arr[i - 1] != "NORTH"
                            || arr[i] == "EAST" && arr[i - 1] != "WEST"
                            || arr[i] == "WEST" && arr[i - 1] != "EAST")
                        {
                            reduced.Add(arr[i]);
                        }
                    }
            }
            for (int i = 0; i <= reduced.Count; i++)
            {
                if (i < reduced.Count - 1)
                {
                    if (reduced[i] == "NORTH" && reduced[i + 1] != "SOUTH"
                    || reduced[i] == "SOUTH" && reduced[i + 1] != "NORTH"
                    || reduced[i] == "EAST" && reduced[i + 1] != "WEST"
                    || reduced[i] == "WEST" && reduced[i + 1] != "EAST")
                    {
                        reduced2.Add(reduced[i]);

                    }
                    else
                    {
                        i++;
                    }
                }
                else if (i == reduced.Count - 1)
                {
                    if (reduced[i] == "NORTH" && reduced[i - 1] != "SOUTH"
                        || reduced[i] == "SOUTH" && reduced[i - 1] != "NORTH"
                        || reduced[i] == "EAST" && reduced[i - 1] != "WEST"
                        || reduced[i] == "WEST" && reduced[i - 1] != "EAST")
                    {
                        reduced2.Add(reduced[i]);
                    }
                }
            }
            return reduced2.ToArray();
        }
        
        
        public static String[] BestPractice(String[] arr)
        {
            Stack<String> stack = new Stack<String>();

            foreach (String direction in arr)
            {
                String lastElement = stack.Count > 0 ? stack.Peek().ToString() : null;

                switch (direction)
                {
                    case "NORTH": if ("SOUTH".Equals(lastElement)) { stack.Pop(); } else { stack.Push(direction); } break;
                    case "SOUTH": if ("NORTH".Equals(lastElement)) { stack.Pop(); } else { stack.Push(direction); } break;
                    case "EAST": if ("WEST".Equals(lastElement)) { stack.Pop(); } else { stack.Push(direction); } break;
                    case "WEST": if ("EAST".Equals(lastElement)) { stack.Pop(); } else { stack.Push(direction); } break;
                }
            }
            String[] result = stack.ToArray();
            Array.Reverse(result);

            return result;
        }
    }
}

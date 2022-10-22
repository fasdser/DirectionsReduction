using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectionsReduction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(dirReduc(new string[] { "NORTH", "SOUTH", "SOUTH", "EAST", "WEST", "NORTH", "WEST" }));
            Console.ReadKey();
        }


        public static string[] dirReduc(String[] arr)
        {
            Stack<String> stack = new Stack<String>();
            foreach (String s in arr)
            {
                String lastElement = stack.Count > 0 ? stack.Peek().ToString() : null;

                switch (s)
                {
                    case "NORTH": if ("SOUTH".Equals(lastElement)) { stack.Pop(); } else { stack.Push(s); } break;
                    case "SOUTH": if ("NORTH".Equals(lastElement)) { stack.Pop(); } else { stack.Push(s); } break;
                    case "EAST":  if ("WEST".Equals(lastElement)) { stack.Pop(); } else { stack.Push(s); } break;
                    case "WEST":  if ("EAST".Equals(lastElement)) { stack.Pop(); } else { stack.Push(s); } break;
                }
            }
            String[] result = stack.ToArray();
            Array.Reverse(result);

            return result;
        }


        public static string[] dirReduc1(String[] arr)
        {
            Dictionary<string, string> oppositeOf = new Dictionary<string, string>()
        {
            {"NORTH", "SOUTH"},
            {"SOUTH", "NORTH"},
            {"EAST", "WEST"},
            {"WEST", "EAST"}
        };

            List<string> betterDirections = new List<string>();
            foreach (var direction in arr)
            {
                if (betterDirections.LastOrDefault() == oppositeOf[direction])
                {
                    betterDirections.RemoveAt(betterDirections.Count - 1);
                }
                else
                {
                    betterDirections.Add(direction);
                }
            }
            return betterDirections.ToArray();
        }
    }
}

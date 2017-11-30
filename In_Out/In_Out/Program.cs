using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace In_Out
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = args[0];
            string str;
            while((str = Console.ReadLine())!=null){
                Out.Write<string>(new string[] { str }, fileName);
            }
        }
    }
    class In
    {
        public static int[] ReadInts(string name){
            List<Int32> nums = new List<int>();
            ParseFile(name, nums,x=>Int32.Parse(x));
            return nums.ToArray();
        }
        public static Double[] ReadDoubles(string name)
        {
            List<Double> nums = new List<Double>();
            ParseFile(name, nums, x => Double.Parse(x));
            return nums.ToArray();
        }
        public static String[] ReadStrings(string name)
        {
            List<String> nums = new List<String>();
            ParseFile(name, nums, x => x);
            return nums.ToArray();
        }

        private static void ParseFile<T>(string name, List<T> list, Func<string,T> ParseFunc)
        {
            using (StreamReader sr = new StreamReader(name))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    T num = ParseFunc(line.Trim());
                    {
                        list.Add(num);
                    }
                }
            }
        }
    }

    class Out
    {
        public static void Write<T>(T[] array, string name)
        {
            using (StreamWriter fs = new StreamWriter(name,true))
            {
                Array.ForEach<T>(array, x => fs.WriteLine(x));
            }
        }
    }
}

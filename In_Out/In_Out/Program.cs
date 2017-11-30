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
            string str;
            while((str = Console.ReadLine())!=null){
                Console.WriteLine(str+"out");
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

        private static void ParseFile<T>(string name, List<T> list, Func<string,T> parseFunc)
        {
            using (StreamReader sr = new StreamReader(name))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    var strs = line.Trim().Split(' ');
                    foreach (var st in strs)
                    {
                        T num = parseFunc(st);
                        {
                            list.Add(num);
                        }
                    }
                }
            }
        }
    }

    //class Out
    //{
    //    public static void Write(int[]array, string name)
    //    {
    //        List<Int32> nums = new List<int>();
    //        ParseFile(name, nums, x => Int32.Parse(x));
    //        return nums.ToArray();
    //    }
    //    public static void Write(double[]array, string name)
    //    {
    //        List<Double> nums = new List<Double>();
    //        ParseFile(name, nums, x => Double.Parse(x));
    //        return nums.ToArray();
    //    }
    //    public static void Write(string[] array, string name)
    //    {
    //        List<String> nums = new List<String>();
    //        ParseFile(name, nums, x => x);
    //        return nums.ToArray();
    //    }

    //    private static void ParseFile<T>(string name, List<T> list, Func<string, T> parseFunc)
    //    {
    //        using (StreamReader sr = new StreamReader(name))
    //        {
    //            string line;
    //            while ((line = sr.ReadLine()) != null)
    //            {
    //                var strs = line.Trim().Split(',');
    //                foreach (var st in strs)
    //                {
    //                    T num = parseFunc(st);
    //                    {
    //                        list.Add(num);
    //                    }
    //                }
    //            }
    //        }
    //    }
    //}
}

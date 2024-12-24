using System;
using System.Reflection.Metadata.Ecma335;

namespace RaonX_SJPark
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Example 01
            Console.WriteLine("======Solution1======");
            List<Example_01> Example_01s = new List<Example_01>
                {
                    new Example_01(3, new string[] {"Jeju", "Pangyo", "Seoul", "NewYork", "LA", "Jeju", "Pangyo", "Seoul", "NewYork", "LA"}),
                    new Example_01(3, new string[] {"Jeju", "Pangyo", "Seoul", "Jeju", "Pangyo", "Seoul", "Jeju", "Pangyo", "Seoul"}),
                    new Example_01(2, new string[] {"Jeju", "Pangyo", "Seoul", "NewYork", "LA", "SanFrancisco", "Seoul", "Rome", "Paris", "Jeju", "NewYork", "Rome"}),
                    new Example_01(5, new string[] {"Jeju", "Pangyo", "Seoul", "NewYork", "LA", "SanFrancisco", "Seoul", "Rome", "Paris", "Jeju", "NewYork", "Rome"}),
                    new Example_01(2, new string[] {"Jeju", "Pangyo", "NewYork", "newyork"}),
                    new Example_01(0, new string[] {"Jeju", "Pangyo", "Seoul", "NewYork", "LA"}),
                };
            Example_01s.ForEach((ex1) => Solution_01(ex1.CacheSize, ex1.Cities));
            #endregion Example 01

            #region Example 02
            Console.WriteLine("======Solution2======");
            List<Example_02> Example_02s = new List<Example_02>
                {
                    new Example_02("1 2 3 4"),
                    new Example_02("-1 -2 -3 -4"),
                    new Example_02("-1 -1"),
                };
            Example_02s.ForEach((ex2) => Solution_02(ex2.S));
            #endregion Example 02

            #region Example 03
            Console.WriteLine("======Solution3======");
            List<Example_03> Example_03s = new List<Example_03>
                {
                    new Example_03("1924", 2),
                    new Example_03("1231234", 3),
                    new Example_03("4177252841", 4),
                };

            Example_03s.ForEach((ex3) => Solution_03(ex3.Number, ex3.K));
            #endregion Example 03
        }

        /// <summary>
        /// solution of example 01
        /// </summary>
        /// <param name="cacheSize"></param>
        /// <param name="cities"></param>
        public static void Solution_01(int cacheSize, string[] cities)
        {
            List<string> cache = new List<string>();
            int answer = 0;

            // input error
            if (cacheSize < 0 || cacheSize > 30)
            {
                Console.WriteLine("Please enter available cache size.");
                return;
            }
            if (cities.Length > 100000)
            {
                Console.WriteLine("Please check the number of cities");
                return;
            }

            // show only cache miss case
            if (cacheSize == 0)
            {
                answer = cities.Length * 5;
                Console.WriteLine($"Execution time: {answer}");
                return;
            }

            for (int i = 0; i < cities.Length; i++)
            {
                string city = cities[i].ToUpper();

                // cache hit
                if (cache.Contains(city))
                {
                    cache.Remove(city);
                    cache.Insert(0, city);

                    answer++;
                }
                else // cache miss
                {
                    if (cache.Count >= cacheSize)
                    {
                        cache.RemoveAt(cache.Count - 1);
                    }
                    cache.Insert(0, city);
                    answer += 5;
                }
            }

            Console.WriteLine($"Execution time: {answer}");
        }

        /// <summary>
        /// solution of example 02
        /// </summary>
        /// <param name="s"></param>
        public static void Solution_02(string s)
        {
            string[] strArr = s.Split(' ');

            if(strArr.Length < 2 ) 
            {
                Console.WriteLine("Please enter the two or more integers separated by spaces.");
                return;
            }

            int[] numArr = Array.ConvertAll(strArr, int.Parse);

            int min = numArr.Min();
            int max = numArr.Max();

            Console.WriteLine($"{min} {max}");
        }

        /// <summary>
        /// solution of example 03
        /// </summary>
        /// <param name="number"></param>
        /// <param name="k"></param>
        public static void Solution_03(string number, int k)
        {
            List<char> charList = new List<char>();
            int removeCnt = k;

            for (int i = 0; i < number.Length;i++)
            {
                char ch = number[i];

                if (charList.Count > 0)
                {
                    for (int j = charList.Count - 1; j >= 0; j--)
                    {
                        if (removeCnt > 0 && charList[j] < ch)
                        {
                            charList.RemoveAt(j);
                            removeCnt--;
                        }
                    }
                }

                charList.Add(ch);
            }

            string answer = new string(charList.ToArray());

            Console.WriteLine($"The biggest value is: {answer}");
        }
    }

    public class Example_01
    {
        public int CacheSize { get; set; }
        public string[] Cities { get; set; }

        public Example_01(int cacheSize, string[] cities)
        {
            CacheSize = cacheSize;
            Cities = cities;
        }
    }

    public class Example_02
    {
        public string S { get; set; }

        public Example_02(string s)
        {
            S = s;
        }
    }
    public class Example_03
    {
        public string Number { get; set; }
        public int K { get; set; }

        public Example_03(string number, int k)
        {
            Number = number;
            K = k;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Task3
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        /*
         * 
         */
        public static IEnumerable<IEnumerable<string>> OnlyBigCollections(List<IEnumerable<string>> toFilter)
        {
            Func<IEnumerable<string>, bool> predicate = list =>
            {
                IEnumerator enumerator = list.GetEnumerator();

                int count = 0;
                while (enumerator.MoveNext() || count <= 5)
                {
                    count++;
                }
                return count > 5;
            };

            return toFilter.Where(predicate);
        }
    }
}

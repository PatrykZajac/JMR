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
         * To obecnie najlepszy pomysł jaki przyszedł mi do głowy, który nie spowoduje stworzenia w pamięci kopii kolekcji, oraz nie będzie wymagać iteracji po niej całej
         * Jeśli byłoby to pobierane z bazy danych i była by możlwość użycia IQueryable to można by użyć Expresions i zastosować do tego mechanizmy bazodanowe
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

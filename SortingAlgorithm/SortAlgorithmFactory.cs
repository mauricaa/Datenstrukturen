using System;
using SortingAlgorithm;

namespace Common
{
    public static class SortAlgorithmFactory
    {
        public static ISortAlgorithm<T> Create<T>(string algorithmName)
            where T : IComparable<T>
        {
            if (string.IsNullOrWhiteSpace(algorithmName))
                throw new ArgumentException("Algorithmus-Name darf nicht leer sein.");

            string name = algorithmName.Trim().ToLower();

            return name switch
            {
                "bubble" or "bubblesort" or "bubble sort"
                    => new BubbleSorts<T>(),

                "insertion" or "insertionsort" or "insertion sort"
                    => new InsertionSorts<T>(),

                _ => throw new ArgumentException(
                    $"Unbekannter Sortieralgorithmus: '{algorithmName}'\n" +
                    "Bekannte: bubble, insertion")
            };
        }

        public static ISortAlgorithm<T> CreateDefault<T>()
            where T : IComparable<T>
        {
            return new BubbleSorts<T>();
        }
    }
}
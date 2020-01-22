namespace DynamicArray
{
    using System;
    using System.Collections;

    internal class Program
    {
        private static void Main()
        {
            var numbers = new Array<int>
            {
                1,
                2,
                3,
                4,
                5,
                6,
                7,
                8,
                9
            };

            numbers.Remove(0);

            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }

            Console.ReadKey();
        }
    }
}

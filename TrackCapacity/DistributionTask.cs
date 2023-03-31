using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnitLite;

namespace DistributionTask
{
    internal class DistributionTask
    {
        static void Main()
        {
            var testsToRun = new string[]
           {
                "DistributionTask.DistributionTaskTests",
           };

            new AutoRun().Execute(new[]
            {
                "--stoponerror",
                "--noresult",
                "--test=" + string.Join(",", testsToRun)
            });

            var truckCapacity = 40;
            Console.WriteLine("Чтобы выйти, нажмите enter");
            while(true)
            {
                Console.Write("Введите количество заказов: ");
                var temporalInput = ReadDigitsFromConsole();
                if (temporalInput == null) return;
                else
                {
                    var result = MakeOptimalDistribution(Int32.Parse(temporalInput), truckCapacity);
                    for (int i = 0; i < result.Length; i++)
                    {
                        Console.Write(result[i] + "\t");
                        if (i % 10 == 0 && i != 0) Console.WriteLine();
                    }
                    Console.WriteLine();
                }
            }
            
        }
        static public int[] MakeOptimalDistribution(int countOfOrder, int truckCapacity)
        {
            if (countOfOrder == 0) return new int[] { };
            var countOfTruck = (int)Math.Ceiling((double)countOfOrder / truckCapacity);
            int[] result = new int[countOfTruck];
            var a = countOfOrder % countOfTruck;
            for (int i = 0; i < result.Length; i++)
                result[i] = (countOfOrder - a) / result.Length;
            for (int i = 0; i < a; i++)
                result[i]++;
            return result;
        }

        public static string ReadDigitsFromConsole()
        {
            string result = null;
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.Backspace:
                        if (result.Length > 0)
                        {
                            result = result.Remove(result.Length - 1, 1);
                            Console.Write(key.KeyChar + " " + key.KeyChar);
                        }
                        break;
                    case ConsoleKey.Enter:
                        Console.WriteLine();
                        return result;
                    default:
                        if (char.IsDigit(key.KeyChar))
                        {
                            Console.Write(key.KeyChar);
                            result += key.KeyChar;
                        }
                        break;
                }       
            }
        }
    }
}

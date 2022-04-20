using System;
using System.Globalization;

namespace _01._Sino_The_Walker
{
    class Program
    {
        static void Main(string[] args)
        {
            var start = DateTime.ParseExact(Console.ReadLine(), "HH:mm:ss", CultureInfo.InvariantCulture);
            int steps = int.Parse(Console.ReadLine());
            int secOneSteps = int.Parse(Console.ReadLine());
            ulong allTimeToHome = (ulong)steps * (ulong)secOneSteps;
            ulong allSeconds = (ulong)(start.Hour * 60 * 60 + start.Minute * 60 + start.Second) + allTimeToHome;
            var sec = allSeconds % 60;
            var totalMinutes = allSeconds / 60;
            var min = totalMinutes % 60;
            var totalHours = totalMinutes / 60;
            var hour = totalHours % 24;



            Console.WriteLine($"Time Arrival: {hour:d2}:{min:d2}:{sec:d2}");

        }
    }
}

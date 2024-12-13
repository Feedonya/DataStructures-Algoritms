using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        (double x, int n)[] testCases =
        {
            (1, 10),
            (2, 200),
            (3, 124),
            (2.1, 5),
            (-6.2, 20),
            (-1, 1001),
            (12, 240),
            (2, 1_000_000),
            (1.000001, 1_000_000),
            (-2, 1_000_000),
            (-2, 1_000_001),
            (123456789, 100_000),
            (0.5, 1_000_000),
            (-1, 1_000_001),
            (10, 10_000_000),
            (100_000_000_000, 10_000_000),
            (100_000_000_000_000_000, 10_000_000_00),
        };

        Console.WriteLine("{0,-15}{1,-15}{2,-20}{3,-20}{4,-20}",
            "x", "n", "Итеративный (мс)", "Math.Pow (мс)", "Улучшенный алгоритм");

        foreach (var (x, n) in testCases)
        {
            var iterativeResult = MeasureIterativeAlgorithm(x, n, out double iterativeTime);
            var mathPowResult = MeasureMathPow(x, n, out double mathPowTime);
            var improvedResult = MeasureImprovedFastPower(x, n, out double improvedTime);

            Console.WriteLine("{0,-15}{1,-15}{2,-20}{3,-20}{4,-20}",
                x, n, iterativeTime, mathPowTime, improvedTime);
        }
    }

    static double MeasureIterativeAlgorithm(double x, int n, out double elapsedTime)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        double power = 1;

        while (n > 0)
        {
            if (n % 2 == 1) power *= x;
            x *= x;
            n /= 2;
        }

        stopwatch.Stop();
        elapsedTime = stopwatch.ElapsedTicks;

        return power;
    }

    static double MeasureMathPow(double x, int n, out double elapsedTime)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();

        double result = Math.Pow(x, n);

        stopwatch.Stop();
        elapsedTime = stopwatch.ElapsedTicks;

        return result;
    }

    static double MeasureImprovedFastPower(double x, int n, out double improvedTime, double power = 1)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();

        while (n > 0)
        {
            if ((n & 1) == 1) power *= x;
            x *= x;
            n >>= 1;
        }

        stopwatch.Stop();
        improvedTime = stopwatch.ElapsedTicks;

        return power;
    }
}
using System.Diagnostics;

public class Program
{
    public static void Main()
    {
        const int arraySize = 10_000_000;
        double[] data = new double[arraySize];
        Random random = new Random();

        for (int i = 0; i < arraySize; i++)
        {
            data[i] = random.NextDouble() * 100;
        }

        double result1 = 0, result2 = 0, result3 = 0, result4 = 0;

        Stopwatch stopwatch = new Stopwatch();

        Parallel.Invoke(
            () => result1 = ProcessAsyncChunk(data, 0, arraySize/4),
            () => result2 = ProcessAsyncChunk(data, 0, arraySize/2),
            () => result3 = ProcessAsyncChunk(data, arraySize/2, 3 * arraySize/4),
            () => result4 = ProcessAsyncChunk(data, 3 * arraySize/4, arraySize)
            );

        stopwatch.Stop();

        double totalResult = result1 + result2 + result3 + result4;

        Console.WriteLine($"Total Result: {totalResult}");
        Console.WriteLine($"Processing Time: {stopwatch.ElapsedMilliseconds}ms");

    }


    private static double ProcessAsyncChunk(double[] array, int start, int end)
    {
        double result = 0;

        for (int i = start; i < end; i++)
        {
            result += Math.Sqrt(array[i]) * Math.Sqrt(array[i]);
        }

        Console.WriteLine($"Processed chunk from {start} to {end}, partial result: {result}");
        return result;
    }
}



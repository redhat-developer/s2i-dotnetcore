using System;
using System.Runtime.InteropServices;

class Program
{
    public static void Main(string[] args)
    {
        // info: Print out information about the .NET Environment.
        if (args.Length > 0 && args[0] == "info")
        {
            Console.WriteLine("---> .NET information:");
            // API not available in 3.1:
            // Console.WriteLine($"Runtime Identifier: {RuntimeInformation.RuntimeIdentifier}");
            Console.WriteLine($"Runtime Version:    {Environment.Version}");
            Console.WriteLine($"Processor Count:    {Environment.ProcessorCount}");
            Console.WriteLine($"Heap Size:          {GC.GetGCMemoryInfo().TotalAvailableMemoryBytes}");
        }
    }
}
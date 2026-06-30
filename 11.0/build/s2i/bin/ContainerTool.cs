using System;
using System.Diagnostics;

class Program
{
    public static void Main(string[] args)
    {
        // info: Print out information about the .NET Environment.
        if (args.Length > 0 && args[0] == "info")
        {
            Console.WriteLine("---> .NET information:");
            Console.WriteLine("Limits:");
            Console.WriteLine($" Processor Count:    {Environment.ProcessorCount}");
            Console.WriteLine($" Heap Size:          {GC.GetGCMemoryInfo().TotalAvailableMemoryBytes}");
            Console.WriteLine();
            Process.Start("dotnet", "--info").WaitForExit();
        }
    }
}
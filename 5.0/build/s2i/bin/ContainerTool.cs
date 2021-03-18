using System;
using System.Runtime.InteropServices;

// info: Print out information about the .NET Environment.
if (args.Length > 0 && args[0] == "info")
{
    Console.WriteLine("---> .NET information:");
    Console.WriteLine($"Runtime Identifier: {RuntimeInformation.RuntimeIdentifier}");
    Console.WriteLine($"Runtime Version:    {Environment.Version}");
    Console.WriteLine($"Processor Count:    {Environment.ProcessorCount}");
    Console.WriteLine($"Heap Size:          {GC.GetGCMemoryInfo().TotalAvailableMemoryBytes}");
}

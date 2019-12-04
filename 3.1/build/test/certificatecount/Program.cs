using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

public class Example
{
    static void Main()
    {
        X509Store store = new X509Store(StoreName.Root, StoreLocation.LocalMachine);
        store.Open(OpenFlags.OpenExistingOnly);
        Console.WriteLine($"#Certificates: {store.Certificates.Count}");
    }
}
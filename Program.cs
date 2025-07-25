using System;
using System.Security.Cryptography;

namespace TestRepo
{
    class Program
    {
        // Hardcoded "secret" - often flagged by code scanners
        private const string ApiKey = "12345-ABCDE";

        static void Main(string[] args)
        {
            Console.WriteLine("This is a test program for Dependabot and GitHub Code Scans.");

            // Use obsolete/Dangerous crypto API example to trigger scan warnings
            using (var md5 = MD5.Create())  // MD5 is insecure, often reported by scanners
            {
                var inputBytes = System.Text.Encoding.UTF8.GetBytes("test input");
                var hashBytes = md5.ComputeHash(inputBytes);
                Console.WriteLine("MD5 hash: " + BitConverter.ToString(hashBytes));
            }
        }
    }
}
using System;
using RestApi.Security.Benchmarks.Benchmarks;
using BenchmarkDotNet.Running;

namespace RestApi.Security.Benchmarks
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<PlainTextVsEncryptedString>();
        }
    }
}

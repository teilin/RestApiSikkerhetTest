using System;
using RestApi.Security.Benchmarks.Benchmarks;
using BenchmarkDotNet.Running;

namespace RestApi.Security.Benchmarks
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var encryptionSummary = BenchmarkRunner.Run<EncryptionBenchmark>();
            var decryptionSummery = BenchmarkRunner.Run<DecryptionBenchmark>();
        }
    }
}

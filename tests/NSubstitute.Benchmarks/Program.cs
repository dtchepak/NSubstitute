using BenchmarkDotNet.Running;

namespace NSubstitute.Benchmarks
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkRunner.Run<ArgumentSpecificationUsageBenchmark>();
            // BenchmarkRunner.Run<ActivationBenchmark>();
            // BenchmarkRunner.Run<DispatchCallBenchmark>();
            // BenchmarkRunner.Run<ToStringCallBenchmark>();
        }
    }
}
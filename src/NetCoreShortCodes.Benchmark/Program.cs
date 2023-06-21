using BenchmarkDotNet.Running;
using NetCoreShortCodes.Benchmark;

// To run benchmarks, change configuration to 'Release' and run the project

//var summary = BenchmarkRunner.Run<Md5VsSha256>();
BenchmarkRunner.Run<LoopIteration>();
BenchmarkRunner.Run<Md5VsSha256>();
using BenchmarkDotNet.Running;
using NetCoreShortCodes.Benchmark;

//var summary = BenchmarkRunner.Run<Md5VsSha256>();
BenchmarkRunner.Run<LoopIteration>();
BenchmarkRunner.Run<Md5VsSha256>();
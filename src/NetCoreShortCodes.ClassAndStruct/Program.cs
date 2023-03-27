using BenchmarkDotNet.Running;
using NetCoreShortCodes.ClassAndStruct;

BenchmarkRunner.Run<ClassIteration>();
BenchmarkRunner.Run<StructIteration>();

//var structIteration = new StructIteration();
//structIteration.SerializeDeserialize();
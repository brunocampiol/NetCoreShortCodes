using BenchmarkDotNet.Running;
using NetCoreShortCodes.ClassAndStruct;
using NetCoreShortCodes.ClassAndStruct.Models;

// First intention was to check performance class vs struct
BenchmarkRunner.Run<ClassIteration>();
BenchmarkRunner.Run<StructIteration>();
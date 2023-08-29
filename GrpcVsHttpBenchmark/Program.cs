using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Toolchains.InProcess.Emit;
using GrpcVdUnaryCallBanchmark;

var config = DefaultConfig.Instance
    .AddJob(Job
        .MediumRun
        .WithLaunchCount(1)
        .WithToolchain(InProcessEmitToolchain.Instance));

BenchmarkRunner.Run<MemoryBenchmarkDemo>(config);
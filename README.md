## Overview
This repository contains a .NET solution consisting of three applications: a gRPC server, an HTTP server, and a console application with a benchmark.

## Installation
To get started, follow these steps:

1. Clone this repository to your local machine.
2. Open the solution file (.sln) in your preferred IDE.
3. Build the solution to restore the necessary dependencies.
4. Run GrpcServer and HttpServer.
5. Run Console Apllication as realese.

## Docker Compose 
The Docker Compose file provided in this repository allows you to easily run the gRPC server and the HTTP server in a containerized environment.

## Usage
Each application serves a different purpose and can be used independently. Here's a brief description of each:

1. gRPC Server: This application provides a gRPC server implementation. It allows clients to communicate with the server using the gRPC protocol. To use this application, run the server and configure your gRPC client to connect to the specified endpoint.

2. HTTP Server: This application provides an HTTP server implementation. It allows clients to interact with the server using HTTP requests. To use this application, run the server and send HTTP requests to the specified endpoint.

3. Console Application with Benchmark: This application is designed to benchmark the performance of the gRPC and HTTP servers. It measures response times and throughput under different scenarios. To use this application, run the benchmark.

## Results of benchmark
Job=MediumRun  Toolchain=InProcessEmitToolchain  IterationCount=15
LaunchCount=1  WarmupCount=10

|         Method |     Mean |    Error |   StdDev | Allocated |
|--------------- |---------:|---------:|---------:|----------:|
| CallGrpcServer | 582.5 us | 12.01 us |  9.38 us |   6.48 KB |
| CallHttpServer | 767.6 us | 39.53 us | 36.98 us |   3.08 KB |


// * Hints *
Outliers
  MemoryBenchmarkDemo.CallGrpcServer: MediumRun -> 1 outlier  was  removed (375.91 us)
  MemoryBenchmarkDemo.CallHttpServer: MediumRun -> 3 outliers were removed (466.59 us..504.92 us)

// * Legends *
  Mean      : Arithmetic mean of all measurements
  Error     : Half of 99.9% confidence interval
  StdDev    : Standard deviation of all measurements
  Gen0      : GC Generation 0 collects per 1000 operations
  Allocated : Allocated memory per single operation (managed only, inclusive, 1KB = 1024B)
  1 us      : 1 Microsecond (0.000001 sec)
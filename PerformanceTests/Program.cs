using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Order;
using Perfolizer.Horology;
using System;
using System.Buffers;
using System.Buffers.Binary;
using System.Buffers.Text;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Numerics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO.Compression;
#if NETCOREAPP3_0_OR_GREATER
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
#endif

[DisassemblyDiagnoser(maxDepth: 1)] // change to 0 for just the [Benchmark] method
[MemoryDiagnoser(displayGenColumns: false)]
public class Program
{
    public static void Main(string[] args) =>
        BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args, DefaultConfig.Instance
            //.WithSummaryStyle(new SummaryStyle(CultureInfo.InvariantCulture, printUnitsInHeader: false, SizeUnit.B, TimeUnit.Microsecond))
        );

    /*[Benchmark]
    public int TestA()
    {
        return A(10);
    }

    [Benchmark]
    public int TestB()
    {
        return B(10);
    }*/

    [Benchmark]
    public int TestC()
    {
        return C();
    }

    [Benchmark]
    public int TestD()
    {
        return D();
    }
    public int A(int y)
    {
        int sum = 0;
        Func<int, bool> filter = x => x > y;
        for (int i = 0; i < 500; i++)
        {
            if(filter(i))
            {
                sum += i;
            }
        }

        return sum;
    }

    public int B(int y)
    {
        int sum = 0;
        bool filter(int x) => x > y;

        for (int i = 0; i < 500; i++)
        {
            if(filter(i))
            {
                sum += i;
            }
        }

        return sum;
    }

    private IEnumerable<int> _data = new int[] { 10, 20, 1000, 4, 5000 };

    public int C()
    {
        return _data.Where(x => x > 100).First();
    }

    public int D()
    {
        return _data.First(x => x > 100);
    }



}
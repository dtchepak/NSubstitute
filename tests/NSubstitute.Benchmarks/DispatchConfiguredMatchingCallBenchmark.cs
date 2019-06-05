﻿using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Jobs;
using NSubstitute.Benchmarks.TestTypes;
using NSubstitute.Core;

namespace NSubstitute.Benchmarks
{
    [ClrJob, CoreJob]
    [MemoryDiagnoser]
    public class DispatchConfiguredMatchingCallBenchmark
    {
        private readonly IInterfaceWithSingleMethod _interfaceProxy;
        private readonly AbstractClassWithSingleMethod _abstractClassProxy;
        private readonly ClassWithSingleMethod _classPartialProxy;
        private readonly IntDelegate _intDelegateProxy;
        private readonly VoidDelegate _voidDelegateProxy;

        public DispatchConfiguredMatchingCallBenchmark()
        {
            _interfaceProxy = Substitute.For<IInterfaceWithSingleMethod>();
            _interfaceProxy.IntMethod("42").Returns(42);
            _interfaceProxy.When(x => x.VoidMethod("42")).Do(delegate {  });
            
            _abstractClassProxy = Substitute.For<AbstractClassWithSingleMethod>();
            _abstractClassProxy.IntMethod("42").Returns(42);
            _abstractClassProxy.When(x => x.VoidMethod("42")).Do(delegate {  });
            
            _classPartialProxy = Substitute.For<ClassWithSingleMethod>();
            _classPartialProxy.IntMethod("42").Returns(42);
            _classPartialProxy.When(x => x.VoidMethod("42")).Do(delegate {  });
            
            _intDelegateProxy = Substitute.For<IntDelegate>();
            _intDelegateProxy.Invoke("42").Returns(42);
            
            _voidDelegateProxy = Substitute.For<VoidDelegate>();
            _voidDelegateProxy.When(x => x.Invoke("42")).Do(delegate {  });
        }

        [Benchmark]
        public int DispatchInterfaceProxyCall_Int() => _interfaceProxy.IntMethod("42");
        
        [Benchmark]
        public int DispatchAbstractClassProxyCall_Int() => _abstractClassProxy.IntMethod("42");

        [Benchmark]
        public int DispatchClassPartialProxyCall_Int() => _classPartialProxy.IntMethod("42");

        [Benchmark]
        public int DispatchDelegateCall_Int() => _intDelegateProxy.Invoke("42");

        [Benchmark]
        public void DispatchInterfaceProxyCall_Void() => _interfaceProxy.VoidMethod("42");
        
        [Benchmark]
        public void DispatchAbstractClassProxyCall_Void() => _abstractClassProxy.VoidMethod("42");

        [Benchmark]
        public void DispatchClassPartialProxyCall_Void() => _classPartialProxy.VoidMethod("42");

        [Benchmark]
        public void DispatchDelegateCall_Void() => _voidDelegateProxy.Invoke("42");
    }
}
using System;
using Functions.Interfaces;
using InfraStrcuture;
using Xunit.Abstractions;

namespace FunctionTests
{
    public class TestBase 
    {
        protected readonly ITestOutputHelper InnerOutputWriter;
        protected ITestImplementation Impl;

        protected TestBase(ITestOutputHelper innerOutputWriter)
        {
            this.InnerOutputWriter = innerOutputWriter;
            RegisterDependencies();
        }

        private void RegisterDependencies()
        {
            Type t = typeof (ITestImplementation);
            
            //GlobalIocContainer.Instance().RegisterUserSpecificITypesOf(t.Assembly);
            GlobalIocContainer.Instance().RegisterUserSpecificITypesOf(t.Assembly, "START");

            Impl = GlobalIocContainer.Instance().Resolve<ITestImplementation>();
        }
    }
}
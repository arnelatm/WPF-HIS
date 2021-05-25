using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Autofac;
using IContainer = Autofac.IContainer;

namespace CAccounts
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();
            //builder.RegisterType<SalaryLoanSchedulePresenter>().As<ISalaryLoanSchedulePresenter>();
            return builder.Build();
        }

        //public static class IContainer Configure()
        //{
        //    //var builder = new ContainerBuilder();
        //    //builder.registerBuildType()
        //}
    }
}
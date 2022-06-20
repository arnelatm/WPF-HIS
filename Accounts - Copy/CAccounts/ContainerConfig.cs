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
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<SalaryLoanSchedule>.As < ISalaryLoanScheduleView >
            // var container = containerBuilder.Build();

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
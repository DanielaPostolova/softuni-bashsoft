using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using BashSoft.Core;
using BashSoft.Core.Contracts;
using ConsoleClient.Infrastructure;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {

            var autofacConfig = new AutofacConfig();
            autofacConfig.Config();

            var engine = autofacConfig.Container.Resolve<IEngine>();
            engine.Start();
        }
    }
}

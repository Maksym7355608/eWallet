using eWallet.BLL.Interfaces;
using eWallet.BLL.Services;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWallet.BLL.Infrastructure
{
    public class ClientModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IClientService>().To<ClientService>();
        }
    }
}

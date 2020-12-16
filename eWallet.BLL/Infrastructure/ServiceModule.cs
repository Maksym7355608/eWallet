using eWallet.DAL.Interfaces;
using eWallet.DAL.Repositories;
using Ninject.Modules;

namespace eWallet.BLL.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private readonly string connection;

        public ServiceModule(string connection)
        {
            this.connection = connection;
        }

        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>().WithConstructorArgument(connection);
        }
    }
}

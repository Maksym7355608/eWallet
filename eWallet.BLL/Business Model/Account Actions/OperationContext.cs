using eWallet.BLL.Interfaces;

namespace eWallet.BLL.Business_Model.Account_Actions
{
    public class OperationContext
    {
        private IOperation operation;
        private IClientService client;

        public OperationContext(IClientService service, IOperation operation)
        {
            client = service;
            this.operation = operation;
        }

        public void Execute()
        {
            client.UpdateAccount(operation.Execute());
        }
    }
}

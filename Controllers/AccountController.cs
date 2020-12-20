using eWallet.BLL.Interfaces;
using eWallet.Models;
using System.Web.Mvc;
using AutoMapper;
using eWallet.BLL.DTO.PersonalAccountDTO;
using eWallet.BLL.DTO.Currency;
using System.Collections.Generic;
using System;
using eWallet.BLL.Business_Model.Account_Actions;
using System.Threading.Tasks;
using System.Threading;

namespace eWallet.Controllers
{
    public class AccountController : Controller
    {
        private IClientService clientService;
        private static ClientViewModel client;
        private IMapper mapperClient = new MapperConfiguration(c => c.CreateMap<ClientDTO, ClientViewModel>()).CreateMapper();
        private IMapper mapperAccount = new MapperConfiguration(c => c.CreateMap<AccountDTO, AccountViewModel>()).CreateMapper();
        private IMapper mapperAccountView = new MapperConfiguration(c => c.CreateMap<AccountViewModel, AccountDTO>()).CreateMapper();
        private IMapper mapperClientView = new MapperConfiguration(c => c.CreateMap<ClientViewModel, ClientDTO>()).CreateMapper();
        private OperationContext operationContext;

        public AccountController(IClientService service)
        {
            clientService = service;
        }
        public void Getter(int id)
        {
            var x = clientService.GetClient(id);
            ICollection<AccountViewModel> accounts = mapperAccount.
                Map<ICollection<AccountDTO>, ICollection<AccountViewModel>>
                ((ICollection<AccountDTO>)clientService.GetAccounts(id));

            ClientViewModel c = mapperClient.Map<ClientDTO, ClientViewModel>(x);
            c.Money = accounts;

            client = c;

            Response.Redirect("/Account/Accounts");
        }
        public ActionResult Accounts()
        {
            return View(client);
        }
        [HttpGet]
        public ActionResult NewAccount()
        {
            List<CurrencyDTO> last = new List<CurrencyDTO>();
            for (int i = 0; i < Enum.GetValues(typeof(CurrencyDTO)).Length; i++)
            {
                bool flag = false;
                foreach (var item in client.Money)
                {
                    if ((int)item.Name == i)
                    {
                        flag = false;
                        break;
                    }
                    else flag = true;
                }
                if (flag)
                    last.Add((CurrencyDTO)i);
            }
            return View(last);
        }
        [HttpPost]
        public void NewAccount(CurrencyDTO? currency)
        {
            clientService.CreateAccount(new AccountDTO { ClientId = client.Id, Name = (CurrencyDTO)currency, Value = default });
            Response.Redirect("/Account/Accounts");
        }
        [HttpGet]
        public ActionResult Deposit()
        {
            return View(client);
        }
        [HttpPost]
        public void Deposit(int account, string method, double value, string methodNum)
        {
            if (method.Length == 0 || methodNum.Length == 0)
            { 
                Response.Redirect("/Account/Deposit");
                return;
            }

            var x = clientService.GetClientAccount(account);

            ClientDTO mappedClient = new ClientDTO
            {
                Id = client.Id,
                Money = mapperAccountView.Map<ICollection<AccountViewModel>,
                ICollection<AccountDTO>>(client.Money)
            };

            operationContext = new OperationContext(clientService, 
                new Deposit(mappedClient, x.Name, value));
            operationContext.Execute();

            Getter(client.Id);
        }
        [HttpGet]
        public ActionResult Withdraw()
        {
            return View(client);
        }
        [HttpPost]
        public void Withdraw(int account, string method, double value, string methodNum)
        {
            if (method.Length == 0 || methodNum.Length == 0)
            {
                Response.Redirect("/Account/Withdraw");
                return;
            }
            var x = clientService.GetClientAccount(account);

            ClientDTO mappedClient = new ClientDTO
            {
                Id = client.Id,
                Money = mapperAccountView.Map<ICollection<AccountViewModel>,
                ICollection<AccountDTO>>(client.Money)
            };

            operationContext = new OperationContext(clientService,
                new Withdraw(mappedClient, x.Name, value));
            operationContext.Execute();

            Getter(client.Id);
        }
        [HttpGet]
        public ActionResult Exchange()
        {
            return View(client);
        }
        [HttpPost]
        public void Exchange(int from, int to, double value)
        {
            if (value == 0)
            {
                Response.Redirect("/Account/Exchange");
                return;
            }

            ClientDTO mappedClient = new ClientDTO
            {
                Id = client.Id,
                Money = mapperAccountView.Map<ICollection<AccountViewModel>,
                ICollection<AccountDTO>>(client.Money)
            };

            var input = clientService.GetClientAccount(from);
            var output = clientService.GetClientAccount(to);

            operationContext = new OperationContext(clientService, new Exchange(mappedClient, input.Name, output.Name, value));
            operationContext.Execute();

            Getter(client.Id);
        }
    }
}
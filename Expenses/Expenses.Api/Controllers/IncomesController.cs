using Expenses.Data.Context;
using Expenses.Data.Services;
using Expenses.Data.UnitOfWork;
using ExpensesApp.Core.Models.Income;
using System.Net.Http;
using System.Web.Http;

namespace Expenses.Api.Controllers
{
    [RoutePrefix("api/incomes")]
    public class IncomesController : BaseController
    {
        // GET: Incomes
        private IncomeService _incomeService { get; set; }
        private UnitOfWorkContainer _uow { get; set; }
        private EntityContext _context;

        public IncomesController()
        {
            _context = new EntityContext();
            _uow = new UnitOfWorkContainer(_context);
            _incomeService = new IncomeService(_uow);
        }

        [HttpGet]
        [Route("all")]
        public HttpResponseMessage GetIncomes()
        {
            return GetResponse(_incomeService.GetIncomes());
        }

        [HttpGet]
        [Route("history/byuser/{id}")]
        public HttpResponseMessage GetIncomesByUser(int id)
        {
            return GetResponse(_incomeService.GetIncomesByUser(id));
        }

        [HttpGet]
        [Route("byid/{id}")]
        public HttpResponseMessage GetIncomeById(int id)
        {
            return GetResponse(_incomeService.GetIncomeById(id));
        }

        [HttpGet]
        [Route("total/byuser/{iduser}")]
        public HttpResponseMessage GetIncomeByUser(int iduser)
        {
            return GetResponse(_incomeService.GetIncomesTotal(iduser));
        }

        [HttpPost]
        [Route("create")]
        public HttpResponseMessage PostIncome([FromBody] CreateIncomeModel createIncome)
        {
            return GetResponse(_incomeService.PostIncome(createIncome));
        }

        [HttpPut]
        [Route("update/{id}")]
        public HttpResponseMessage PutIncome([FromBody] UpdateIncomeModel updateIncome, int id)
        {
            return GetResponse(_incomeService.PutIncome(updateIncome, id));
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public HttpResponseMessage DeleteIncome(int id)
        {
            return GetResponse(_incomeService.DeleteIncome(id));
        }
    }
}
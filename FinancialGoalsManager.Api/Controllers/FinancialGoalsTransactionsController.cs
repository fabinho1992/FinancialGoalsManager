using FinancialGoalsManager.Application.Commands.FinancialGoalsTransactionsCommands.CreateFinancialGoalsTransactions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinancialGoalsManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinancialGoalsTransactionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FinancialGoalsTransactionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateFinancialGoalsTransactionsCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}

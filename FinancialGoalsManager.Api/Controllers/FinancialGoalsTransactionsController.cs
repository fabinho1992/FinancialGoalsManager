using FinancialGoalsManager.Application.Commands.FinancialGoalsTransactionsCommands.CreateFinancialGoalsTransactions;
using FinancialGoalsManager.Application.Queries.TransactionsQueries.TransactionById;
using FinancialGoalsManager.Application.Queries.TransactionsQueries.TransactionByIdFinancial;
using FinancialGoalsManager.Application.Queries.TransactionsQueries.TransactionsList;
using FinancialGoalsManager.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
        public async Task<IActionResult> Create(CreateTransactionsCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PaginationParameters pagination)
        {
            var query = new TransactionListQuery(pagination.PageNumber, pagination.PageSize);
            var result = await _mediator.Send(query);

            if (!result.IsSuccess)
            {
                return NotFound(result.Message);
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new TransactionByIdQuery(id);
            var result = await _mediator.Send(query);

            if (!result.IsSuccess)
            {
                return NotFound(result.Message);
            }

            return Ok(result);
        }

        [HttpGet("financialGoalId/{id}")]
        public async Task<IActionResult> GetByIdFinancialGoal(Guid id)
        {
            var query = new TransactionFinanQuery(id);
            var result = await _mediator.Send(query);

            if (!result.IsSuccess)
            {
                return NotFound(result.Message);
            }

            return Ok(result);
        }
    }
}


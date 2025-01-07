using FinancialGoalsManager.Application.Commands.FinancialGoalCommands.CreateFinancialGoal;
using FinancialGoalsManager.Application.Queries.FinancialGoalQueries.FinancialGoalList;
using FinancialGoalsManager.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinancialGoalsManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinancialGoalsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FinancialGoalsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateFinancialGoalCommand command)
        {
            var result = await _mediator.Send(command);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PaginationParameters pagination)
        {
            var query = new FinancialGoalListQuery(pagination.PageNumber, pagination.PageSize);
            var result = await _mediator.Send(query);

            if (!result.IsSuccess)
            {
                return NotFound(result.Message);
            }

            return Ok(result);
        }
    }
}

using FinancialGoalsManager.Application.Commands.FinancialGoalCommands.CreateFinancialGoal;
using FinancialGoalsManager.Application.Commands.FinancialGoalCommands.DeleteFinancialGoal;
using FinancialGoalsManager.Application.Commands.FinancialGoalCommands.UpdateFinancialGoal;
using FinancialGoalsManager.Application.Queries.FinancialGoalQueries.FinancialGoalById;
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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new FinancialGoalByIdQuery(id);
            var result = await _mediator.Send(query);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteFinancialCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();

        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateFinancialGoalCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }
    }
}

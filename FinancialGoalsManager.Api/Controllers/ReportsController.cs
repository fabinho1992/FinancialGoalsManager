using FastReport.Export.PdfSimple;
using FastReport.Web;
using FinancialGoalsManager.Application.Queries.ReportsQueries.TransactionsReports;
using FinancialGoalsManager.Application.ServiceReport;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinancialGoalsManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IGenerateDataTableReport _generateDataTableReport;

        public ReportsController(IMediator mediator, IWebHostEnvironment webHostEnvironment,
            IGenerateDataTableReport generateDataTableReport)
        {
            _mediator = mediator;
            _webHostEnvironment = webHostEnvironment;
            _generateDataTableReport = generateDataTableReport;
        }

        [HttpGet("Transactions_report/{id}")]
        public async Task<IActionResult> DonationsReport(Guid id)
        {
            var transactions = new TransactionsReportQuery(id);
            if (transactions is null)
            {
                return NotFound();
            }
            var result = await _mediator.Send(transactions);

            var webReport = new WebReport();
            webReport.Report.Load(Path.Combine(_webHostEnvironment.ContentRootPath, "Reports", "Transactio.frx"));

            // Passando o parâmetro para o relatório
            webReport.Report.SetParameterValue("FinancialGoalId", id.ToString());

            _generateDataTableReport.DataTableReportTransactions(result, webReport);


            webReport.Report.Prepare();

            using MemoryStream stream = new MemoryStream();
            webReport.Report.Export(new PDFSimpleExport(), stream);
            stream.Flush();
            byte[] arrayReport = stream.ToArray();
            return File(arrayReport, "application/zip", "TransactionsReport.pdf");

        }

        //[HttpGet("TransactionsReport/{id}")]
        //public async Task<IActionResult> TransactionsReport(Guid id)
        //{

        //}

    }
}

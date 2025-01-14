using FinancialGoalsManager.Domain.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoalsManager.Application.Dtos.ViewModels.FinancialGoalsTransactionsResponses
{
    public class TransactionByIdResponse
    {
        public TransactionByIdResponse(Guid id, string nameBox, Guid boxId, double amount,
            string transactionDate, TransactionTypeEnum transactionType)
        {
            Id = id;
            NameBox = nameBox;
            BoxId = boxId;
            Amount = amount;
            TransactionDate = transactionDate;
            TransactionType = transactionType;
        }

        public Guid Id { get; private set; }
        public string NameBox { get; private set; }
        public Guid BoxId { get; private set; }
        public double Amount { get; private set; }
        public string TransactionDate { get; private set; }
        public TransactionTypeEnum TransactionType { get; private set; }
    }
}

using System;
using SlothEnterprise.ProductApplication.Products;

namespace SlothEnterprise.ProductApplication.Adapters
{
    public interface ISubmissionServiceFactory
    {
        ISubmissionServiceAdapter GetService(IProduct product);
    }

    public class SubmissionServiceFactory : ISubmissionServiceFactory
    {
        private readonly IBusinessLoanServiceAdapter _businessLoanServiceAdapter;
        private readonly IConfidentialInvoiceServiceAdapter _confidentialInvoiceServiceAdapter;
        private readonly ISelectInvoiceServiceAdapter _selectInvoiceServiceAdapter;

        public SubmissionServiceFactory(IBusinessLoanServiceAdapter businessLoanServiceAdapter,
            IConfidentialInvoiceServiceAdapter confidentialInvoiceServiceAdapter,
            ISelectInvoiceServiceAdapter selectInvoiceServiceAdapter)
        {
            _businessLoanServiceAdapter = businessLoanServiceAdapter;
            _confidentialInvoiceServiceAdapter = confidentialInvoiceServiceAdapter;
            _selectInvoiceServiceAdapter = selectInvoiceServiceAdapter;
        }

        public ISubmissionServiceAdapter GetService(IProduct product)
        {
            switch (product)
            {
                case BusinessLoans _:
                    return _businessLoanServiceAdapter;
                case ConfidentialInvoiceDiscount _:
                    return _confidentialInvoiceServiceAdapter;
                case SelectiveInvoiceDiscount _:
                    return _selectInvoiceServiceAdapter;
                default:
                    throw new ArgumentOutOfRangeException(nameof(product));
            }
        }
    }
}
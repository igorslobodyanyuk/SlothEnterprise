using System;
using SlothEnterprise.External.V1;
using SlothEnterprise.ProductApplication.Applications;
using SlothEnterprise.ProductApplication.Products;

namespace SlothEnterprise.ProductApplication.Adapters
{
    public interface ISelectInvoiceServiceAdapter : ISubmissionServiceAdapter
    {
    }

    public class SelectInvoiceServiceAdapter : ISelectInvoiceServiceAdapter
    {
        private readonly ISelectInvoiceService _selectInvoiceService;

        public SelectInvoiceServiceAdapter(ISelectInvoiceService selectInvoiceService)
        {
            _selectInvoiceService = selectInvoiceService;
        }

        public int SubmitApplicationFor(ISellerApplication application)
        {
            var sid = application.Product as SelectiveInvoiceDiscount;
            if (sid == null)
                throw new ArgumentException(
                    $"Invalid application product type for SelectInvoice service. Expected: {nameof(SelectiveInvoiceDiscount)}. Actual: {application.Product?.GetType().Name}.");

            return _selectInvoiceService.SubmitApplicationFor(application.CompanyData.Number.ToString(),
                sid.InvoiceAmount, sid.AdvancePercentage);
        }
    }
}
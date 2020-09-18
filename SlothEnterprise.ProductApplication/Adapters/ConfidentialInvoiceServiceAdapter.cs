using System;
using SlothEnterprise.External;
using SlothEnterprise.External.V1;
using SlothEnterprise.ProductApplication.Applications;
using SlothEnterprise.ProductApplication.Products;

namespace SlothEnterprise.ProductApplication.Adapters
{
    public interface IConfidentialInvoiceServiceAdapter : ISubmissionServiceAdapter
    {
    }

    public class ConfidentialInvoiceServiceAdapter : IConfidentialInvoiceServiceAdapter
    {
        private IConfidentialInvoiceService _confidentialInvoiceService;

        public ConfidentialInvoiceServiceAdapter(IConfidentialInvoiceService confidentialInvoiceService)
        {
            _confidentialInvoiceService = confidentialInvoiceService;
        }

        public int SubmitApplicationFor(ISellerApplication application)
        {
            var cid = application.Product as ConfidentialInvoiceDiscount;
            if (cid == null)
                throw new ArgumentException(
                    $"Invalid application product type for ConfidentialInvoice service. Expected: {nameof(ConfidentialInvoiceDiscount)}. Actual: {application.Product?.GetType().Name}.");
            
            var result = _confidentialInvoiceService.SubmitApplicationFor(
                new CompanyDataRequest
                {
                    CompanyFounded = application.CompanyData.Founded,
                    CompanyNumber = application.CompanyData.Number,
                    CompanyName = application.CompanyData.Name,
                    DirectorName = application.CompanyData.DirectorName
                }, cid.TotalLedgerNetworth, cid.AdvancePercentage, cid.VatRate);

            return result.Success && result.ApplicationId.HasValue
                ? result.ApplicationId.Value
                : ApplicationConstants.DefaultApplicationId;
        }
    }
}
using System;
using SlothEnterprise.External;
using SlothEnterprise.External.V1;
using SlothEnterprise.ProductApplication.Applications;
using SlothEnterprise.ProductApplication.Products;

namespace SlothEnterprise.ProductApplication.Adapters
{
    public interface IBusinessLoanServiceAdapter : ISubmissionServiceAdapter
    {
    }

    public class BusinessLoanServiceAdapter : IBusinessLoanServiceAdapter
    {
        private readonly IBusinessLoansService _businessLoansService;

        public BusinessLoanServiceAdapter(IBusinessLoansService businessLoansService)
        {
            _businessLoansService = businessLoansService;
        }

        public int SubmitApplicationFor(ISellerApplication application)
        {
            var loans = application.Product as BusinessLoans;
            if (loans == null)
                throw new ArgumentException(
                    $"Invalid application product type for BusinessLoans service. Expected: {nameof(BusinessLoans)}. Actual: {application.Product?.GetType().Name}.");

            var result = _businessLoansService.SubmitApplicationFor(
                new CompanyDataRequest
            {
                CompanyFounded = application.CompanyData.Founded,
                CompanyNumber = application.CompanyData.Number,
                CompanyName = application.CompanyData.Name,
                DirectorName = application.CompanyData.DirectorName
            }, 
                new LoansRequest
            {
                InterestRatePerAnnum = loans.InterestRatePerAnnum,
                LoanAmount = loans.LoanAmount
            });

            return result.Success && result.ApplicationId.HasValue
                ? result.ApplicationId.Value
                : ApplicationConstants.DefaultApplicationId;
        }
    }
}
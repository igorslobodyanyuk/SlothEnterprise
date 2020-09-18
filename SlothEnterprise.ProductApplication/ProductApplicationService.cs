using System;
using SlothEnterprise.External;
using SlothEnterprise.External.V1;
using SlothEnterprise.ProductApplication.Adapters;
using SlothEnterprise.ProductApplication.Applications;
using SlothEnterprise.ProductApplication.Products;

namespace SlothEnterprise.ProductApplication
{
    public class ProductApplicationService
    {
        private readonly ISubmissionServiceFactory _submissionServiceFactory;

        public ProductApplicationService(ISubmissionServiceFactory submissionServiceFactory)
        {
            _submissionServiceFactory = submissionServiceFactory;
        }

        public int SubmitApplicationFor(ISellerApplication application)
        {
            if (application == null)
                throw new ArgumentNullException(nameof(application));

            var service = _submissionServiceFactory.GetService(application.Product);

            return service.SubmitApplicationFor(application);
        }
    }
}

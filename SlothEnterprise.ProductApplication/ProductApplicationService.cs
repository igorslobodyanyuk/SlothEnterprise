using System;
using SlothEnterprise.ProductApplication.Adapters;
using SlothEnterprise.ProductApplication.Applications;

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

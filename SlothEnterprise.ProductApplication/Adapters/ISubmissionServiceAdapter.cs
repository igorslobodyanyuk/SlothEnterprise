using SlothEnterprise.ProductApplication.Applications;

namespace SlothEnterprise.ProductApplication.Adapters
{
    public interface ISubmissionServiceAdapter
    {
        int SubmitApplicationFor(ISellerApplication application);
    }
}
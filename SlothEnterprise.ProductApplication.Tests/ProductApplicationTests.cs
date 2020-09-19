using System;
using Moq;
using SlothEnterprise.ProductApplication.Adapters;
using SlothEnterprise.ProductApplication.Applications;
using SlothEnterprise.ProductApplication.Products;
using Xunit;

namespace SlothEnterprise.ProductApplication.Tests
{
    public class ProductApplicationTests
    {
        private readonly Mock<ISubmissionServiceFactory> _submissionServiceFactoryMock;
        private readonly ProductApplicationService _productApplicationService;

        public ProductApplicationTests()
        {
            _submissionServiceFactoryMock = new Mock<ISubmissionServiceFactory>();
            _productApplicationService = new ProductApplicationService(_submissionServiceFactoryMock.Object);
        }

        [Fact]
        public void SubmitNull_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() =>
                _productApplicationService.SubmitApplicationFor(null)
            );
        }

        [Fact]
        public void SubmitApplication_ReturnsCorrectResultFromSumbissionService()
        {
            var mockAdapter = new Mock<ISelectInvoiceServiceAdapter>();
            mockAdapter.Setup(adapter => adapter.SubmitApplicationFor(It.IsAny<ISellerApplication>())).Returns(1);

            _submissionServiceFactoryMock.Setup(factory => factory.GetService(It.IsAny<IProduct>()))
                .Returns(mockAdapter.Object);

            var result = _productApplicationService.SubmitApplicationFor(new SellerApplication());

            Assert.Equal(1, result);
        }
    }
}

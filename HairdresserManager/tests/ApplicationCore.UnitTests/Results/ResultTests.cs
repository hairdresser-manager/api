using System;
using ApplicationCore.Results;
using Xunit;

namespace ApplicationCore.UnitTests.Results
{
    public class ResultTests
    {
        [Fact]
        public void SuccessMethodCreatesAnEmptyErrorsCollectionAndSucceededStatus()
        {
            var result = ServiceResult.Success();
            
            Assert.Equal(Array.Empty<string>(), result.Errors);
            Assert.True(result.Succeeded);
        }

        [Fact]
        public void FailureMethodCreatesAnNotEmptyErrorsCollectionAndNotSucceededStatus()
        {
            var result = ServiceResult.Failure("some error");
            
            Assert.NotEqual(Array.Empty<string>(), result.Errors);
            Assert.False(result.Succeeded);
        }

        [Fact]
        public void FailureMethodCreatesAnNotEmptyErrorsCollectionAndNotSucceededStatus2()
        {
            var result = ServiceResult.Failure(new[] {"some error"});
            
            Assert.NotEqual(Array.Empty<string>(), result.Errors);
            Assert.False(result.Succeeded);
        }
    }
}
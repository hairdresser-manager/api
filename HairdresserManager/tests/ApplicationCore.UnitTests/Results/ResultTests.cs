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
            var result = Result.Success();
            
            Assert.Equal(Array.Empty<string>(), result.Errors);
            Assert.True(result.Succeeded);
        }

        [Fact]
        public void FailureMethodCreatesAnNotEmptyErrorsCollectionAndNotSucceededStatus()
        {
            var result = Result.Failure("some error");
            
            Assert.NotEqual(Array.Empty<string>(), result.Errors);
            Assert.False(result.Succeeded);
        }

        [Fact]
        public void FailureMethodCreatesAnNotEmptyErrorsCollectionAndNotSucceededStatus2()
        {
            var result = Result.Failure(new[] {"some error"});
            
            Assert.NotEqual(Array.Empty<string>(), result.Errors);
            Assert.False(result.Succeeded);
        }
    }
}
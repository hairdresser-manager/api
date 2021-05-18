using System;
using ApplicationCore.Results;
using Xunit;

namespace ApplicationCore.UnitTests.Results
{
    public class ResultTests
    {
        [Fact]
        public void SuccessMethodCreatesAnEmptyErrorsCollection()
        {
            var result = Result.Success();
            Assert.Equal(result.Errors, Array.Empty<string>());
        }

        [Fact]
        public void FailureMethodCreatesAnNotEmptyErrorsCollection()
        {
            var result = Result.Failure("some error");
            Assert.NotEqual(result.Errors, Array.Empty<string>());
        }

        [Fact]
        public void FailureMethodCreatesAnNotEmptyErrorsCollection2()
        {
            var result = Result.Failure(new[] {"some error"});
            Assert.NotEqual(result.Errors, Array.Empty<string>());
        }
    }
}
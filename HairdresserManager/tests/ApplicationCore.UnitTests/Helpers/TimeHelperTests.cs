using System;
using ApplicationCore.Helpers;
using Xunit;

namespace ApplicationCore.UnitTests.Helpers
{
    public class TimeHelperTests
    {
        [Theory]
        [InlineData(1, 59)]
        [InlineData(23, 59)]
        [InlineData(0, 0)]
        [InlineData(0, 1)]
        [InlineData(21, 37)]
        public void ShouldCastTo24HourFormatTheory(int hourToCast, int minuteToCast)
        {
            var (hour, minute) = TimeHelper.CastTo24HourFormat($"{hourToCast}:{minuteToCast}");

            Assert.Equal(hourToCast, hour);
            Assert.Equal(minuteToCast, minute);
        }

        [Theory]
        [InlineData(1, 60)]
        [InlineData(24, 60)]
        [InlineData(-1, 56)]
        [InlineData(23, -1)]
        public void ShouldNotCastTo24HourFormat(int hourToCast, int minuteToCast)
        {
            try
            {
                var (hour, minute) = TimeHelper.CastTo24HourFormat($"{hourToCast}:{minuteToCast}");

                Assert.NotEqual(hourToCast, hour);
                Assert.NotEqual(minuteToCast, minute);
            }
            catch (InvalidCastException e)
            {
                Assert.NotNull(e);
            }
        }
    }
}
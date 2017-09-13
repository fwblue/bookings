using System;
using Xunit;

namespace BookingUnitTest
{
    public class BookingTest
    {
        [Theory]
        [InlineData("nigel", true)]
        [InlineData("felix", true)]
        [InlineData("mike", true)]
        [InlineData("bill", false)]
        public void ValidUserId(string userId, bool expectedResult)
        {
            bool testValue = userId.Equals("nigel", StringComparison.OrdinalIgnoreCase) || userId.Equals("felix", StringComparison.OrdinalIgnoreCase) || userId.Equals("mike", StringComparison.OrdinalIgnoreCase);
            Assert.True(testValue == expectedResult, $"Invalid user name {userId}");
        }
    }
}
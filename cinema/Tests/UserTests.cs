using cinema.Data.Entities;
using Xunit;

namespace cinema.Tests
{
    public class UserTests
    {
        [Theory]
        [InlineData("+7(993)123-34-45", "89931233445")]
        [InlineData("8 993 123 34 45", "89931233445")]
        [InlineData("8(993)123-8656", "89931238656")]
        [InlineData("+7 993-12635-21", "89931263521")]
        [InlineData("89931238656", "89931238656")]
        public void CheckPhoneNumberCorrect(string phoneNumber, string resultPhoneNumber)
        {
            string? result = User.Create("123", phoneNumber)?.phone_number;

            Assert.Equal(result, resultPhoneNumber);
        }

        [Theory]
        [InlineData("8-993-123-34-45", null)]
        [InlineData("8(993)123-34-453", null)]
        [InlineData("", null)]
        [InlineData("abracadabra", null)]
        [InlineData("992 123-45-67", null)]
        [InlineData("+7-995-123-12-34", null)]
        public void CheckPhoneNumberNull(string phoneNumber, string? resultPhoneNumber)
        {
            string? result = User.Create("123", phoneNumber)?.phone_number;

            Assert.Equal(result, resultPhoneNumber);
        }

    }
}

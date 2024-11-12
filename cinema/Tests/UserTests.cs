using cinema.Data.Entities;
using Xunit;
using Xunit.Abstractions;

namespace cinema.Tests
{
    public class UserTests
    {
        private readonly ITestOutputHelper _output;
        
        public UserTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Theory]
        [InlineData("+7(993)123-34-45", "89931233445")]
        [InlineData("8 993 123 34 45", "89931233445")]
        [InlineData("8(993)123-8656", "89931238656")]
        [InlineData("+7 993-12635-21", "89931263521")]
        [InlineData("89931238656", "89931238656")]
        public void CheckPhoneNumberCorrect(string phoneNumber, string resultPhoneNumber)
        {
            string? result = User.Create("123", phoneNumber)?.phone_number;

            _output.WriteLine($"Входной номер: {phoneNumber}. Ожидаемый ответ: {resultPhoneNumber}. Полученный ответ: {result}");

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

            _output.WriteLine($"Входной номер: {phoneNumber}. Ожидаемый ответ: {resultPhoneNumber ?? "null"}. Полученный ответ: {result ?? "null"}");

            Assert.Equal(result, resultPhoneNumber);
        }

    }
}

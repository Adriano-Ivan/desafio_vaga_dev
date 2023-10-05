using ClientesAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ClientesAPI.Tests.Services
{
    public class ClienteServiceTests
    {
        [Fact]
        public void Valid_Cpf_Is_True()
        {
            CpfValidator validator = new CpfValidator();

            var validCpf = "492.294.270-04";

            bool isValid = validator.IsValid(validCpf);

            Assert.True(isValid);   
        }

        [Fact]
        public void Invalid_Cpf_Is_False()
        {
            CpfValidator validator = new CpfValidator();

            var validCpf = "33445612337ADFDF";

            bool isValid = validator.IsValid(validCpf);

            Assert.False(isValid);
        }
    }
}

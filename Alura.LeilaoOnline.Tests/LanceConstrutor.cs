using System;
using Xunit;
using Alura.LeilaoOnline.Core;

namespace Alura.LeilaoOnline.Tests
{
    public class LanceConstrutor
    {
        [Fact]
        public void LancaArgumentExceptionDadoValorNegativo()
        {
            // Arrange
            var valorNegativo = -100;

            // Assert
            Assert.Throws<ArgumentException>(() => {
                return new Lance(null, valorNegativo);
            });
        }
    }
}
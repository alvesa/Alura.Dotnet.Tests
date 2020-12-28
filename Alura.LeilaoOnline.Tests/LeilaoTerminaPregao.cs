using Alura.LeilaoOnline.Core;
using Xunit;
using System;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoTerminaPregao
    {
        [Fact]
        public void LancaInvalidOperationExceptionDadoPregaoNaoIniciado()
        {
            // Arrange
            var leilao = new Leilao("Van Gogh");

            var exceptionObitida = Assert.Throws<InvalidOperationException>(() => {
                // Act
                leilao.TerminaPregao();
            });

            var msgEsperada = "Não é possivel terminar o pregao sem que ele tenha começado. Para isso inicie o metodo iniciaPregao";
             
            // Assert
            Assert.Equal(msgEsperada, exceptionObitida.Message);
        }

        [Fact]
        public void RetornaZeroDadoLeilaoSemLances()
        {
            // Arrange
            var leilao = new Leilao("Van Gogh");

            leilao.IniciaPregao();
            
            // Act
            leilao.TerminaPregao();

            // Assert
            var valorEsperado = 0;
            var valorObtido = leilao.Ganhador.Valor;
            
            Assert.Equal(valorEsperado, valorObtido);
        }


        [Theory]
        [InlineData(1200, new double[] {800, 900, 1000, 1200})]
        [InlineData(1000, new double[] {800, 900, 1000, 990})]
        [InlineData(800, new double[] {800})]
        public void RetornaMaiorValorDadodLeilaoComPeloMenosUmLance(double valorEsperado, double[] ofertas )
        {
            // Arrange
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            var maria = new Interessada("Maria", leilao);

            leilao.IniciaPregao();
            for (int i = 0; i < ofertas.Length; i++)
            {
                if(i%2 == 0)
                    leilao.RecebeLance(fulano, ofertas[i]);
                else
                    leilao.RecebeLance(maria, ofertas[i]);
            }

            // Act
            leilao.TerminaPregao();

            // Assert
            var valorObtido = leilao.Ganhador.Valor;
            
            Assert.Equal(valorEsperado, valorObtido);
        }
    }
}
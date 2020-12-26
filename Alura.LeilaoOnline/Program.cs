using System;
using Alura.LeilaoOnline.Core;

namespace Alura.LeilaoOnline
{
    class Program
    {
        static void Main(string[] args)
        {
            LeilaoComVariosLances();
            LeilaoComUmLance();
        }
        private static void LeilaoComVariosLances()
        {
            // Arrange
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            var maria = new Interessada("Maria", leilao);

            leilao.RecebeLance(fulano, 800);
            leilao.RecebeLance(maria, 900);
            leilao.RecebeLance(fulano, 1000);
            leilao.RecebeLance(maria, 990);

            // Act
            leilao.TerminaPregao();

            // Assert
            var valorEsperado = 1000;
            var valorObtido = leilao.Ganhador.Valor;
            
            Verifica(valorEsperado, valorObtido);

        }

        static void LeilaoComUmLance()
        {
            // Arrange
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);

            leilao.RecebeLance(fulano, 800);

            // Act
            leilao.TerminaPregao();

            // Assert
            var valorEsperado = 800;
            var valorObtido = leilao.Ganhador.Valor;
            
            Verifica(valorEsperado, valorObtido);
        }

        private static void Verifica(double esperado, double obtido)
        {
            var cor = Console.ForegroundColor;

            if(esperado == obtido){
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("TESTE OK");
            }
            else{
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"TESTE FALHOU! Esperado: {esperado}, obtido: {obtido}");
            }

            Console.ForegroundColor = cor;
        }
    }
}

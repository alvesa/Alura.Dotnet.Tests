﻿using System;
using Alura.LeilaoOnline.Core;

namespace Alura.LeilaoOnline
{
    class Program
    {
        static void Main(string[] args)
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
            Console.WriteLine(leilao.Ganhador.Valor);
        }
    }
}

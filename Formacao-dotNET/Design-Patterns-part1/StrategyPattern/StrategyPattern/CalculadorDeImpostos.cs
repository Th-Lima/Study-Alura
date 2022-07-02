﻿namespace CursoDesignPatterns1
{
    public class CalculadorDeImpostos
    { 
        public void RealizaCalculo(Orcamento orcamento, IImposto imposto)
        {
            double icms = imposto.Calcula(orcamento);
            Console.WriteLine(icms);
        }
    }
}

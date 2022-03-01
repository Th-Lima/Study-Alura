using ConsultandoCollections;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsultandoComLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            // PROBLEMA: Obter os nomes dos meses do ano que tem 31 dias. em maiusculo e em ordem alfabética
            //Janeiro 31
            //Fevereiro 28
            //Março 31
            //Abril 30
            //Maio 31
            //Junho 30
            //Julho 31
            //Agosto 31
            //Setembro 30
            //Outubro 31
            //Novembro 30
            //Dezembro 31
            
            List<Mes> meses = new List<Mes>
            {
                new Mes("Janeiro", 31),
                new Mes("Fevereiro", 28),
                new Mes("Março", 31),
                new Mes("Abril", 30),
                new Mes("Maio", 31),
                new Mes("Junho", 30),
                new Mes("Julho", 31),
                new Mes("Agosto", 31),
                new Mes("Setembro", 30), 
                new Mes("Outubro", 31),
                new Mes("Novembro", 30),
                new Mes("Dezembro", 31)
            };

            //Montagem da consulta
            var mesesQuery = meses
                .Where(x => x.QtdDias == 31)
                .OrderBy(x => x.NomeMes)
                .Select(x => x.NomeMes.ToUpper() + $" - DIAS: {x.QtdDias}");
            
            //Utilização da consulta
            foreach (var mes in mesesQuery)
            {
                Console.WriteLine(mes);
            }
        }
    }
}
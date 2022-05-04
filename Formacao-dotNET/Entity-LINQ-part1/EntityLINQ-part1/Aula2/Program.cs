﻿using System;
using System.Linq;
using System.Xml.Linq;

namespace Aula2
{
    class Program
    {
        static void Main(string[] args)
        {
            XElement root = XElement.Load(@"..\..\..\Data\AluraTunes.xml");

            var queryXML =
                from g in root.Element("Generos").Elements("Genero")
                select g;

            foreach (var genero in queryXML)
            {
                Console.WriteLine("{0}\t{1}", genero.Element("GeneroId").Value, genero.Element("Nome").Value);
            }

            var queryMusicasEGeneros =
                from g in root.Element("Generos").Elements("Genero")
                join m in root.Element("Musicas").Elements("Musica")
                on g.Element("GeneroId").Value equals m.Element("GeneroId").Value
                select new
                {
                    Musica = m.Element("Nome").Value,
                    Genero = g.Element("Nome").Value
                };

            foreach (var generosMusicas in queryMusicasEGeneros)
            {
                Console.WriteLine("{0}\t{1}", generosMusicas.Musica, generosMusicas.Genero);
            }
        }
    }
}

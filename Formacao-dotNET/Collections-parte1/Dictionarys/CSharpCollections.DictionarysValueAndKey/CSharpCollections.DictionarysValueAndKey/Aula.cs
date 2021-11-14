using System;

namespace CSharpCollections.DictionarysValueAndKey
{
    public class Aula : IComparable
    {
        private string titulo;
        private int tempo;

        public string Titulo { get => titulo; set => titulo = value; }
        public int Tempo { get => tempo; set => tempo = value; }

        public Aula(string titulo, int tempo)
        {
            Titulo = titulo;
            Tempo = tempo;
        }

        public override string ToString()
        {
            return $"Título: {titulo} | Tempo: {tempo}m";
        }

        public int CompareTo(object obj)
        {
            Aula that = obj as Aula;
            return this.titulo.CompareTo(that.titulo);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CSharpCollections.PowerOfSets2
{
    public class Curso
    {
        private ISet<Aluno> alunos = new HashSet<Aluno>();

        public IList<Aluno> Alunos
        {
            get
            {
                return new ReadOnlyCollection<Aluno>(alunos.ToList());
            }
        }

        private IList<Aula> aulas;

        public IList<Aula> Aulas
        {
            get
            {
                return new ReadOnlyCollection<Aula>(aulas);
            }
        }

        internal void Adiciona(Aula aula)
        {
            this.aulas.Add(aula);
        }

        public string Nome { get => nome; set => nome = value; }
        public string Instrutor { get => instrutor; set => instrutor = value; }

        private string nome;

        internal void Matricula(Aluno aluno)
        {
            alunos.Add(aluno);
        }

        private string instrutor;

        public int TempoTotal
        {
            get
            {
                //int total = 0;
                //foreach(var aula in aulas)
                //{
                //    total = total + aula.Tempo;
                //}

                //return total;

                //LINQ
                return aulas.Sum(x => x.Tempo);
            }
        }


        public Curso(string nome, string instrutor)
        {
            aulas = new List<Aula>();
            this.nome = nome;
            this.instrutor = instrutor;
        }

        public override string ToString()
        {
            return $"Nome: {nome} | Instrutor: {instrutor} | Tempo total: {TempoTotal}\nAulas: {string.Join(" , ", aulas)}";
        }

        public bool EstaMatriculado(Aluno aluno)
        {
            return alunos.Contains(aluno);
        }
    }
}

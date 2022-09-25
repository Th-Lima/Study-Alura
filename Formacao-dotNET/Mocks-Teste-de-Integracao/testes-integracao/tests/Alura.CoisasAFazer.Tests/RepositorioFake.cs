using Alura.CoisasAFazer.Core.Models;
using Alura.CoisasAFazer.Infrastructure;

namespace Alura.CoisasAFazer.Tests
{
    public class RepositorioFake : IRepositorioTarefas
    {
        List<Tarefa> lista = new List<Tarefa>();

        public void AtualizarTarefas(params Tarefa[] tarefas)
        {
            throw new NotImplementedException();
        }

        public void ExcluirTarefas(params Tarefa[] tarefas)
        {
            throw new NotImplementedException();
        }

        public void IncluirTarefas(params Tarefa[] tarefas)
        {
            throw new Exception("Houve um erro ao incluir as tarefas");
            //foreach (var item in tarefas)
            //{
            //    lista.Add(item);
            //}

            tarefas.ToList().ForEach(x => lista.Add(x));
        }

        public Categoria ObtemCategoriaPorId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tarefa> ObtemTarefas(Func<Tarefa, bool> filtro)
        {
            var result = lista.Where(filtro);

            if (!result.Any())
                throw new NullReferenceException("Tarefa não encontrada");

            return result;
        }
    }
}

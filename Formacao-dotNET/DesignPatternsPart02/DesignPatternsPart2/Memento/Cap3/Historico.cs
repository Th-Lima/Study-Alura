namespace Memento.Cap3
{
    public class Historico
    {
        private IList<EstadoDoContrato> Estados = new List<EstadoDoContrato>();

        public void Adiciona(EstadoDoContrato estado)
        {
            this.Estados.Add(estado);
        }

        public EstadoDoContrato Pega(int indice)
        {
            return Estados[indice];
        }
    }
}

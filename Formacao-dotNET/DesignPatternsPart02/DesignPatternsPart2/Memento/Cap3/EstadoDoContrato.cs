namespace Memento.Cap3
{
    public class EstadoDoContrato
    {
        public Contrato Contrato { get; private set; }

        public EstadoDoContrato(Contrato contrato)
        {
            Contrato = contrato;
        }
    }
}

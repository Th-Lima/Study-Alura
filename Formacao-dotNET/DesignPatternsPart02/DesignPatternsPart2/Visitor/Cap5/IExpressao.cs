namespace Visitor.Cap5
{
    public interface IExpressao
    {
        int Avalia();

        void Aceita(IVisitor impressora);
    }
}

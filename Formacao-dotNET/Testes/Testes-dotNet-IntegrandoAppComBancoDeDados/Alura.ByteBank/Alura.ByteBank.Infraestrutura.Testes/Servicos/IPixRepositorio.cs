using Alura.ByteBank.Infraestrutura.Testes.Servicos.DTO;

namespace Alura.ByteBank.Infraestrutura.Testes.Servicos
{
    public interface IPixRepositorio
    {
        public PixDTO consultaPix(Guid pix);
    }
}

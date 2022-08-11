using Alura.ByteBank.Dados.Contexto;

namespace Alura.ByteBank.Infraestrutura.Testes
{
    public class ByteBankContextoTeste
    {
        [Fact]
        public void TestaConexaoComBDMySQL()
        {
            //Arrange
            var contexto = new ByteBankContexto();
            bool conectado;

            //Act
            try
            {
                conectado = contexto.Database.CanConnect();
            }
            catch (Exception e)
            {
                throw new Exception("Não foi possível conectar a base de dados", e);
            }

            //Assert
            Assert.True(conectado);
        }
    }
}

using Patrimonio.Domains;
using Xunit;

namespace Patrimonio.Test.Domains
{
    public class UsuarioDomainTests
    {
        [Fact] // Descrição
        public void DeveRetornarUsuarioPreenchido()
        {
            // Pré-Condição / Arrange
            Usuario usuario = new Usuario();
            usuario.Email = "lima@email.com";
            usuario.Senha = "1234";

            // Procedimento / Act
            bool resultado = true;

            if (usuario.Senha == null || usuario.Email == null) 
                resultado = false;


            // Resultado esperado / Assert
            Assert.True(resultado);

        }
    }
}

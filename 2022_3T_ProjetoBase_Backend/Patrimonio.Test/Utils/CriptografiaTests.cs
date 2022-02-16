using Patrimonio.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xunit;

namespace Patrimonio.Test.Utils
{
    public class CriptografiaTests
    {
        [Fact]
        public void DeveRetornarHashBCrypt()
        {
            // Pré-Condição
            var senha = Cripto.GerarHash("123456789");
            var regex = new Regex(@"^\$2[ayb]\$.{56}$");

            // Procedimento
            bool retorno = regex.IsMatch(senha);

            // Resultado esperado
            Assert.True(retorno);
        }

        [Fact]
        public void DeveRetornarComparacaoValida()
        {
            // Pré-Condição
            var senha = "123456789";
            var hash = "$2a$11$PCJcIvnOaQQ0eODKX7t/X.bJ14EChYEC18xg/5ahIfn2JMZbmLwV2";

            // Procedimento
            bool comparacao = Cripto.CompararSenha(senha, hash);

            // Resultado esperado
            Assert.True(comparacao);
        }
    }
}

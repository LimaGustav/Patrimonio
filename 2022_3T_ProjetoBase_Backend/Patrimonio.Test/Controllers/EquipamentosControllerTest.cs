using Microsoft.AspNetCore.Mvc;
using Moq;
using Patrimonio.Controllers;
using Patrimonio.Domains;
using Patrimonio.Interfaces;
using System.Collections.Generic;
using Xunit;

namespace Patrimonio.Test.Controllers
{
    public class EquipamentosControllerTest
    {
        [Fact]
        public void DeveRetornarUmaListaDeEquipamentos()
        {
            // Pré-Condição
            List<Equipamento> lista = new List<Equipamento>();
            Equipamento eq1 = new Equipamento();
            lista.Add(eq1);

            var fakeRepository = new Mock<IEquipamentoRepository>();
            fakeRepository
                .Setup(x => x.Listar())
                .Returns(lista);

            var controller = new EquipamentosController(fakeRepository.Object);
            // Procedimentos
            var resultado = controller.GetEquipamentos();
            // Resultado Esperado
            Assert.IsType<OkObjectResult>(resultado);
        }

    }
}

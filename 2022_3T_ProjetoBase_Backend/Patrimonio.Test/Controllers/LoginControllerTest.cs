using Microsoft.AspNetCore.Mvc;
using Moq;
using Patrimonio.Controllers;
using Patrimonio.Domains;
using Patrimonio.Interfaces;
using Patrimonio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Patrimonio.Test.Controllers
{
    public class LoginControllerTest
    {
        [Fact]
        public void DeveRetornarUmUsuarioInvalido()
        {
            // Pré-Condição
            var fakeRepository = new Mock<IUsuarioRepository>();
            fakeRepository
                .Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>()))
                .Returns((Usuario)null);

            LoginViewModel loginViewModel = new LoginViewModel();
            loginViewModel.Email = "lima@email.com";
            loginViewModel.Senha = "123456789";

            var controller = new LoginController(fakeRepository.Object);
            // Procedimento
            var resultado = controller.Login(loginViewModel);

            // Resultado esperado
            Assert.IsType<UnauthorizedObjectResult>(resultado);
        }

        [Fact]
        public void DeveRetornarUmUsuarioValido()
        {
            // Pré-Condição
            var usuarioFake = new Usuario();
            usuarioFake.Email = "tsuka@email.com";
            usuarioFake.Senha = "$2a$11$PCJcIvnOaQQ0eODKX7t/X.bJ14EChYEC18xg/5ahIfn2JMZbmLwV2";


            var fakeRepository = new Mock<IUsuarioRepository>();
            fakeRepository
                .Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(usuarioFake);

            LoginViewModel loginViewModel = new LoginViewModel();
            loginViewModel.Email = "lima@email.com";
            loginViewModel.Senha = "123456789-000";

            var controller = new LoginController(fakeRepository.Object);
            // Procedimento
            var resultado = controller.Login(loginViewModel);

            // Resultado esperado
            Assert.IsType<OkObjectResult>(resultado);
        }
    }
}

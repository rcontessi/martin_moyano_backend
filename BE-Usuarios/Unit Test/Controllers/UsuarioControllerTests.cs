using NUnit.Framework;
using BE_Usuarios.Services;
using BE_Usuarios.Repository.Interfaces;
using Moq;
using BE_Usuarios.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BE_Usuarios.Controllers;
using BE_Usuarios.Services.Interfaces;
using BE_Usuarios.Common.Models;
using BE_Usuarios.Common.Dtos;

namespace BE_Usuarios.Unit_Test.Controllers
{
    [TestFixture]
    public class UsuarioControllerTests
    {
        private UsuarioServices _usuarioServices;
        private Mock<IUsuarioRepository> _mockUsuarioRepository;
        private Mock<IUsuarioServices> _mockUsuarioServices;
        [SetUp]
        public void Setup()
        {
            _mockUsuarioRepository = new Mock<IUsuarioRepository>();
            _usuarioServices = new UsuarioServices(_mockUsuarioRepository.Object);
        }

        [TestMethod]
        public void TestObtenerUsuarios()
        {
            _mockUsuarioServices.Setup(x => x.ObtenerUsuarios()).Returns(Task.Run(() => new UsuariosDto()));
            UsuarioController usuarioController = new UsuarioController(_mockUsuarioServices.Object);
            var usuarios = usuarioController.Get();
            NUnit.Framework.Assert.NotNull(usuarios.Result);
        }
    }
}

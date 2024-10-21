using Moq;
using WebAPI_Funcionarios.Controllers;
using WebAPI_Funcionarios.Service.FuncionarioService;

namespace WebApi_Funcionarios.Tests;

public class FuncionarioControllerTests
{
    [Fact]
    public void Constructor_InitializesController()
    {
        // Arrange
        var service = new Mock<IFuncionarioInterface>();

        // Act
        var controller = new FuncionarioController(service.Object);

        // Assert
        Assert.NotNull(controller);
    }
}
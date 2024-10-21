using Microsoft.AspNetCore.Mvc;
using Moq;
using WebAPI_Funcionarios.Controllers;
using WebAPI_Funcionarios.Models;
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

    [Fact]
    public async Task GetFuncionarios_ReturnsOkResult_WhenCalled()
    {
        // Arrange
        var mockService = new Mock<IFuncionarioInterface>();
        mockService.Setup(service => service.GetFuncionario())
            .ReturnsAsync(new ServiceResponse<List<FuncionarioModel>>
            {
                Sucesso = true,
                Dados = new List<FuncionarioModel>()
            });
        var controller = new FuncionarioController(mockService.Object);

        // Act
        var result = await controller.GetFuncionarios();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var serviceResponse = Assert.IsType<ServiceResponse<List<FuncionarioModel>>>(okResult.Value);
        Assert.True(serviceResponse.Sucesso);
    }
}
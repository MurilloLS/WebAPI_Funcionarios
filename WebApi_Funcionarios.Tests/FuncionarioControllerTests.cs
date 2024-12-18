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
        Assert.NotNull(serviceResponse.Dados);
    }

    [Fact]
    public async Task GetFuncionarioById_ReturnsFuncionario_WhenExists()
    {
        // Arrange
        var funcionario = new FuncionarioModel { Id = 1, Nome = "Murillo", Sobrenome = "Santos" };
        var mockService = new Mock<IFuncionarioInterface>();
        mockService.Setup(s => s.GetFuncionarioById(1))
            .ReturnsAsync(new ServiceResponse<FuncionarioModel>
            {
                Sucesso = true,
                Dados = funcionario
            });
        var controller = new FuncionarioController(mockService.Object);

        // Act
        var result = await controller.GetFuncionarioById(1);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var serviceResponse = Assert.IsType<ServiceResponse<FuncionarioModel>>(okResult.Value);
        Assert.Equal(funcionario.Id, serviceResponse.Dados.Id);
    }

    [Fact]
    public async Task PostFuncionario_ReturnsOkResult_WhenFuncionarioIsCreated()
    {
        // Arrange
        var newFuncionario = new FuncionarioModel { Id = 2, Nome = "Murillo", Sobrenome = "Santos" };
        var mockService = new Mock<IFuncionarioInterface>();
        mockService.Setup(s => s.CreateFuncionario(newFuncionario))
            .ReturnsAsync(new ServiceResponse<List<FuncionarioModel>>
            {
                Sucesso = true,
                Dados = new List<FuncionarioModel> { newFuncionario }
            });
        var controller = new FuncionarioController(mockService.Object);

        // Act
        var result = await controller.PostFuncionario(newFuncionario);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var serviceResponse = Assert.IsType<ServiceResponse<List<FuncionarioModel>>>(okResult.Value);
        Assert.True(serviceResponse.Sucesso);
        Assert.Contains(newFuncionario, serviceResponse.Dados);
    }

    [Fact]
    public async Task InativaFuncionario_ReturnsOkResult_WhenFuncionarioIsInactivated()
    {
        // Arrange
        var mockService = new Mock<IFuncionarioInterface>();
        mockService.Setup(s => s.InativaFuncionario(1))
            .ReturnsAsync(new ServiceResponse<List<FuncionarioModel>>
            {
                Sucesso = true,
                Dados = new List<FuncionarioModel>()
            });
        var controller = new FuncionarioController(mockService.Object);

        // Act
        var result = await controller.InativaFuncionario(1);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var serviceResponse = Assert.IsType<ServiceResponse<List<FuncionarioModel>>>(okResult.Value);
        Assert.True(serviceResponse.Sucesso);
    }

    [Fact]
    public async Task AtivaFuncionario_ReturnsOkResult_WhenFuncionarioIsActivated()
    {
        // Arrange
        var mockService = new Mock<IFuncionarioInterface>();
        mockService.Setup(s => s.AtivaFuncionario(1))
            .ReturnsAsync(new ServiceResponse<List<FuncionarioModel>>
            {
                Sucesso = true,
                Dados = new List<FuncionarioModel>()
            });
        var controller = new FuncionarioController(mockService.Object);

        // Act
        var result = await controller.AtivaFuncionario(1);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var serviceResponse = Assert.IsType<ServiceResponse<List<FuncionarioModel>>>(okResult.Value);
        Assert.True(serviceResponse.Sucesso);
    }

    [Fact]
    public async Task UpdateFuncionario_ReturnsOkResult_WhenFuncionarioIsUpdated()
    {
        // Arrange
        var editedFuncionario = new FuncionarioModel { Id = 1, Nome = "Murillo", Sobrenome = "Atualizado" };
        var mockService = new Mock<IFuncionarioInterface>();
        mockService.Setup(s => s.UpdateFuncionario(editedFuncionario))
            .ReturnsAsync(new ServiceResponse<List<FuncionarioModel>>
            {
                Sucesso = true,
                Dados = new List<FuncionarioModel> { editedFuncionario }
            });
        var controller = new FuncionarioController(mockService.Object);

        // Act
        var result = await controller.UpdateFuncionario(editedFuncionario);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var serviceResponse = Assert.IsType<ServiceResponse<List<FuncionarioModel>>>(okResult.Value);
        Assert.True(serviceResponse.Sucesso);
        Assert.Contains(editedFuncionario, serviceResponse.Dados);
    }

    [Fact]
    public async Task DeleteFuncionario_ReturnsOkResult_WhenFuncionarioIsDeleted()
    {
        // Arrange
        var mockService = new Mock<IFuncionarioInterface>();
        mockService.Setup(s => s.DeleteFuncionario(1))
            .ReturnsAsync(new ServiceResponse<List<FuncionarioModel>>
            {
                Sucesso = true,
                Dados = new List<FuncionarioModel>()
            });
        var controller = new FuncionarioController(mockService.Object);

        // Act
        var result = await controller.DeleteFuncionario(1);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var serviceResponse = Assert.IsType<ServiceResponse<List<FuncionarioModel>>>(okResult.Value);
        Assert.True(serviceResponse.Sucesso);
    }
}
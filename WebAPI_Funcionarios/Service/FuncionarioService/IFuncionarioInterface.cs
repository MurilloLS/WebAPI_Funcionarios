using WebAPI_Funcionarios.Models;

namespace WebAPI_Funcionarios.Service.FuncionarioService
{
    public interface IFuncionarioInterface
    {
        Task<ServiceResponse<List<FuncionarioModel>>> GetFuncionario();
        Task<ServiceResponse<List<FuncionarioModel>>> CreateFuncionario(FuncionarioModel newFuncionario);
        Task<ServiceResponse<FuncionarioModel>> GetFuncionarioById(int id);
        Task<ServiceResponse<List<FuncionarioModel>>> UpdateFuncionario(FuncionarioModel editedFuncionario);
        Task<ServiceResponse<List<FuncionarioModel>>> DeleteFuncionario(int id);
        Task<ServiceResponse<List<FuncionarioModel>>> InativaFuncionario(int id);
    }
}

using WebAPIHospitalCP04.Dto.PlanoSaude;
using WebAPIHospitalCP04.Models;

namespace WebAPIHospitalCP04.Services.PlanoSaude
{
    public interface IPlanoSaudeInterface
    {
        Task<ResponseModel<List<PlanoSaudeModel>>> ListarPlanos();
        Task<ResponseModel<PlanoSaudeModel>> BuscarPlanoPorId(int idPlano);
        Task<ResponseModel<List<PlanoSaudeModel>>> BuscarPlanoPorIdPaciente(int idPaciente);
        Task<ResponseModel<List<PlanoSaudeModel>>> CadastrarPlano(CriarPlanoSaudeDto criarPlanoSaudeDto);
        Task<ResponseModel<List<PlanoSaudeModel>>> EditarPlano(EditarPlanoSaudeDto editarPlanoSaudeDto);
        Task<ResponseModel<List<PlanoSaudeModel>>> ExcluirPlano(int idPlano);
    }
}

using WebAPIHospitalCP04.Dto.Paciente;
using WebAPIHospitalCP04.Models;

namespace WebAPIHospitalCP04.Services.Paciente
{
    public interface IPacienteInterface
    {
        Task<ResponseModel<List<PacienteModel>>> ListarPacientes();
        Task<ResponseModel<PacienteModel>> BuscarPacientePorId(int idPaciente);
        Task<ResponseModel<List<PacienteModel>>> CadastrarPaciente(CriarPacienteDto criarPacienteDto);
        Task<ResponseModel<List<PacienteModel>>> EditarPaciente(EditarPacienteDto editarPacienteDto);
        Task<ResponseModel<List<PacienteModel>>> ExcluirPaciente(int  idPaciente);
    }
}

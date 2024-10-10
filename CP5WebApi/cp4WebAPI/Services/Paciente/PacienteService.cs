using WebAPIHospitalCP04.Models;
using WebAPIHospitalCP04.Data;
using Microsoft.EntityFrameworkCore;
using WebAPIHospitalCP04.Dto.Paciente;

namespace WebAPIHospitalCP04.Services.Paciente
{
    public  class PacienteService : IPacienteInterface
    {
        private readonly AppDbContext _context;

        public PacienteService(AppDbContext context)
        {
            _context = context;
        }

       public async Task<ResponseModel<PacienteModel>> BuscarPacientePorId(int idPaciente)
       {
            ResponseModel<PacienteModel> response = new ResponseModel<PacienteModel>();
            try
            {
                var paciente = await _context.Pacientes.FirstOrDefaultAsync(cadPaciente => cadPaciente.IdPaciente == idPaciente);

                if (paciente == null)
                {
                    response.Mensagem = "Paciente não encontrado!";
                    return response;
                }

                response.Dados = paciente;
                response.Mensagem = "Paciente encontrado!";
                return response;
            }
            catch (Exception ex) 
            { 
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }

       }

       public async Task<ResponseModel<List<PacienteModel>>> CadastrarPaciente(CriarPacienteDto criarPacienteDto)
       {
            ResponseModel<List<PacienteModel>> response = new ResponseModel<List<PacienteModel>>();
            try
            {
                var paciente = new PacienteModel()
                {
                    NomeCompleto = criarPacienteDto.NomeCompleto,
                    DataNascimento = criarPacienteDto.DataNascimento,
                    CPF = criarPacienteDto.CPF,
                    Endereco = criarPacienteDto.Endereco,
                    Telefone = criarPacienteDto.Telefone
                };

                _context.Add(paciente);
                await _context.SaveChangesAsync();

                response.Dados = await _context.Pacientes.ToListAsync();
                response.Mensagem = "Paciente cadastrado!";

                return response;
            }
            catch (Exception ex) 
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
       }

       public async Task<ResponseModel<List<PacienteModel>>> EditarPaciente(EditarPacienteDto editarPacienteDto)
       {
            ResponseModel<List<PacienteModel>> response = new ResponseModel<List<PacienteModel>>();
            try
            {
                var paciente = await _context.Pacientes.FirstOrDefaultAsync(cadPaciente => cadPaciente.IdPaciente == editarPacienteDto.IdPaciente);

                if (paciente == null) 
                {
                    response.Mensagem = "Paciente não encontrado!";
                    return response;
                }

                paciente.NomeCompleto = editarPacienteDto.NomeCompleto;
                paciente.DataNascimento = editarPacienteDto.DataNascimento;
                paciente.CPF = editarPacienteDto.CPF;
                paciente.Endereco = editarPacienteDto.Endereco;
                paciente.Telefone = editarPacienteDto.Telefone;

                _context.Update(paciente);
                await _context.SaveChangesAsync();

                response.Dados = await _context.Pacientes.ToListAsync();
                response.Mensagem = "Paciente editado com sucesso!";

                return response;
            }
            catch(Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                
            }

            return response;


        }

       public async Task<ResponseModel<List<PacienteModel>>> ExcluirPaciente(int idPaciente)
       {
            ResponseModel<List<PacienteModel>> response = new ResponseModel<List<PacienteModel>>();
            try
            {
                var paciente = await _context.Pacientes.FirstOrDefaultAsync(cadPaciente => cadPaciente.IdPaciente == idPaciente);

                if (paciente == null)
                {
                    response.Mensagem = "Paciente não encontrado!";
                    return response;
                }

                _context.Remove(paciente);
                await _context.SaveChangesAsync();

                response.Dados = await _context.Pacientes.ToListAsync();
                response.Mensagem = "Paciente removido com sucesso!";
            }
            catch (Exception ex) 
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                
            }

            return response;
       }

       public async Task<ResponseModel<List<PacienteModel>>> ListarPacientes()
       {
            ResponseModel<List<PacienteModel>> response = new ResponseModel<List<PacienteModel>>();
            try
            {
                var pacientes = await _context.Pacientes.ToListAsync();

                response.Dados = pacientes;
                response.Mensagem = "Todos os pacientes foram pesquisados!";
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                
            }
            return response;
       }
    }
}

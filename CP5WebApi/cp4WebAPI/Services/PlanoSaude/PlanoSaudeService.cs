using Microsoft.EntityFrameworkCore;
using WebAPIHospitalCP04.Data;
using WebAPIHospitalCP04.Dto.PlanoSaude;
using WebAPIHospitalCP04.Models;

namespace WebAPIHospitalCP04.Services.PlanoSaude
{
    public class PlanoSaudeService : IPlanoSaudeInterface
    {
        private readonly AppDbContext _context;

        public PlanoSaudeService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<PlanoSaudeModel>> BuscarPlanoPorId(int idPlano)
        {
            ResponseModel<PlanoSaudeModel> response = new ResponseModel<PlanoSaudeModel>();
            try
            {
                var plano = await _context.PlanosDeSaude.Include(p => p.Paciente).FirstOrDefaultAsync(cadPlano => cadPlano.IdPlanoDeSaude == idPlano);

                if (plano == null)
                {
                    response.Mensagem = "Plano não encontrado";
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;

            }

            return response;
        }

        public Task<ResponseModel<List<PlanoSaudeModel>>> BuscarPlanoPorIdPaciente(int idPaciente)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<List<PlanoSaudeModel>>> CadastrarPlano(CriarPlanoSaudeDto criarPlanoSaudeDto)
        {
            ResponseModel<List<PlanoSaudeModel>> response = new ResponseModel<List<PlanoSaudeModel>>();
            try
            {

                var plano = new PlanoSaudeModel()
                {
                    NomePlano = criarPlanoSaudeDto.NomePlano,
                    CodPlano = criarPlanoSaudeDto.CodPlano,
                    Cobertura = criarPlanoSaudeDto.Cobertura
                };

                _context.Add(plano);
                await _context.SaveChangesAsync();

                response.Dados = await _context.PlanosDeSaude.ToListAsync();
                response.Mensagem = "Plano de Saúde cadastrado!";

                return response;
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
            }

            return response;

        }

        public async Task<ResponseModel<List<PlanoSaudeModel>>> EditarPlano(EditarPlanoSaudeDto editarPlanoSaudeDto)
        {
            ResponseModel<List<PlanoSaudeModel>> response = new ResponseModel<List<PlanoSaudeModel>>();
            try
            {
                var plano = await _context.PlanosDeSaude.FirstOrDefaultAsync(cadPlano => cadPlano.IdPlanoDeSaude == editarPlanoSaudeDto.IdPlanoDeSaude);

                if (plano == null)
                {
                    response.Mensagem = "Plano não encontrado";
                    return response;
                }

                plano.NomePlano = editarPlanoSaudeDto.NomePlano;
                plano.CodPlano = editarPlanoSaudeDto.CodPlano;
                plano.Cobertura = editarPlanoSaudeDto.Cobertura;

                _context.Update(plano);
                await _context.SaveChangesAsync();

                response.Dados = await _context.PlanosDeSaude.ToListAsync();
                response.Mensagem = "Plano editado com sucesso!";

                return response;

            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
            }

            return response;
        }

        public async Task<ResponseModel<List<PlanoSaudeModel>>> ExcluirPlano(int idPlano)
        {
            ResponseModel<List<PlanoSaudeModel>> response = new ResponseModel<List<PlanoSaudeModel>>();
            try
            {
                var plano = await _context.PlanosDeSaude.Include(p => p.Paciente).FirstOrDefaultAsync(cadPlano => cadPlano.IdPlanoDeSaude == idPlano);

                if (plano == null)
                {
                    response.Mensagem = "Plano não encontrado";
                    return response;
                }

                _context.Remove(plano);
                await _context.SaveChangesAsync();

                response.Dados = await _context.PlanosDeSaude.ToListAsync();
                response.Mensagem = "Plano excluído com sucesso!";
                response.Status = true;

                return response;
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<PlanoSaudeModel>>> ListarPlanos()
        {
            ResponseModel<List<PlanoSaudeModel>> response = new ResponseModel<List<PlanoSaudeModel>>();
            try
            {
                response.Dados = await _context.PlanosDeSaude.Include(p => p.Paciente).ToListAsync();
                response.Mensagem = "Lista de planos obtida com sucesso!";
                response.Status = true;
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

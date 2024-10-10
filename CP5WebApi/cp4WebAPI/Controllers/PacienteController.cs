using Microsoft.AspNetCore.Mvc;
using WebAPIHospitalCP04.Data;
using WebAPIHospitalCP04.Models;
using Microsoft.EntityFrameworkCore;
using WebAPIHospitalCP04.Services.Paciente;
using WebAPIHospitalCP04.Dto.Paciente;

namespace WebAPIHospitalCP04.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {

        private readonly IPacienteInterface _pacienteInterface;
        public PacienteController(IPacienteInterface pacienteInterface)
        {
            _pacienteInterface = pacienteInterface;
        }

        [HttpGet("ListarPacientes")]
        public async Task<ActionResult<ResponseModel<List<PacienteModel>>>> ListarPacientes()
        {
            var pacientes = await _pacienteInterface.ListarPacientes();
            return Ok(pacientes);
        }

        [HttpGet("BuscarPacientePorId/{idPaciente}")]
        public async Task<ActionResult<ResponseModel<PacienteModel>>> BuscarPacientePorId(int idPaciente)
        {
            var paciente = await _pacienteInterface.BuscarPacientePorId(idPaciente);
            return Ok(paciente);
        }

        [HttpPost("CadastrarPaciente")]
        public async Task<ActionResult<ResponseModel<List<PacienteModel>>>> CadastrarPaciente(CriarPacienteDto criarPacienteDto)
        {
            var consumidor = await _pacienteInterface.CadastrarPaciente(criarPacienteDto);
            return Ok(consumidor);
        }

        [HttpPut("EditarPaciente")]
        public async Task<ActionResult<ResponseModel<List<PacienteModel>>>> EditarPaciente(EditarPacienteDto editarPacienteDto)
        {
            var paciente = await _pacienteInterface.EditarPaciente(editarPacienteDto);
            return Ok(paciente);
        }

        [HttpDelete("ExcluirPaciente")]
        public async Task<ActionResult<ResponseModel<List<PacienteModel>>>> ExcluirPaciente(int idPaciente)
        {
            var paciente = await _pacienteInterface.ExcluirPaciente(idPaciente);
            return Ok(paciente);
        }

        //private readonly AppDbContext _context;

        //public PacienteController(AppDbContext context)
        //{
        //    _context = context;
        //}

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<PacienteModel>>> GetPaciente()
        //{
        //    return await _context.Pacientes.ToListAsync();
        //}

        //[HttpGet("{id}")]
        //public async Task<ActionResult<PacienteModel>> GetPaciente(int id)
        //{
        //    var paciente = await _context.Pacientes.FindAsync(id);

        //    if (paciente == null)
        //    {
        //        return NotFound();
        //    }

        //    return paciente;
        //}

        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutPaciente(int id, PacienteModel paciente)
        //{
        //    if (id != paciente.IdPaciente)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(paciente).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PacienteExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            return StatusCode(StatusCodes.Status500InternalServerError, "Erro de concorrência durante a atualização do paciente.");
        //        }
        //    }

        //    return NoContent();
        //}

        //[HttpPost]
        //public async Task<ActionResult<PacienteModel>> PostPaciente(PacienteModel paciente)
        //{
        //    _context.Pacientes.Add(paciente);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetPaciente", new { id = paciente.IdPaciente }, paciente);
        //}

        //[HttpDelete("{id}")]
        //public async Task<ActionResult<PacienteModel>> DeletePaciente(int id)
        //{
        //    var paciente = await _context.Pacientes.FindAsync(id);
        //    if (paciente == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Pacientes.Remove(paciente);
        //    await _context.SaveChangesAsync();

        //    return paciente;
        //}

        //[HttpGet("{id}/PlanoSaude")]
        //public async Task<ActionResult<IEnumerable<PlanoSaudeModel>>> GetPlanoSaude(int id)
        //{
        //    var paciente = await _context.Pacientes.FindAsync(id);

        //    if (paciente == null)
        //    {
        //        return NotFound();
        //    }

        //    var planosSaude = await _context.PacientePlanosSaude
        //        .Where(pps => pps.IdPaciente == id)
        //        .Select(pps => pps.PlanoSaude)
        //        .ToListAsync();

        //    return planosSaude;
        //}

        //[HttpPost("{id}/PlanoSaude/{idPlanoSaude}")]
        //public async Task<IActionResult> PostPlanoSaude(int id, int idPlanoSaude)
        //{
        //    var paciente = await _context.Pacientes.FindAsync(id);
        //    if (paciente == null)
        //    {
        //        return NotFound();
        //    }

        //    var planoSaude = await _context.PlanoDeSaude.FindAsync(idPlanoSaude);
        //    if (planoSaude == null)
        //    {
        //        return NotFound();
        //    }

        //    var exists = await _context.PacientePlanosSaude
        //        .AnyAsync(pps => pps.IdPaciente == id && pps.IdPlanoSaude == idPlanoSaude);

        //    if (exists)
        //    {
        //        return BadRequest("O plano de saúde já está associado a este paciente.");
        //    }

        //    _context.PacientePlanosSaude.Add(new PacientePlanoSaude { IdPaciente = id, IdPlanoSaude = idPlanoSaude });
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //[HttpDelete("{id}/PlanoSaude/{idPlanoSaude}")]
        //public async Task<IActionResult> DeletePlanoSaude(int id, int idPlanoSaude)
        //{
        //    var pps = await _context.PacientePlanosSaude
        //        .Where(pps => pps.IdPaciente == id && pps.IdPlanoSaude == idPlanoSaude)
        //        .FirstOrDefaultAsync();

        //    if (pps == null)
        //    {
        //        return NotFound("Associação entre paciente e plano de saúde não encontrada.");
        //    }

        //    _context.PacientePlanosSaude.Remove(pps);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool PacienteExists(int id)
        //{
        //    return _context.Pacientes.Any(e => e.IdPaciente == id);
        //}
    }
}

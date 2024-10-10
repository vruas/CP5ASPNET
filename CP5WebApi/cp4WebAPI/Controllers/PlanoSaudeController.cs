using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIHospitalCP04.Data;
using WebAPIHospitalCP04.Models;
using WebAPIHospitalCP04.Dto.PlanoSaude;
using WebAPIHospitalCP04.Services.PlanoSaude;

namespace WebAPIHospitalCP04.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PlanoSaudeController : Controller
    {
        private readonly IPlanoSaudeInterface _planoSauseInterface;

        public PlanoSaudeController(IPlanoSaudeInterface planoSauseInterface)
        {
            _planoSauseInterface = planoSauseInterface;
        }

        [HttpGet("ListarPllanos")]
        public async Task<ActionResult<ResponseModel<List<PlanoSaudeModel>>>> ListarPlanos()
        {
            var planos = await _planoSauseInterface.ListarPlanos();
            return Ok(planos);
        }

        [HttpGet("BuscarPlanoPorId/{idPlano}")]
        public async Task<ActionResult<ResponseModel<PlanoSaudeModel>>> BuscarPlanoPorId(int idPlano)
        {
            var plano = await _planoSauseInterface.BuscarPlanoPorId(idPlano);
            return Ok(plano);
        }

        [HttpPost("CadastrarPlano")]
        public async Task<ActionResult<ResponseModel<List<PlanoSaudeModel>>>> CadastrarPlano(CriarPlanoSaudeDto criarPlanoSaudeDto)
        {
            var plano = await _planoSauseInterface.CadastrarPlano(criarPlanoSaudeDto);
            return Ok(plano);
        }

        [HttpPut("EditarPlano")]
        public async Task<ActionResult<ResponseModel<PlanoSaudeModel>>> EditarPlano(EditarPlanoSaudeDto editarPlanoSaudeDto)
        {
            var plano = await _planoSauseInterface.EditarPlano(editarPlanoSaudeDto);
            return Ok(plano);
        }

        [HttpDelete("ExcluirPlano/{idPlano}")]
        public async Task<ActionResult<ResponseModel<List<PlanoSaudeModel>>>> ExcluirPlano(int idPlano)
        {
            var plano = await _planoSauseInterface.ExcluirPlano(idPlano);
            return Ok(plano);
        }

        //private readonly AppDbContext _context;

        //public PlanoSaudeController(AppDbContext context)
        //{
        //    _context = context;
        //}

        //// GET: api/PlanoDeSaude
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<PlanoSaudeModel>>> GetPlanoDeSaude()
        //{
        //    return await _context.PlanoDeSaude.ToListAsync();
        //}

        //// GET: api/PlanoDeSaude/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<PlanoSaudeModel>> GetPlanoDeSaude(int id)
        //{
        //    var planoDeSaude = await _context.PlanoDeSaude.FindAsync(id);

        //    if (planoDeSaude == null)
        //    {
        //        return NotFound();
        //    }

        //    return planoDeSaude;
        //}

        //// PUT: api/PlanoDeSaude/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutPlanoDeSaude(int id, PlanoSaudeModel planoDeSaude)
        //{
        //    if (id != planoDeSaude.IdPlanoDeSaude)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(planoDeSaude).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PlanoDeSaudeExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/PlanoDeSaude
        //[HttpPost]
        //public async Task<ActionResult<PlanoSaudeModel>> PostPlanoDeSaude(PlanoSaudeModel planoDeSaude)
        //{
        //    _context.PlanoDeSaude.Add(planoDeSaude);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetPlanoDeSaude", new { id = planoDeSaude.IdPlanoDeSaude }, planoDeSaude);
        //}

        //// DELETE: api/PlanoDeSaude/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<PlanoSaudeModel>> DeletePlanoDeSaude(int id)
        //{
        //    var planoDeSaude = await _context.PlanoDeSaude.FindAsync(id);
        //    if (planoDeSaude == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.PlanoDeSaude.Remove(planoDeSaude);
        //    await _context.SaveChangesAsync();

        //    return planoDeSaude;
        //}

        ////GET: api/PlanoDeSaude/5/Paciente
        //[HttpGet("{id}/Paciente")]

        //public async Task<ActionResult<IEnumerable<PacientePlanoSaude>>> GetPacientePlanoSaude(int id)
        //{
        //    var pacientePlanoSaude = await _context.PacientePlanosSaude.Where(p => p.IdPlanoSaude == id).ToListAsync();

        //    if (pacientePlanoSaude == null)
        //    {
        //        return NotFound();
        //    }

        //    return pacientePlanoSaude;
        //}

        //private bool PlanoDeSaudeExists(int id)
        //{
        //    return _context.PlanoDeSaude.Any(e => e.IdPlanoDeSaude == id);
        //}
    }
}

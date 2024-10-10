using WebAPIHospitalCP04.Dto.PacientePlano;
using WebAPIHospitalCP04.Models;

namespace WebAPIHospitalCP04.Dto.PlanoSaude
{
    public class CriarPlanoSaudeDto
    {
        public string NomePlano { get; set; }
        public string CodPlano { get; set; }
        public string Cobertura { get; set; }

        public PacientePlanoDto Paciente { get; set; }
    }
}

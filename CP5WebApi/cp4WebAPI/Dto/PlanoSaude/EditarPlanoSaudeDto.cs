using WebAPIHospitalCP04.Dto.PacientePlano;

namespace WebAPIHospitalCP04.Dto.PlanoSaude
{
    public class EditarPlanoSaudeDto
    {
        public int IdPlanoDeSaude { get; set; }
        public string NomePlano { get; set; }
        public string CodPlano { get; set; }
        public string Cobertura { get; set; }

        public PacientePlanoDto Paciente { get; set; }
    }
}

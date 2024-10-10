using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIHospitalCP04.Models
{
    [Table("PLANO_DE_SAUDE")]
    public class PlanoSaudeModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPlanoDeSaude { get; set; }
        public string NomePlano { get; set; }
        public string CodPlano { get; set; }
        public string Cobertura { get; set; }

        public PacienteModel Paciente { get; set; }
         
    }
}

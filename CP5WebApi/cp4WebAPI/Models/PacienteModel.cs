using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebAPIHospitalCP04.Models
{
    [Table("PACIENTE")]
    public class PacienteModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPaciente { get; set; }
        public string NomeCompleto { get; set; }
        public string DataNascimento { get; set; }
        public string CPF { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }

        [JsonIgnore]
        public ICollection<PlanoSaudeModel> PlanosSaude { get; set; }


        //public List<PacientePlanoSaude> PacientePlanosSaude {  get; set; }
    }
}

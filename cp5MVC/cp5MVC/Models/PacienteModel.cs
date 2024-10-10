namespace cp5MVC.Models
{
    public class PacienteModel
    {
        public int IdPaciente { get; set; }
        public string NomeCompleto { get; set; }
        public string DataNascimento { get; set; }
        public string CPF { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
    }
}

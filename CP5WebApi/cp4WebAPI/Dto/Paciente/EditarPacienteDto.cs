﻿namespace WebAPIHospitalCP04.Dto.Paciente
{
    public class EditarPacienteDto
    {
        public int IdPaciente { get; set; }
        public string NomeCompleto { get; set; }
        public string DataNascimento { get; set; }
        public string CPF { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
    }
}

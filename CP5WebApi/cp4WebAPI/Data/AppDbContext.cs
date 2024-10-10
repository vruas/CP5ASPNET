using Microsoft.EntityFrameworkCore;
using WebAPIHospitalCP04.Models;
using WebAPIHospitalCP04.Data;

namespace WebAPIHospitalCP04.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<PacienteModel> Pacientes { get; set; }

        public DbSet<PlanoSaudeModel> PlanosDeSaude { get; set; }

       
       

        

     
        
    }

    
    
}

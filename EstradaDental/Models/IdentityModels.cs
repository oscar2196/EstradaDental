using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System;

namespace EstradaDental.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() { }

        public ApplicationUser(RegisterViewModel persona)
        {
            this.nombre = persona.nombre;
            this.apellidoP = persona.apellidoP;
            this.apellidoM = persona.apellidoM;
            this.direccion = persona.direccion;
            this.fechaNac = persona.fechaNac;
            this.PhoneNumber = persona.PhoneNumber;
            this.Email = persona.Email;
            this.UserName = persona.Email;
            
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
       
        public string nombre { get; set; }
        public string apellidoP { get; set; }
        public string apellidoM { get; set; }
        public string direccion { get; set; }
        public DateTime fechaNac { get; set; }

        

    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        
        public DbSet<Cita> cita { get; set; }
        //public DbSet<Doctor> doctor { get; set; }
        public DbSet<Historial> historial { get; set; }
        public DbSet<HistorialClinico> historialclinico { get; set; }
        public DbSet<Archivo> archivo { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {

        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();

        
        }

        //public System.Data.Entity.DbSet<EstradaDental.Models.Cliente> ApplicationUsers { get; set; }

        //public System.Data.Entity.DbSet<EstradaDental.Models.ApplicationUser> ApplicationUsers { get; set; }

        // public System.Data.Entity.DbSet<EstradaDental.Models.ApplicationUser> ApplicationUsers { get; set; }
    }
}
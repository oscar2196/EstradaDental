using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace EstradaDental.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
       
        public string nombre { get; set; }
        public string apellidoP { get; set; }
        public string direccion { get; set; }
       
        //Un cliente tiene muchas Citas
        virtual public ICollection<Cita> cita { get; set; }

        //Un cliente tiene muchos historiales
        virtual public ICollection<Historial> historiales { get; set; }
        virtual public ICollection<HistorialClinico> historialClinico { get; set; }
        virtual public ICollection<Archivo> archivos { get; set; }

    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        
        public DbSet<Cita> cita { get; set; }
        public DbSet<Doctor> doctor { get; set; }
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

       // public System.Data.Entity.DbSet<EstradaDental.Models.ApplicationUser> ApplicationUsers { get; set; }
    }
}
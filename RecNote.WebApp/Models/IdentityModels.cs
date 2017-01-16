using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace RecNote.WebApp.Models
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
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<Recnote.WebApp.Models.Contact> Contacts { get; set; }

        public System.Data.Entity.DbSet<RecNote.WebApp.Models.Service> Services { get; set; }

       public System.Data.Entity.DbSet<RecNote.WebApp.Models.ServiceType> ServiceTypes { get; set; }

       public System.Data.Entity.DbSet<RecNote.WebApp.Models.Maintenance> Maintenances { get; set; }

       public System.Data.Entity.DbSet<RecNote.WebApp.Models.MaintenanceType> MaintenanceTypes { get; set; }

       public System.Data.Entity.DbSet<RecNote.WebApp.Models.Insurance> Insurances { get; set; }

       public System.Data.Entity.DbSet<RecNote.WebApp.Models.InsuranceType> InsuranceTypes { get; set; }

       public System.Data.Entity.DbSet<RecNote.WebApp.Models.IndexListView> IndexListViews { get; set; }

       //public System.Data.Entity.DbSet<RecNote.WebApp.Models.ServiceViewModel> ServiceViewModels { get; set; }
    }
}
namespace RecNote.WebApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Recnote.WebApp.Models;
    using RecNote.WebApp.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<RecNote.WebApp.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        string AddUserAndRole(RecNote.WebApp.Models.ApplicationDbContext context)
        {
            string userID = "failed";
            IdentityResult ir;
            var rm = new RoleManager<IdentityRole>
                (new RoleStore<IdentityRole>(context));
            ir = rm.Create(new IdentityRole("canEdit"));
            var um = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));
            var user = new ApplicationUser()
            {
                UserName = "user1@contoso.com",
            };
            ir = um.Create(user, "P_assw0rd1");
            if (ir.Succeeded == false)
                return userID;
            userID = user.Id;
            ir = um.AddToRole(user.Id, "canEdit");
            return userID;
        }

        protected override void Seed(RecNote.WebApp.Models.ApplicationDbContext context)
        {

          string userID =   AddUserAndRole(context);

        if(context.Contacts.Count() > 0)
        {
            return;
        }
            
       context.Contacts.AddOrUpdate(p => p.Name,
       new Contact
       {
           Name = "Pankaj Bhakta",
           Address = "248/2 St. George Street",
           Suburb = "Papatoetoe",
           City = "Auckland",           
           PostCode = "2025",
           Email = "bhakta@xtra.co.nz",
           Phone = "09-2504485",
           Mobile = "0212481893",
       },
        new Contact
        {
            Name = "Pradip Chakraborty",
            Address = "47/5 Wallace Road",
            Suburb = "Papatoetoe",
            City = "Auckland",
            PostCode = "2025",
            Email = "pradipc@vodafone.co.nz",
            Phone = "09-2504985",
            Mobile = "0212947829",
        },
        new Contact
        {
            Name = "Vijayendra Bose",
            Address = "47 Milan Road",
            Suburb = "Papatoetoe",
            City = "Auckland",
            PostCode = "2025",
            Email = "viju.bose@gmail.com",
            Phone = "09-2504485",
            Mobile = "0212481893",
        },
        new Contact
        {
            Name = "Amit Sengupta",
            Address = "61 Puhinui Road",
            Suburb = "Papatoetoe",
            City = "Auckland",
            PostCode = "2025",
            Email = "None",
            Phone = "09-2797167",
            Mobile = "None",
        },
        new Contact
        {
            Name = "Sujoy Biswas",
            Address = "2/5 Laburnum Road",
            Suburb = "New Windsor",
            City = "Auckland",
            PostCode = "0600",
            Email = "bis_amrita@yahoo.co.nz",
            Phone = "09-6260921",
            Mobile = "0210365731",
        }
        );
        }
    }
 }
    


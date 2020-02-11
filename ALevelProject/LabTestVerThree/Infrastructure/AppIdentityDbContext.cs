using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using LabTestVerThree.Models;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;

namespace LabTestVerThree.Infrastructure
{
    public class AppIdentityDbContext : IdentityDbContext<AppUser>
    {
        public AppIdentityDbContext() : base("name=IdentityDb") { }

        public DbSet<EventsDetails> EventDetails { get; set; }

        static AppIdentityDbContext()
        {
            Database.SetInitializer<AppIdentityDbContext>(new IdentityDbInit());
        }

        public static AppIdentityDbContext Create()
        {
            return new AppIdentityDbContext();
        }
    }

    public class IdentityDbInit : DropCreateDatabaseIfModelChanges<AppIdentityDbContext>
    {
        protected override void Seed(AppIdentityDbContext context)
        {
            PerformInitialSetup(context);
            base.Seed(context);
        }
        public void PerformInitialSetup(AppIdentityDbContext context)
        {
            AppUserManager userMgr = new AppUserManager(new UserStore<AppUser>(context));
            AppRoleManager roleMgr = new AppRoleManager(new RoleStore<AppRole>(context));

            List<string> roleNames = new List<string> { "admins", "managers", "laborants" };
            List<string> userNames = new List<string> { "admin", "manager", "laborant" };
            List<string> userEmails = new List<string> { "admin@gmail.com", "manager@gmail.com", "laborant@gmail.com" };
            List<string> passwords = new List<string> { "admins", "manager", "laborant" };

            foreach (var role in roleNames)
            {
                if (!roleMgr.RoleExists(role))
                {
                    roleMgr.Create(new AppRole(role));
                }
            }

            for (int i = 0; i < userNames.Count; i++)
            {
                AppUser userItem = userMgr.FindByName(userNames[i]);
                if (userItem == null)
                {
                    userMgr.Create(new AppUser { UserName = userNames[i], Email = userEmails[i] },
                        passwords[i]);
                    userItem = userMgr.FindByName(userNames[i]);
                }

                if (!userMgr.IsInRole(userItem.Id, roleNames[i]))
                {
                    userMgr.AddToRole(userItem.Id, roleNames[i]);
                }
            }
        }
    }
}
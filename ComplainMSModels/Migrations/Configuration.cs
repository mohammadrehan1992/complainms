namespace ComplainMSModels.Migrations
{
    using ComplainMSCommon;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ComplainDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ComplainDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            context.Logins.Add(new Login { Email = "admin@gmail.com", Password = SecurityLayer.GetMd5Hash("test").ToUpper(), IsActive = true, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now });
        }
    }
}

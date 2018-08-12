namespace DatPQShop.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Model.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DatPQShop.Data.DatPQShopDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DatPQShop.Data.DatPQShopDbContext context)
        {
            CreateProductCategorySample(context);
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            //var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new DatPQShopDbContext()));

            //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new DatPQShopDbContext()));

            //var user = new ApplicationUser()
            //{
            //    UserName = "tedu",
            //    Email = "tedu.international@gmail.com",
            //    EmailConfirmed = true,
            //    BirthDay = DateTime.Now,
            //    FullName = "Technology Education"

            //};

            //manager.Create(user, "123654$");

            //if (!roleManager.Roles.Any())
            //{
            //    roleManager.Create(new IdentityRole { Name = "Admin" });
            //    roleManager.Create(new IdentityRole { Name = "User" });
            //}

            //var adminUser = manager.FindByEmail("tedu.international@gmail.com");

            //manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });
        }

        private void CreateProductCategorySample(DatPQShop.Data.DatPQShopDbContext context)
        {
            if (context.ProductCategories.Count() == 0)
            {
                List<ProductCategory> listProductCategory = new List<ProductCategory>()
            {
                new ProductCategory() {Name = "Điện lạnh",Alias="dien-lanh",Status=true },
                new ProductCategory() {Name = "Viễn thong",Alias="vien-thong",Status=true },
                new ProductCategory() {Name = "Đồ gia dụng",Alias="dien-lanh",Status=true },
                new ProductCategory() {Name = "Mỹ Phẩm",Alias="dien-lanh",Status=true }
            };
                context.ProductCategories.AddRange(listProductCategory);
                context.SaveChanges();
            }


        }
    }
}

namespace DatPQShop.Data.Migrations
{
    using Common;
    using Data;
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
            //CreateProductCategorySample(context);
            CreateSlide(context);

        }
        private void CreateUser(DatPQShopDbContext context)
        {
            //This method will be called after migrating to the latest version.

            //You can use the DbSet<T>.AddOrUpdate() helper extension method
            //to avoid creating duplicate seed data.
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new DatPQShopDbContext()));

            var rolemanager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new DatPQShopDbContext()));

            var user = new ApplicationUser()
            {
                UserName = "tedu",
                Email = "tedu.international@gmail.com",
                EmailConfirmed = true,
                BirthDay = DateTime.Now,
                FullName = "technology education"

            };

            manager.Create(user, "123654$");

            if (!rolemanager.Roles.Any())
            {
                rolemanager.Create(new IdentityRole { Name = "admin" });
                rolemanager.Create(new IdentityRole { Name = "user" });
            }

            var adminuser = manager.FindByEmail("tedu.international@gmail.com");

            manager.AddToRoles(adminuser.Id, new string[] { "admin", "user" });
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
        private void Footer(DatPQShopDbContext context)
        {
            if (context.Footers.Count(x => x.ID == CommonConstants.DefaultFooterID) == 0)
            {
                string content = "";
            }
        }
        private void CreateSlide(DatPQShopDbContext context)
        {
            if (context.Slides.Count() == 0)
            {
                List<Slide> listSlide = new List<Slide>()
                {
                    new Slide() {Name="slide1",DisplayOrder=1,Status=true,Url="#",Image="~/Assets/client/images/bag.jpg",Content=@"<h2>FLAT 50% 0FF</h2>
                                <label>FOR ALL PURCHASE <b>VALUE</b></label>
                                <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et </p>
                                <span class=""on-get"">GET NOW</span>" },
                    new Slide() {Name="slide2",DisplayOrder=2,Status=true,Url="#",Image="~/Assets/client/images/bag1.jpg",Content=@"<h2>FLAT 50% 0FF</h2>
                                <label>FOR ALL PURCHASE <b>VALUE</b></label>
                                <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et </p>
                                <span class=""on-get"">GET NOW</span>" }
                };
                context.Slides.AddRange(listSlide);
                context.SaveChanges();


            }
        }
    }
}

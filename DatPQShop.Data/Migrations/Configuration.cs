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
    using System.Data.Entity.Validation;
    using System.Diagnostics;
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
            CreateContactDetail(context);
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
        private void CreatePage(DatPQShopDbContext context)
        {
            if (context.Pages.Count() == 0)
            {
                try
                {
                    var page = new Page()
                    {
                        Name = "Giới thiệu",
                        Alias = "gioi-thieu",
                        Content = @"Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium ",
                        Status = true

                    };
                    context.Pages.Add(page);
                    context.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var eve in ex.EntityValidationErrors)
                    {
                        Trace.WriteLine($"Entity of type \"{eve.Entry.Entity.GetType().Name}\" in state \"{eve.Entry.State}\" has the following validation error.");
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Trace.WriteLine($"- Property: \"{ve.PropertyName}\", Error: \"{ve.ErrorMessage}\"");
                        }
                    }
                }

            }
        }
        private void CreateContactDetail(DatPQShopDbContext context)
        {
            if (context.ContactDetails.Count() == 0)
            {
                try
                {
                    var contactDetail = new DatPQShop.Model.Models.ContactDetail()
                    {
                        Name="Shop thời trang DatPQ",
                        Address="Số 2 Âu Cơ",
                        Email="phandat07011997@gmail.com",
                        Lat= 21.061757,
                        Lng= 105.834930,
                        Phone="01696934750",
                        Website="fb.com/phandat97",
                        Other="",
                        Status=true

                    };
                    context.ContactDetails.Add(contactDetail);
                    context.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var eve in ex.EntityValidationErrors)
                    {
                        Trace.WriteLine($"Entity of type \"{eve.Entry.Entity.GetType().Name}\" in state \"{eve.Entry.State}\" has the following validation error.");
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Trace.WriteLine($"- Property: \"{ve.PropertyName}\", Error: \"{ve.ErrorMessage}\"");
                        }
                    }
                }

            }
        }
    }
}

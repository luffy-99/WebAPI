namespace WebShop.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebShop.Model.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebShop.Data.WebShopDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebShop.Data.WebShopDbContext context)
        {
            AddProduct(context);
            //var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new WebShopDbContext()));

            //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new WebShopDbContext()));

            //var user = new ApplicationUser()
            //{
            //    UserName = "admin",
            //    Email = "tedu@gmail.com",
            //    EmailConfirmed = true,
            //    BirthDay = DateTime.Now,
            //    FullName = "Technology Education"

            //};

            //manager.Create(user, "123456");

            //if (!roleManager.Roles.Any())
            //{
            //    roleManager.Create(new IdentityRole { Name = "Admin" });
            //    roleManager.Create(new IdentityRole { Name = "User" });
            //}

            //var adminUser = manager.FindByEmail("tedu@gmail.com");

            //manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });
        }
        private void CreateProductCategorySample(WebShop.Data.WebShopDbContext context)
        {
            if (context.ProductCategories.Count() == 0)
            {
                List<ProductCategory> listProductCategory = new List<ProductCategory>()
            {
                new ProductCategory() { Name="Điện lạnh",Alias="dien-lanh",Status=true },
                 new ProductCategory() { Name="Viễn thông",Alias="vien-thong",Status=true },
                  new ProductCategory() { Name="Đồ gia dụng",Alias="do-gia-dung",Status=true },
                   new ProductCategory() { Name="Mỹ phẩm",Alias="my-pham",Status=true }
            };
                context.ProductCategories.AddRange(listProductCategory);
                context.SaveChanges();
            }

        }

        public void AddProduct(WebShop.Data.WebShopDbContext context)
        {
            List<Product> products = new List<Product>()
            {
                new Product()
                {
                    Name = "Lorem ipsum dolor",
                    Image = "/Assets/client/images/ch.jpg",
                    Price = 300
                },
                new Product()
                {
                    Name = "Lorem ipsum dolor",
                    Image = "/Assets/client/images/ba.jpg",
                    Price = 300
                },
                new Product()
                {
                    Name = "Lorem ipsum dolor",
                    Image = "/Assets/client/images/bo.jpg",
                    Price = 300
                }
            };
            context.Products.AddRange(products);
            context.SaveChanges();
        }

        private void AddSlide(WebShop.Data.WebShopDbContext context)
        {
            List<Slide> listSlide = new List<Slide>()
            {
                new Slide(){
                    Name = "Slide 1",
                    DisplayOrder = 1,
                    Status = true,
                    URL = "#",
                    Image = "/Assets/client/images/bag1.jpg",
                    Content = @"<h2>FLAT 50% 0FF</h2>
								<label>FOR ALL PURCHASE <b>VALUE</b></label>
								<p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et </p>					
								<span class=""on-get"">GET NOW</span>"
                },
                new Slide()
                {
                    Name = "Slide 2",
                    DisplayOrder = 1,
                    Status = true,
                    URL = "#",
                    Image = "Assets/client/images/bag2.jpg",
                    Content = @"<h2>FLAT 50% 0FF</h2>
								<label>FOR ALL PURCHASE <b>VALUE</b></label>
								<p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et </p>					
								<span class=""on-get"">GET NOW</span>"
                }
            };
            context.Slides.AddRange(listSlide);
            context.SaveChanges();
        }
    }

}

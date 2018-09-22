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
            AddContactDetail(context);
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
        private void AddPage(WebShopDbContext context)
        {
            if (context.Pages.Count() == 0)
            {
                var page = new Page()
                {
                    
                    Name = "Gioi thieu",
                    Alias = "gioi-thieu",
                    Content = @"Thank you very much for your letter which arrived a few days ago. It was lovely to hear from you. 
                                I am sorry, I haven’t written for you such along time because I studied hard to pass the final exam. However, I had agreat weekend more than every when I went to live concerts last night with my friends.
                                Now, I am writing to tell you how the wonderful concert is.
                                It is the beautiful concert I have ever taken part in with many people and the miracle of sound of piano.
                                As you know,my pianist is Yiruma and in last concert I couldn’t believe that he appeared in my eyes and gave me a big hug after his performance.I also listen a soothing music which is played by him and other professional musicians.Only when I heard his song from the stage I feel anythings 
                                around me seem to disappear and I can fly with many stars on the sky to forget all my fears which I suffered before. That is amazing.",
                    Status = true
                    
                };
                context.Pages.Add(page);
                context.SaveChanges();
            }
        }
        private void AddContactDetail(WebShopDbContext context)
        {
            if (context.ContactDetails.Count() == 0)
            {
                var contactDetail = new ContactDetail()
                {
                    Name = " Shop thoi trang",
                    Address = "Ngo 389 Hoang Quoc Viet",
                    Email = "huy@gmail.com",
                    Lat = 134.2234355,
                    Lng = 32.13243544,
                    Phone = "0335456576",
                    Website = "http://webshop.com.vn",
                    Other = "",
                    Status = true
                };
                context.ContactDetails.Add(contactDetail);
                context.SaveChanges();
            }
        }
    }

}

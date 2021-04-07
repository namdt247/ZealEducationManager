namespace Zeal_Institute.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Zeal_Institute.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Zeal_Institute.Models.ApplicationDbContext>
    {
        UserManager<ApplicationUser> UserManager = null;
        RoleManager<IdentityRole> RoleManager = null;
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Zeal_Institute.Models.ApplicationDbContext context)
        {
            context.Database.ExecuteSqlCommand("DELETE FROM Batches");
            context.Database.ExecuteSqlCommand("DELETE FROM Certificates");
            context.Database.ExecuteSqlCommand("DELETE FROM Courses");
            context.Database.ExecuteSqlCommand("DELETE FROM Discounts");
            context.Database.ExecuteSqlCommand("DELETE FROM Exams");
            context.Database.ExecuteSqlCommand("DELETE FROM Feedbacks");
            context.Database.ExecuteSqlCommand("DELETE FROM Payments");
            context.Database.ExecuteSqlCommand("DELETE FROM Reminders");
            context.Database.ExecuteSqlCommand("DELETE FROM ExamDetails");

            context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('Batches', RESEED, 0)");
            context.Database.ExecuteSqlCommand(" DBCC CHECKIDENT('Certificates', RESEED, 0)");
            context.Database.ExecuteSqlCommand(" DBCC CHECKIDENT('Courses', RESEED, 0)");
            context.Database.ExecuteSqlCommand(" DBCC CHECKIDENT('Discounts', RESEED, 0)");
            context.Database.ExecuteSqlCommand(" DBCC CHECKIDENT('Exams', RESEED, 0)");
            context.Database.ExecuteSqlCommand(" DBCC CHECKIDENT('Feedbacks', RESEED, 0)");
            context.Database.ExecuteSqlCommand(" DBCC CHECKIDENT('Payments', RESEED, 0)");
            context.Database.ExecuteSqlCommand(" DBCC CHECKIDENT('Reminders', RESEED, 0)");

            if (RoleManager == null)
            {
                RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            }

            if (UserManager == null)
            {
                UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            }

            var role1 = new IdentityRole { Name = "Admin" };
            var role2 = new IdentityRole { Name = "Manager" };
            var role3 = new IdentityRole { Name = "Faculty" };
            var role4 = new IdentityRole { Name = "Student" };
            RoleManager.Create(role1);
            RoleManager.Create(role2);
            RoleManager.Create(role3);
            RoleManager.Create(role4);

            // create user
            var passwordHash = new PasswordHasher();
            string password = passwordHash.HashPassword("123456");

            // date now
            DateTime date = DateTime.Now;

            context.Users.AddOrUpdate(new ApplicationUser() { Id = "1", FullName = "Admin", Email = "admin@gmail.com", UserName = "Admin", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Admin", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0987654321", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "Admin", CreatedAt = DateTime.Now });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "2", FullName = "Hong Hanh", Email = "honghanh@gmail.com", UserName = "Hong Hanh", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Giao Vu", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0966123123", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "2", RollNumber = "MSG1", CreatedAt = DateTime.Now });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "3", FullName = "Dao Hong Luyen", Email = "hongluyenh@gmail.com", UserName = "Dao Hong Luyen", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Giao Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0958567567", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "GV1", CreatedAt = DateTime.Now });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "4", FullName = "La Phuong", Email = "laphuong@gmail.com", UserName = "La Phuong", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0983454545", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00631", CreatedAt = DateTime.Now });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "5", FullName = "Van Hien", Email = "vanhien@gmail.com", UserName = "Van Hien", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0962336611", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00632", CreatedAt = DateTime.Now });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "6", FullName = "Dinh Nam", Email = "dinhnam@gmail.com", UserName = "Dinh Nam", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0988712312", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00633", CreatedAt = DateTime.Now });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "7", FullName = "Van Quy", Email = "vanquy@gmail.com", UserName = "Van Quy", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0881231230", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00634", CreatedAt = DateTime.Now });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "8", FullName = "Duc Tung", Email = "ductung@gmail.com", UserName = "Duc Tung", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0234123987", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00635", CreatedAt = DateTime.Now });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "9", FullName = "Huy Cuong", Email = "huycuong@gmail.com", UserName = "Huy Cuong", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0123567345", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00636", CreatedAt = DateTime.Now });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "10", FullName = "Van Loi", Email = "vanloi@gmail.com", UserName = "Van Loi", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0912381234", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00637", CreatedAt = DateTime.Now });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "11", FullName = "Le Vinh", Email = "levinh@gmail.com", UserName = "Le Vinh", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0912309876", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00638", CreatedAt = DateTime.Now });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "12", FullName = "Duy Phuong", Email = "duyphuong@gmail.com", UserName = "Duy Phuong", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0912312394", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00639", CreatedAt = DateTime.Now });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "13", FullName = "Kim Nghi", Email = "kimnghi@gmail.com", UserName = "Kim Nghi", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0988199612", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00640", CreatedAt = DateTime.Now });
            
            
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "14", FullName = "La Thanh", Email = "lathanh@gmail.com", UserName = "La Thanh", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0988199613", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00641", CreatedAt = date.AddDays(-30) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "15", FullName = "Xuan Phong", Email = "xuanphong@gmail.com", UserName = "Xuan Phong", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0988199614", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00642", CreatedAt = date.AddDays(-30) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "16", FullName = "Ho Tuan Tai", Email = "hotuantai@gmail.com", UserName = "Ho Tuan Tai 01", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0988199615", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00643", CreatedAt = date.AddDays(-30) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "17", FullName = "Dinh Thanh", Email = "dinhthanh@gmail.com", UserName = "Dinh Thanh", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0988199616", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00644", CreatedAt = date.AddDays(-30) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "18", FullName = "Xuan Hung", Email = "xuanhung@gmail.com", UserName = "Xuan Hung", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0988199617", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00645", CreatedAt = date.AddDays(-30) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "19", FullName = "Dinh Van Bac", Email = "dinhvietbac@gmail.com", UserName = "Dinh Van Bac", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0988199618", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00646", CreatedAt = date.AddDays(-30) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "20", FullName = "Do Duy Nam", Email = "doduynam@gmail.com", UserName = "Do Duy Nam", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0988199619", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00647", CreatedAt = date.AddDays(-30) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "21", FullName = "Truong Thanh", Email = "truongthanh@gmail.com", UserName = "Truong Thanh", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0988199620", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00648", CreatedAt = date.AddDays(-30) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "22", FullName = "Nguyen Khoi My", Email = "nguyenkhoimy@gmail.com", UserName = "Nguyen Khoi My", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0988199621", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00649", CreatedAt = date.AddDays(-30) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "23", FullName = "Chi Thien", Email = "chithien@gmail.com", UserName = "Chi Thien", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0988199622", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00649", CreatedAt = date.AddDays(-30) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "24", FullName = "Doan Van Lan", Email = "doanvanlan@gmail.com", UserName = "Doan Van Lan", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0988199623", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00649", CreatedAt = date.AddDays(-30) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "25", FullName = "Kim Dung", Email = "kimdung@gmail.com", UserName = "Kim Dung", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0988199624", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00649", CreatedAt = date.AddDays(-30) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "26", FullName = "Ngo Thi My", Email = "ngothimy@gmail.com", UserName = "Ngo Thi My", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0988199625", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00649", CreatedAt = date.AddDays(-30) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "27", FullName = "My Hao", Email = "myhao@gmail.com", UserName = "My Hao", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0988199626", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00649", CreatedAt = date.AddDays(-30) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "28", FullName = "Xuan Thanh", Email = "xuanthanh@gmail.com", UserName = "Xuan Thanh", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0988199627", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00649", CreatedAt = date.AddDays(-30) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "29", FullName = "Trieu Son", Email = "trieuson@gmail.com", UserName = "Trieu Son", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0988199628", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00649", CreatedAt = date.AddDays(-30) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "30", FullName = "La Thang", Email = "lathanh@gmail.com", UserName = "La Thang", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0988199629", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00649", CreatedAt = date.AddDays(-30) });



            context.Users.AddOrUpdate(new ApplicationUser() { Id = "31", FullName = "Do Duy Nam", Email = "doduynam@gmail.com", UserName = "Do Duy Nam 01", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0988199630", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00650", CreatedAt = date.AddDays(-29) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "32", FullName = "Van Khoi", Email = "vankhoi@gmail.com", UserName = "Van Khoi", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0988199631", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00651", CreatedAt = date.AddDays(-29) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "33", FullName = "Phung Kien Cuong", Email = "phungkiencuong@gmail.com", UserName = "Phung Kien Cuong", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0988199632", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00652", CreatedAt = date.AddDays(-29) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "34", FullName = "Doi Moi", Email = "doimoi@gmail.com", UserName = "Doi Moi", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0988199700", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00653", CreatedAt = date.AddDays(-29) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "35", FullName = "Lai Thi Thao", Email = "laithithao@gmail.com", UserName = "Lai Thi Thao", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0988199800", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00654", CreatedAt = date.AddDays(-29) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "36", FullName = "Le Van Loi", Email = "levanloi@gmail.com", UserName = "Le Van Loi", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0988199900", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00655", CreatedAt = date.AddDays(-29) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "37", FullName = "Le Vinh", Email = "levinh@gmail.com", UserName = "Le Vinh 01", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0988200200", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00656", CreatedAt = date.AddDays(-29) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "38", FullName = "Le Vinh Xo", Email = "levinhxo@gmail.com", UserName = "Le Vinh Xo", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0988199123", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00657", CreatedAt = date.AddDays(-29) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "39", FullName = "Lai Thi Thao", Email = "laithithao@gmail.com", UserName = "Lai Thi Thao 01", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0988199124", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00658", CreatedAt = date.AddDays(-27) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "40", FullName = "Hoang Thi Thao", Email = "hoangthithao@gmail.com", UserName = "Hoang Thi Thao", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0988199125", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00659", CreatedAt = date.AddDays(-27) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "41", FullName = "Dinh Nam", Email = "dinhnam@gmail.com", UserName = "Dinh Nam 01", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0988199701", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00660", CreatedAt = date.AddDays(-27) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "42", FullName = "Nam Dinh", Email = "namdinh@gmail.com", UserName = "Nam Dinh 01", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0988199711", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00661", CreatedAt = date.AddDays(-27) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "43", FullName = "Nguyen Van Hien", Email = "nguyenvanhien@gmail.com", UserName = "Dinh Nam 02", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0988199712", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00662", CreatedAt = date.AddDays(-25) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "44", FullName = "Van Hien", Email = "vanhien@gmail.com", UserName = "Van Hien 01", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0988199716", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00663", CreatedAt = date.AddDays(-25) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "45", FullName = "Nguyen Hien", Email = "nguyenhien@gmail.com", UserName = "Nguyen Hien 01", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0988199718", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00664", CreatedAt = date.AddDays(-22) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "46", FullName = "Hoang Thi Thao", Email = "hoangthithao@gmail.com", UserName = "Hoang Thi Thao 01", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0988199731", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00665", CreatedAt = date.AddDays(-22) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "47", FullName = "Linh Vu", Email = "linhvu@gmail.com", UserName = "Linh Vu", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0988199734", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00666", CreatedAt = date.AddDays(-22) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "48", FullName = "Vu Linh", Email = "vulinh@gmail.com", UserName = "Vu Linh", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0988199737", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00667", CreatedAt = date.AddDays(-22) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "49", FullName = "Vu Nga Linh", Email = "vungalinh@gmail.com", UserName = "Vu Nga Linh", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0988199740", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00668", CreatedAt = date.AddDays(-22) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "50", FullName = "Vu Thi Thuy Linh", Email = "vuthithuylinh@gmail.com", UserName = "Vu Thi Thuy Linh", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0988199743", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00669", CreatedAt = date.AddDays(-19) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "51", FullName = "Nguyen Yen", Email = "nguyenyen@gmail.com", UserName = "Nguyen Yen", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0988199746", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00670", CreatedAt = date.AddDays(-19) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "52", FullName = "Tang Phuong Anh", Email = "tangphuonganh@gmail.com", UserName = "Tang Phuong Anh", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0988199747", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00671", CreatedAt = date.AddDays(-16) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "53", FullName = "Nguyen Kim Yen", Email = "nguyenthiyen@gmail.com", UserName = "Nguyen Kim Yen", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0988199750", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00672", CreatedAt = date.AddDays(-16) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "54", FullName = "JohnSon", Email = "johnson@gmail.com", UserName = "JohnSon", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0988199753", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00673", CreatedAt = date.AddDays(-16) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "55", FullName = "NixSon", Email = "nixson@gmail.com", UserName = "NixSon", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0988199756", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00674", CreatedAt = date.AddDays(-16) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "56", FullName = "Tran My Hao", Email = "tranmyhao@gmail.com", UserName = "Tran My Hao", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0988199759", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00675", CreatedAt = date.AddDays(-16) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "57", FullName = "Thanh Sang", Email = "thanhsang@gmail.com", UserName = "Thanh Sang", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0988199763", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00676", CreatedAt = date.AddDays(-16) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "58", FullName = "Hoang Van Thu", Email = "hoangvanthu@gmail.com", UserName = "Hoang Van Thu", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0988199765", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00677", CreatedAt = date.AddDays(-16) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "59", FullName = "Duong Van Hung", Email = "duongvanhung@gmail.com", UserName = "Duong Van Hung", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0988199768", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00678", CreatedAt = date.AddDays(-16) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "60", FullName = "Dinh Nam", Email = "dinhnam@gmail.com", UserName = "Dinh Nam 04", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0988199769", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00679", CreatedAt = date.AddDays(-16) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "61", FullName = "Nam Dinh", Email = "namdinh@gmail.com", UserName = "Nam Dinh 04", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0988199772", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00680", CreatedAt = date.AddDays(-16) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "62", FullName = "The Nam", Email = "thenam@gmail.com", UserName = "The Nam 04", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0988199773", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00681", CreatedAt = date.AddDays(-12) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "63", FullName = "Ho Tuan Tai", Email = "hotuantai@gmail.com", UserName = "Ho Tuan Tai", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0988199776", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00682", CreatedAt = date.AddDays(-12) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "64", FullName = "Ong Cao Thang", Email = "ongcaothang@gmail.com", UserName = "Ong Cao Thang", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0988199779", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00683", CreatedAt = date.AddDays(-12) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "65", FullName = "Lai Thi Ho", Email = "laithiho@gmail.com", UserName = "Lai Thi Ho", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0988199782", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00684", CreatedAt = date.AddDays(-9) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "66", FullName = "Adam Levin", Email = "adminlevin@gmail.com", UserName = "Adam Levin", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0988199783", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00685", CreatedAt = date.AddDays(-9) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "67", FullName = "La Phuong", Email = "laphuong@gmail.com", UserName = "La Phuong 02", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0988199785", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00686", CreatedAt = date.AddDays(-9) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "68", FullName = "Phuong Thanh", Email = "phuongthanh@gmail.com", UserName = "Phuong Thanh", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0988199786", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00687", CreatedAt = date.AddDays(-9) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "69", FullName = "Tuan Anh", Email = "tuananh@gmail.com", UserName = "Tuan Anh", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0988199789", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00688", CreatedAt = date.AddDays(-9) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "70", FullName = "Tri Thien", Email = "trithien@gmail.com", UserName = "Tri Thien", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0988199791", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00689", CreatedAt = date.AddDays(-5) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "71", FullName = "Duong Van Hung", Email = "duongvanhung@gmail.com", UserName = "Duong Van Hung 01", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0988199794", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00690", CreatedAt = date.AddDays(-5) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "72", FullName = "Ngo Ha My", Email = "ngohamy@gmail.com", UserName = "Ngo Ha My", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0988199797", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00691", CreatedAt = date.AddDays(-5) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "73", FullName = "Ngo Van Ty", Email = "ngovanty@gmail.com", UserName = "Tran Thi Thao", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0988399802", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00692", CreatedAt = date.AddDays(-5) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "74", FullName = "Tran Thi Thao", Email = "trnathithao@gmail.com", UserName = "Tran Thi Thao 02", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0123623712", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00693", CreatedAt = date.AddDays(-5) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "75", FullName = "Nguyen Thang Loi", Email = "nguyenthangloi@gmail.com", UserName = "Nguyen Thang Loi", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0123623713", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00694", CreatedAt = date.AddDays(-5) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "76", FullName = "Dao Thi Thao", Email = "daothithao@gmail.com", UserName = "Dao Thi Thao", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0123623715", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00695", CreatedAt = date.AddDays(-1) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "77", FullName = "Lai Thi Hang", Email = "laithihang@gmail.com", UserName = "Lai Thi Hang", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0123623717", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00696", CreatedAt = date.AddDays(-1) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "78", FullName = "Tuan Khanh", Email = "tuankhanh@gmail.com", UserName = "Tuan Khanh", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0123623719", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00697", CreatedAt = date.AddDays(-1) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "79", FullName = "Tu Cung Phung", Email = "tucungphung@gmail.com", UserName = "Tu Cung Phung", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0923678423", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00698", CreatedAt = date.AddDays(-1) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "80", FullName = "Quang Le", Email = "quangle@gmail.com", UserName = "Quang Le", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0923678424", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00699", CreatedAt = date.AddDays(-3) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "81", FullName = "Vu Thanh An", Email = "vuthanhan@gmail.com", UserName = "Vu Thanh An", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0923678426", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00700", CreatedAt = date.AddDays(-3) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "82", FullName = "La Phuong", Email = "laphuong@gmail.com", UserName = "La Phuong 03", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0923678428", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00701", CreatedAt = date.AddDays(-3) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "83", FullName = "Nhan Thanh", Email = "nhanthanh@gmail.com", UserName = "Nhan Thanh", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0923678430", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00701", CreatedAt = date.AddDays(-5) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "84", FullName = "Kim Tien", Email = "kientien@gmail.com", UserName = "Kim Tien", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0923678432", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00703", CreatedAt = date.AddDays(-5) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "85", FullName = "Kim Nghi", Email = "kimnghi@gmail.com", UserName = "Kim Nghi 02", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0923678465", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00704", CreatedAt = date.AddDays(-2) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "86", FullName = "Thuy Nga", Email = "thuynga@gmail.com", UserName = "Thuy Nga", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0123125371", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00705", CreatedAt = date.AddDays(-2) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "87", FullName = "Tu Cung Phung", Email = "tucungphung@gmail.com", UserName = "Tu Cung Phung 02", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0881231623", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00706", CreatedAt = date.AddDays(-2) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "88", FullName = "Anh Hai", Email = "anhhai@gmail.com", UserName = "Anh Hai", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0881231624", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00707", CreatedAt = date.AddDays(-2) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "89", FullName = "Lam Truong", Email = "lamtruong@gmail.com", UserName = "Lam Truong", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0881231626", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00708", CreatedAt = date.AddDays(-2) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "90", FullName = "Dan Truong", Email = "dantruong@gmail.com", UserName = "Dan Truong", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0881231627", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00709", CreatedAt = date.AddDays(-2) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "91", FullName = "Dan Nguyen", Email = "dannguyen@gmail.com", UserName = "Dan Nguyen", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0881231628", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00710", CreatedAt = date.AddDays(-2) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "92", FullName = "Dinh The Nam", Email = "dinhthenam@gmail.com", UserName = "Dinh The Nam", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0767123123", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00711", CreatedAt = date.AddDays(-2) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "93", FullName = "Tuan Anh", Email = "tuananh@gmail.com", UserName = "Tuan Anh 02", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0982336610", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00712", CreatedAt = date.AddDays(-2) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "94", FullName = "Tri Thien", Email = "trithien@gmail.com", UserName = "Tri Thien 02", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0862123123", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00713", CreatedAt = date.AddDays(-1) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "95", FullName = "Duong Van Hung", Email = "duongvanhung@gmail.com", UserName = "Duong Van Hung 02", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0979146146", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00714", CreatedAt = date.AddDays(-1) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "96", FullName = "Le Thu Thao", Email = "lethuthao@gmail.com", UserName = "Le Thu Thao", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0872123612", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00715", CreatedAt = date.AddDays(-5) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "97", FullName = "Ngo Thi Ha", Email = "ngothiha@gmail.com", UserName = "Ngo Thi Ha", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0983125126", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00716", CreatedAt = date.AddDays(0) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "98", FullName = "Ngo Ha My", Email = "ngohamy@gmail.com", UserName = "Ngo Ha My 02", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0123756281", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00717", CreatedAt = date.AddDays(0) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "99", FullName = "Tran Thi Thao", Email = "tranthithao@gmail.com", UserName = "Tran Thi Thao 03", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "09851237348", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00718", CreatedAt = date.AddDays(0) });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "100", FullName = "Van Hung", Email = "vanhung@gmail.com", UserName = "Van Hung", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0892475459", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00719", CreatedAt = date.AddDays(0) });


            UserManager.AddToRole("1", "Admin");
            UserManager.AddToRole("2", "Manager");
            UserManager.AddToRole("3", "Faculty");
            UserManager.AddToRole("4", "Student");
            UserManager.AddToRole("5", "Student");
            UserManager.AddToRole("6", "Student");
            UserManager.AddToRole("7", "Student");
            UserManager.AddToRole("8", "Student");
            UserManager.AddToRole("9", "Student");
            UserManager.AddToRole("10", "Student");
            UserManager.AddToRole("11", "Student");
            UserManager.AddToRole("12", "Student");
            UserManager.AddToRole("13", "Student");
            UserManager.AddToRole("14", "Student");
            UserManager.AddToRole("15", "Student");
            UserManager.AddToRole("16", "Student");
            UserManager.AddToRole("17", "Student");
            UserManager.AddToRole("18", "Student");
            UserManager.AddToRole("19", "Student");
            UserManager.AddToRole("20", "Student");
            UserManager.AddToRole("21", "Student");
            UserManager.AddToRole("22", "Student");
            UserManager.AddToRole("23", "Student");
            UserManager.AddToRole("24", "Student");
            UserManager.AddToRole("25", "Student");
            UserManager.AddToRole("26", "Student");
            UserManager.AddToRole("27", "Student");
            UserManager.AddToRole("28", "Student");
            UserManager.AddToRole("29", "Student");
            UserManager.AddToRole("30", "Student");

            UserManager.AddToRole("31", "Student");
            UserManager.AddToRole("32", "Student");
            UserManager.AddToRole("33", "Student");
            UserManager.AddToRole("34", "Student");
            UserManager.AddToRole("35", "Student");
            UserManager.AddToRole("36", "Student");
            UserManager.AddToRole("37", "Student");
            UserManager.AddToRole("38", "Student");
            UserManager.AddToRole("39", "Student");
            UserManager.AddToRole("40", "Student");

            UserManager.AddToRole("41", "Student");
            UserManager.AddToRole("42", "Student");
            UserManager.AddToRole("43", "Student");
            UserManager.AddToRole("44", "Student");
            UserManager.AddToRole("45", "Student");
            UserManager.AddToRole("46", "Student");
            UserManager.AddToRole("47", "Student");
            UserManager.AddToRole("48", "Student");
            UserManager.AddToRole("49", "Student");
            UserManager.AddToRole("50", "Student");
            UserManager.AddToRole("51", "Student");
            UserManager.AddToRole("52", "Student");
            UserManager.AddToRole("53", "Student");
            UserManager.AddToRole("54", "Student");
            UserManager.AddToRole("55", "Student");
            UserManager.AddToRole("56", "Student");
            UserManager.AddToRole("57", "Student");
            UserManager.AddToRole("58", "Student");
            UserManager.AddToRole("59", "Student");
            UserManager.AddToRole("60", "Student");
            UserManager.AddToRole("61", "Student");
            UserManager.AddToRole("62", "Student");
            UserManager.AddToRole("63", "Student");
            UserManager.AddToRole("64", "Student");
            UserManager.AddToRole("65", "Student");
            UserManager.AddToRole("66", "Student");
            UserManager.AddToRole("67", "Student");
            UserManager.AddToRole("68", "Student");
            UserManager.AddToRole("69", "Student");
            UserManager.AddToRole("70", "Student");
            UserManager.AddToRole("71", "Student");
            UserManager.AddToRole("72", "Student");
            UserManager.AddToRole("73", "Student");
            UserManager.AddToRole("74", "Student");
            UserManager.AddToRole("75", "Student");
            UserManager.AddToRole("76", "Student");
            UserManager.AddToRole("77", "Student");
            UserManager.AddToRole("78", "Student");
            UserManager.AddToRole("79", "Student");
            UserManager.AddToRole("80", "Student");
            UserManager.AddToRole("81", "Student");
            UserManager.AddToRole("82", "Student");
            UserManager.AddToRole("83", "Student");
            UserManager.AddToRole("84", "Student");
            UserManager.AddToRole("85", "Student");
            UserManager.AddToRole("86", "Student");
            UserManager.AddToRole("87", "Student");
            UserManager.AddToRole("88", "Student");
            UserManager.AddToRole("89", "Student");
            UserManager.AddToRole("90", "Student");
            UserManager.AddToRole("91", "Student");
            UserManager.AddToRole("92", "Student");
            UserManager.AddToRole("93", "Student");
            UserManager.AddToRole("94", "Student");
            UserManager.AddToRole("95", "Student");
            UserManager.AddToRole("96", "Student");
            UserManager.AddToRole("97", "Student");
            UserManager.AddToRole("98", "Student");
            UserManager.AddToRole("99", "Student");
            UserManager.AddToRole("100", "Student");


            IList<string> listIdStudent = new List<string>();
            listIdStudent.Add("4");
            listIdStudent.Add("5");
            listIdStudent.Add("6");
            listIdStudent.Add("7");
            listIdStudent.Add("8");

            IList<string> listIdStudent2 = new List<string>();
            listIdStudent2.Add("9");
            listIdStudent2.Add("10");
            listIdStudent2.Add("11");
            listIdStudent2.Add("12");
            listIdStudent2.Add("13");

            var listStudent = "";
            var listStudent2 = "";
            foreach (var item in listIdStudent)
            {
                listStudent += item + ",";
            }

            foreach (var item in listIdStudent2)
            {
                listStudent2 += item + ",";
            }

            // list course
            IList<Course> courses = new List<Course>();

            courses.Add(new Course() { Id = 1, Name = "ASP .Net Mvc", Code = "ASPNETMCV", Price = 400, Description = "hello", Status = Course.CourseStatus.ACTIVE });
            courses.Add(new Course() { Id = 2, Name = "Swift IOS", Code = "SWIFT", Price = 450, Description = "hello", Status = Course.CourseStatus.ACTIVE });
            courses.Add(new Course() { Id = 3, Name = "Node Js", Code = "NODEJS", Price = 400, Description = "hello", Status = Course.CourseStatus.ACTIVE });
            courses.Add(new Course() { Id = 4, Name = "Java Spring Boot", Code = "JAVAWEB", Price = 450, Description = "hello", Status = Course.CourseStatus.ACTIVE });
            courses.Add(new Course() { Id = 5, Name = "Kotlin Android", Code = "KOTLIN", Price = 450, Description = "hello", Status = Course.CourseStatus.ACTIVE });
            courses.Add(new Course() { Id = 6, Name = "HTML&CSS JS", Code = "HTMLCSS", Price = 250, Description = "hello", Status = Course.CourseStatus.ACTIVE });
            courses.Add(new Course() { Id = 7, Name = "PHP Laravel", Code = "PHPL", Price = 350, Description = "hello", Status = Course.CourseStatus.ACTIVE });
            context.Courses.AddRange(courses);

            // list batch
            IList<Batch> batches = new List<Batch>();

            batches.Add(new Batch() { Id = 1, Name = "Web Frontend 01", Code = "FE001", CourseId = 6, ListStudent = listStudent, Description = null, DateStart = date.AddDays(-30), DateEnd = date.AddDays(-25), Status = Batch.BatchStatus.ACTIVE });
            batches.Add(new Batch() { Id = 2, Name = "Web Frontend 02", Code = "FE002", CourseId = 6, ListStudent = listStudent2, Description = null, DateStart = date.AddDays(-25), DateEnd = date.AddDays(-20), Status = Batch.BatchStatus.ACTIVE });
            batches.Add(new Batch() { Id = 3, Name = ".Net Backend 01", Code = "BE001", CourseId = 1, ListStudent = listStudent, Description = null, DateStart = date.AddDays(-25), DateEnd = date.AddDays(-20), Status = Batch.BatchStatus.ACTIVE });
            batches.Add(new Batch() { Id = 4, Name = ".Net Backend 02", Code = "BE002", CourseId = 1, ListStudent = listStudent2, Description = null, DateStart = date.AddDays(-20), DateEnd = date.AddDays(-15), Status = Batch.BatchStatus.ACTIVE });
            batches.Add(new Batch() { Id = 5, Name = "Java Spring Boot 01", Code = "BE003", CourseId = 4, ListStudent = listStudent, Description = null, DateStart = date.AddDays(-20), DateEnd = date.AddDays(-15), Status = Batch.BatchStatus.ACTIVE });
            batches.Add(new Batch() { Id = 6, Name = "Java Spring Boot 02", Code = "BE004", CourseId = 4, ListStudent = listStudent2, Description = null, DateStart = date.AddDays(-15), DateEnd = date.AddDays(-10), Status = Batch.BatchStatus.ACTIVE });
            batches.Add(new Batch() { Id = 7, Name = "Node JS Backend 01", Code = "BE005", CourseId = 3, ListStudent = listStudent, Description = null, DateStart = date.AddDays(-15), DateEnd = date.AddDays(-10), Status = Batch.BatchStatus.ACTIVE });
            batches.Add(new Batch() { Id = 8, Name = "Node JS Backend 02", Code = "BE006", CourseId = 3, ListStudent = listStudent2, Description = null, DateStart = date.AddDays(-10), DateEnd = date.AddDays(-5), Status = Batch.BatchStatus.ACTIVE });
            batches.Add(new Batch() { Id = 9, Name = "PHP Laravel 01", Code = "BE007", CourseId = 7, ListStudent = listStudent, Description = null, DateStart = date.AddDays(-10), DateEnd = date.AddDays(-5), Status = Batch.BatchStatus.ACTIVE });
            batches.Add(new Batch() { Id = 10, Name = "PHP Laravel 02", Code = "BE008", CourseId = 7, ListStudent = listStudent2, Description = null, DateStart = date.AddDays(-5), DateEnd = date.AddDays(0), Status = Batch.BatchStatus.ACTIVE });
            batches.Add(new Batch() { Id = 11, Name = "Mobile Dev 01", Code = "MB001", CourseId = 2, ListStudent = listStudent, Description = null, DateStart = date.AddDays(-5), DateEnd = date.AddDays(0), Status = Batch.BatchStatus.ACTIVE });
            batches.Add(new Batch() { Id = 12, Name = "Mobile Dev 02", Code = "MB002", CourseId = 2, ListStudent = listStudent2, Description = null, DateStart = date.AddDays(0), DateEnd = date.AddDays(5), Status = Batch.BatchStatus.ACTIVE });
            batches.Add(new Batch() { Id = 13, Name = "Mobile Dev 03", Code = "MB003", CourseId = 5, ListStudent = listStudent, Description = null, DateStart = date.AddDays(0), DateEnd = date.AddDays(5), Status = Batch.BatchStatus.ACTIVE });
            batches.Add(new Batch() { Id = 14, Name = "Mobile Dev 04", Code = "MB004", CourseId = 5, ListStudent = listStudent2, Description = null, DateStart = date.AddDays(5), DateEnd = date.AddDays(10), Status = Batch.BatchStatus.ACTIVE });
            batches.Add(new Batch() { Id = 15, Name = "Mobile Dev 05", Code = "MB005", CourseId = 2, ListStudent = listStudent, Description = null, DateStart = date.AddDays(5), DateEnd = date.AddDays(10), Status = Batch.BatchStatus.ACTIVE });
            batches.Add(new Batch() { Id = 16, Name = "Mobile Dev 06", Code = "MB006", CourseId = 2, ListStudent = listStudent2, Description = null, DateStart = date.AddDays(10), DateEnd = date.AddDays(20), Status = Batch.BatchStatus.ACTIVE });
            batches.Add(new Batch() { Id = 17, Name = ".Net Backend 03", Code = "BE003", CourseId = 1, ListStudent = listStudent, Description = null, DateStart = date.AddDays(10), DateEnd = date.AddDays(20), Status = Batch.BatchStatus.ACTIVE });
            batches.Add(new Batch() { Id = 18, Name = ".Net Backend 04", Code = "BE004", CourseId = 1, ListStudent = listStudent2, Description = null, DateStart = date.AddDays(15), DateEnd = date.AddDays(30), Status = Batch.BatchStatus.ACTIVE });
            context.Batches.AddRange(batches);

            // list exam
            IList<Exam> exams = new List<Exam>();
            exams.Add(new Exam() { Id = 1, BatchId = 1, DateExam = date.AddDays(-25), StartTime = new TimeSpan(9,0,0), Status = Exam.ExamStatus.DONE });
            exams.Add(new Exam() { Id = 2, BatchId = 2, DateExam = date.AddDays(-20), StartTime = new TimeSpan(10,0,0), Status = Exam.ExamStatus.DONE });
            exams.Add(new Exam() { Id = 3, BatchId = 3, DateExam = date.AddDays(-20), StartTime = new TimeSpan(17,30,0), Status = Exam.ExamStatus.DONE });
            exams.Add(new Exam() { Id = 4, BatchId = 4, DateExam = date.AddDays(-15), StartTime = new TimeSpan(13,30,0), Status = Exam.ExamStatus.DONE });
            exams.Add(new Exam() { Id = 5, BatchId = 5, DateExam = date.AddDays(-15), StartTime = new TimeSpan(8,0,0), Status = Exam.ExamStatus.DONE });
            exams.Add(new Exam() { Id = 6, BatchId = 6, DateExam = date.AddDays(-10), StartTime = new TimeSpan(17,0,0), Status = Exam.ExamStatus.DONE });
            exams.Add(new Exam() { Id = 7, BatchId = 7, DateExam = date.AddDays(-10), StartTime = new TimeSpan(15,0,0), Status = Exam.ExamStatus.DONE });
            exams.Add(new Exam() { Id = 8, BatchId = 8, DateExam = date.AddDays(-5), StartTime = new TimeSpan(9,0,0), Status = Exam.ExamStatus.DONE });
            exams.Add(new Exam() { Id = 9, BatchId = 9, DateExam = date.AddDays(-5), StartTime = new TimeSpan(20,0,0), Status = Exam.ExamStatus.DONE });
            exams.Add(new Exam() { Id = 10, BatchId = 10, DateExam = date.AddDays(0), StartTime = new TimeSpan(10,0,0), Status = Exam.ExamStatus.DONE });
            exams.Add(new Exam() { Id = 11, BatchId = 11, DateExam = date.AddDays(0), StartTime = new TimeSpan(9,0,0), Status = Exam.ExamStatus.DONE });
            context.Exams.AddRange(exams);

            // list exam detail
            IList<ExamDetail> examDetails = new List<ExamDetail>();

            // exam id = 1
            examDetails.Add(new ExamDetail() { ExamId = 1, ApplicationUserId = "4", Mark = 40, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 1, ApplicationUserId = "5", Mark = 35, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 1, ApplicationUserId = "6", Mark = 90, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 1, ApplicationUserId = "7", Mark = 85, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 1, ApplicationUserId = "8", Mark = 70, Note = null });

            // exam id = 2
            examDetails.Add(new ExamDetail() { ExamId = 2, ApplicationUserId = "9", Mark = 50, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 2, ApplicationUserId = "10", Mark = 55, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 2, ApplicationUserId = "11", Mark = 70, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 2, ApplicationUserId = "12", Mark = 85, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 2, ApplicationUserId = "13", Mark = 60, Note = null });

            // exam id = 3
            examDetails.Add(new ExamDetail() { ExamId = 3, ApplicationUserId = "4", Mark = 20, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 3, ApplicationUserId = "5", Mark = 35, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 3, ApplicationUserId = "6", Mark = 70, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 3, ApplicationUserId = "7", Mark = 85, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 3, ApplicationUserId = "8", Mark = 80, Note = null });

            // exam id = 4
            examDetails.Add(new ExamDetail() { ExamId = 4, ApplicationUserId = "9", Mark = 60, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 4, ApplicationUserId = "10", Mark = 65, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 4, ApplicationUserId = "11", Mark = 40, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 4, ApplicationUserId = "12", Mark = 75, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 4, ApplicationUserId = "13", Mark = 90, Note = null });

            // exam id = 5
            examDetails.Add(new ExamDetail() { ExamId = 5, ApplicationUserId = "4", Mark = 40, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 5, ApplicationUserId = "5", Mark = 35, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 5, ApplicationUserId = "6", Mark = 90, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 5, ApplicationUserId = "7", Mark = 85, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 5, ApplicationUserId = "8", Mark = 70, Note = null });

            // exam id = 6
            examDetails.Add(new ExamDetail() { ExamId = 6, ApplicationUserId = "9", Mark = 50, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 6, ApplicationUserId = "10", Mark = 55, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 6, ApplicationUserId = "11", Mark = 70, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 6, ApplicationUserId = "12", Mark = 85, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 6, ApplicationUserId = "13", Mark = 60, Note = null });

            // exam id = 7
            examDetails.Add(new ExamDetail() { ExamId = 7, ApplicationUserId = "4", Mark = 65, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 7, ApplicationUserId = "5", Mark = 70, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 7, ApplicationUserId = "6", Mark = 50, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 7, ApplicationUserId = "7", Mark = 95, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 7, ApplicationUserId = "8", Mark = 100, Note = null });

            // exam id = 8
            examDetails.Add(new ExamDetail() { ExamId = 8, ApplicationUserId = "9", Mark = 50, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 8, ApplicationUserId = "10", Mark = 75, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 8, ApplicationUserId = "11", Mark = 70, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 8, ApplicationUserId = "12", Mark = 25, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 8, ApplicationUserId = "13", Mark = 60, Note = null });

            // exam id = 9
            examDetails.Add(new ExamDetail() { ExamId = 9, ApplicationUserId = "4", Mark = 35, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 9, ApplicationUserId = "5", Mark = 80, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 9, ApplicationUserId = "6", Mark = 55, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 9, ApplicationUserId = "7", Mark = 95, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 9, ApplicationUserId = "8", Mark = 65, Note = null });

            // exam id = 10
            examDetails.Add(new ExamDetail() { ExamId = 10, ApplicationUserId = "9", Mark = 55, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 10, ApplicationUserId = "10", Mark = 45, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 10, ApplicationUserId = "11", Mark = 75, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 10, ApplicationUserId = "12", Mark = 40, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 10, ApplicationUserId = "13", Mark = 60, Note = null });

            // exam id = 11
            examDetails.Add(new ExamDetail() { ExamId = 11, ApplicationUserId = "4", Mark = 45, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 11, ApplicationUserId = "5", Mark = 45, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 11, ApplicationUserId = "6", Mark = 70, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 11, ApplicationUserId = "7", Mark = 90, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 11, ApplicationUserId = "8", Mark = 80, Note = null });
            context.ExamDetails.AddRange(examDetails);

            // payment
            // fee course
            IList<Payment> payments = new List<Payment>();

            // batch id = 1
            payments.Add(new Payment() { Id = 1, ApplicationUserId = "4", BatchId = 1, AmountPayable = 250, AmountPaid = 250, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(-33), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 2, ApplicationUserId = "5", BatchId = 1, AmountPayable = 250, AmountPaid = 250, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(-32), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 3, ApplicationUserId = "6", BatchId = 1, AmountPayable = 250, AmountPaid = 250, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(-33), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 4, ApplicationUserId = "7", BatchId = 1, AmountPayable = 250, AmountPaid = 250, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(-32), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 5, ApplicationUserId = "8", BatchId = 1, AmountPayable = 250, AmountPaid = 250, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(-31), Note = null, Status = Payment.PaymentStatus.ACTIVE });

            // batch id = 2
            payments.Add(new Payment() { Id = 6, ApplicationUserId = "9", BatchId = 2, AmountPayable = 250, AmountPaid = 250, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(-26), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 7, ApplicationUserId = "10", BatchId = 2, AmountPayable = 250, AmountPaid = 250, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(-27), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 8, ApplicationUserId = "11", BatchId = 2, AmountPayable = 250, AmountPaid = 250, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(-28), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 9, ApplicationUserId = "12", BatchId = 2, AmountPayable = 250, AmountPaid = 250, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(-29), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 10, ApplicationUserId = "13", BatchId = 2, AmountPayable = 250, AmountPaid = 250, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(-30), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            
            // batch id = 3
            payments.Add(new Payment() { Id = 11, ApplicationUserId = "4", BatchId = 3, AmountPayable = 400, AmountPaid = 400, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(-27), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 12, ApplicationUserId = "5", BatchId = 3, AmountPayable = 400, AmountPaid = 400, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(-27), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 13, ApplicationUserId = "6", BatchId = 3, AmountPayable = 400, AmountPaid = 400, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(-35), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 14, ApplicationUserId = "7", BatchId = 3, AmountPayable = 400, AmountPaid = 400, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(-32), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 15, ApplicationUserId = "8", BatchId = 3, AmountPayable = 400, AmountPaid = 400, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(-31), Note = null, Status = Payment.PaymentStatus.ACTIVE });

            // batch id = 4
            payments.Add(new Payment() { Id = 16, ApplicationUserId = "9", BatchId = 4, AmountPayable = 400, AmountPaid = 400, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(-26), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 17, ApplicationUserId = "10", BatchId = 4, AmountPayable = 400, AmountPaid = 400, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(-27), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 18, ApplicationUserId = "11", BatchId = 4, AmountPayable = 400, AmountPaid = 400, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(-22), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 19, ApplicationUserId = "12", BatchId = 4, AmountPayable = 400, AmountPaid = 400, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(-23), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 20, ApplicationUserId = "13", BatchId = 4, AmountPayable = 400, AmountPaid = 400, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(-34), Note = null, Status = Payment.PaymentStatus.ACTIVE });

            // batch id = 5
            payments.Add(new Payment() { Id = 21, ApplicationUserId = "4", BatchId = 5, AmountPayable = 405, AmountPaid = 405, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(-21), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 22, ApplicationUserId = "5", BatchId = 5, AmountPayable = 405, AmountPaid = 405, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(-23), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 23, ApplicationUserId = "6", BatchId = 5, AmountPayable = 405, AmountPaid = 405, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(-30), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 24, ApplicationUserId = "7", BatchId = 5, AmountPayable = 405, AmountPaid = 405, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(-26), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 25, ApplicationUserId = "8", BatchId = 5, AmountPayable = 405, AmountPaid = 405, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(-22), Note = null, Status = Payment.PaymentStatus.ACTIVE });

            // batch id = 6
            payments.Add(new Payment() { Id = 26, ApplicationUserId = "9", BatchId = 6, AmountPayable = 450, AmountPaid = 450, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(-16), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 27, ApplicationUserId = "10", BatchId = 6, AmountPayable = 450, AmountPaid = 450, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(-17), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 28, ApplicationUserId = "11", BatchId = 6, AmountPayable = 450, AmountPaid = 450, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(-22), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 29, ApplicationUserId = "12", BatchId = 6, AmountPayable = 450, AmountPaid = 450, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(-23), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 30, ApplicationUserId = "13", BatchId = 6, AmountPayable = 450, AmountPaid = 450, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(-24), Note = null, Status = Payment.PaymentStatus.ACTIVE });

            // batch id = 7
            payments.Add(new Payment() { Id = 31, ApplicationUserId = "4", BatchId = 7, AmountPayable = 360, AmountPaid = 360, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(-21), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 32, ApplicationUserId = "5", BatchId = 7, AmountPayable = 360, AmountPaid = 360, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(-23), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 33, ApplicationUserId = "6", BatchId = 7, AmountPayable = 360, AmountPaid = 360, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(-26), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 34, ApplicationUserId = "7", BatchId = 7, AmountPayable = 400, AmountPaid = 400, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(-16), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 35, ApplicationUserId = "8", BatchId = 7, AmountPayable = 400, AmountPaid = 400, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(-16), Note = null, Status = Payment.PaymentStatus.ACTIVE });

            // batch id = 8
            payments.Add(new Payment() { Id = 36, ApplicationUserId = "9", BatchId = 8, AmountPayable = 340, AmountPaid = 340, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(-16), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 37, ApplicationUserId = "10", BatchId = 8, AmountPayable = 340, AmountPaid = 340, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(-17), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 38, ApplicationUserId = "11", BatchId = 8, AmountPayable = 340, AmountPaid = 340, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(-12), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 39, ApplicationUserId = "12", BatchId = 8, AmountPayable = 340, AmountPaid = 340, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(-13), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 40, ApplicationUserId = "13", BatchId = 8, AmountPayable = 340, AmountPaid = 340, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(-14), Note = null, Status = Payment.PaymentStatus.ACTIVE });

            // batch id = 9
            payments.Add(new Payment() { Id = 41, ApplicationUserId = "4", BatchId = 9, AmountPayable = 350, AmountPaid = 350, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(-11), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 42, ApplicationUserId = "5", BatchId = 9, AmountPayable = 350, AmountPaid = 350, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(-13), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 43, ApplicationUserId = "6", BatchId = 9, AmountPayable = 350, AmountPaid = 350, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(-16), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 44, ApplicationUserId = "7", BatchId = 9, AmountPayable = 350, AmountPaid = 350, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(-16), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 45, ApplicationUserId = "8", BatchId = 9, AmountPayable = 350, AmountPaid = 350, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(-16), Note = null, Status = Payment.PaymentStatus.ACTIVE });

            // batch id = 10
            payments.Add(new Payment() { Id = 46, ApplicationUserId = "9", BatchId = 10, AmountPayable = 315, AmountPaid = 315, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(-6), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 47, ApplicationUserId = "10", BatchId = 10, AmountPayable = 315, AmountPaid = 315, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(-7), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 48, ApplicationUserId = "11", BatchId = 10, AmountPayable = 315, AmountPaid = 315, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(-11), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 49, ApplicationUserId = "12", BatchId = 10, AmountPayable = 315, AmountPaid = 315, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(-12), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 50, ApplicationUserId = "13", BatchId = 10, AmountPayable = 315, AmountPaid = 315, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(-9), Note = null, Status = Payment.PaymentStatus.ACTIVE });

            // batch id = 11
            payments.Add(new Payment() { Id = 51, ApplicationUserId = "4", BatchId = 11, AmountPayable = 360, AmountPaid = 360, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(-11), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 52, ApplicationUserId = "5", BatchId = 11, AmountPayable = 360, AmountPaid = 360, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(-13), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 53, ApplicationUserId = "6", BatchId = 11, AmountPayable = 360, AmountPaid = 360, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(-6), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 54, ApplicationUserId = "7", BatchId = 11, AmountPayable = 360, AmountPaid = 360, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(-16), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 55, ApplicationUserId = "8", BatchId = 11, AmountPayable = 360, AmountPaid = 360, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(-14), Note = null, Status = Payment.PaymentStatus.ACTIVE });

            // batch id = 12
            payments.Add(new Payment() { Id = 56, ApplicationUserId = "9", BatchId = 12, AmountPayable = 405, AmountPaid = 405, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(-6), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 57, ApplicationUserId = "10", BatchId = 12, AmountPayable = 405, AmountPaid = 405, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(-7), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 58, ApplicationUserId = "11", BatchId = 12, AmountPayable = 405, AmountPaid = 405, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(-1), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 59, ApplicationUserId = "12", BatchId = 12, AmountPayable = 405, AmountPaid = 405, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(-2), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 60, ApplicationUserId = "13", BatchId = 12, AmountPayable = 405, AmountPaid = 405, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(-9), Note = null, Status = Payment.PaymentStatus.ACTIVE });

            // batch id = 13
            payments.Add(new Payment() { Id = 61, ApplicationUserId = "4", BatchId = 13, AmountPayable = 382.5, AmountPaid = 382.5, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(-1), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 62, ApplicationUserId = "5", BatchId = 13, AmountPayable = 382.5, AmountPaid = 382.5, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(-3), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 63, ApplicationUserId = "6", BatchId = 13, AmountPayable = 382.5, AmountPaid = 382.5, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(-6), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 64, ApplicationUserId = "7", BatchId = 13, AmountPayable = 382.5, AmountPaid = 382.5, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(-6), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 65, ApplicationUserId = "8", BatchId = 13, AmountPayable = 382.5, AmountPaid = 382.5, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(-4), Note = null, Status = Payment.PaymentStatus.ACTIVE });

            // batch id = 14
            payments.Add(new Payment() { Id = 66, ApplicationUserId = "9", BatchId = 14, AmountPayable = 450, AmountPaid = 225, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(-2), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 67, ApplicationUserId = "10", BatchId = 14, AmountPayable = 450, AmountPaid = 225, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(-2), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 68, ApplicationUserId = "11", BatchId = 14, AmountPayable = 450, AmountPaid = 225, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(-2), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 69, ApplicationUserId = "12", BatchId = 14, AmountPayable = 450, AmountPaid = 225, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(-2), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 70, ApplicationUserId = "13", BatchId = 14, AmountPayable = 450, AmountPaid = 225, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(-1), Note = null, Status = Payment.PaymentStatus.ACTIVE });

            // batch id = 15
            payments.Add(new Payment() { Id = 71, ApplicationUserId = "4", BatchId = 15, AmountPayable = 405, AmountPaid = 0, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(-2), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 72, ApplicationUserId = "5", BatchId = 15, AmountPayable = 405, AmountPaid = 0, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(-2), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 73, ApplicationUserId = "6", BatchId = 15, AmountPayable = 405, AmountPaid = 0, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(-2), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 74, ApplicationUserId = "7", BatchId = 15, AmountPayable = 405, AmountPaid = 0, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(-2), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 75, ApplicationUserId = "8", BatchId = 15, AmountPayable = 405, AmountPaid = 0, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(-2), Note = null, Status = Payment.PaymentStatus.ACTIVE });

            // batch id = 16
            payments.Add(new Payment() { Id = 76, ApplicationUserId = "9", BatchId = 16, AmountPayable = 450, AmountPaid = 300, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(-1), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 77, ApplicationUserId = "10", BatchId = 16, AmountPayable = 450, AmountPaid = 300, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(-1), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 78, ApplicationUserId = "11", BatchId = 16, AmountPayable = 450, AmountPaid = 300, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(-1), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 79, ApplicationUserId = "12", BatchId = 16, AmountPayable = 450, AmountPaid = 300, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(-1), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 80, ApplicationUserId = "13", BatchId = 16, AmountPayable = 450, AmountPaid = 300, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(-1), Note = null, Status = Payment.PaymentStatus.ACTIVE });

            // batch id = 17
            payments.Add(new Payment() { Id = 81, ApplicationUserId = "4", BatchId = 17, AmountPayable = 320, AmountPaid = 0, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(0), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 82, ApplicationUserId = "5", BatchId = 17, AmountPayable = 320, AmountPaid = 0, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(0), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 83, ApplicationUserId = "6", BatchId = 17, AmountPayable = 320, AmountPaid = 0, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(0), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 84, ApplicationUserId = "7", BatchId = 17, AmountPayable = 320, AmountPaid = 0, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(0), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 85, ApplicationUserId = "8", BatchId = 17, AmountPayable = 320, AmountPaid = 0, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(0), Note = null, Status = Payment.PaymentStatus.ACTIVE });

            // batch id = 18
            payments.Add(new Payment() { Id = 86, ApplicationUserId = "9", BatchId = 18, AmountPayable = 400, AmountPaid = 0, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(0), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 87, ApplicationUserId = "10", BatchId = 18, AmountPayable = 400, AmountPaid = 0, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(0), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 88, ApplicationUserId = "11", BatchId = 18, AmountPayable = 400, AmountPaid = 0, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(0), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 89, ApplicationUserId = "12", BatchId = 18, AmountPayable = 400, AmountPaid = 0, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(0), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 90, ApplicationUserId = "13", BatchId = 18, AmountPayable = 400, AmountPaid = 0, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(0), Note = null, Status = Payment.PaymentStatus.ACTIVE });

            // fine batch id = 1
            payments.Add(new Payment() { Id = 91, ApplicationUserId = "4", BatchId = 1, AmountPayable = 20, AmountPaid = 20, Type = Payment.PaymentType.FINE, PayDate = date.AddDays(-26), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 92, ApplicationUserId = "5", BatchId = 1, AmountPayable = 20, AmountPaid = 20, Type = Payment.PaymentType.FINE, PayDate = date.AddDays(-26), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 93, ApplicationUserId = "6", BatchId = 1, AmountPayable = 20, AmountPaid = 20, Type = Payment.PaymentType.FINE, PayDate = date.AddDays(-26), Note = null, Status = Payment.PaymentStatus.ACTIVE });

            // fine batch id = 2
            payments.Add(new Payment() { Id = 94, ApplicationUserId = "9", BatchId = 2, AmountPayable = 10, AmountPaid = 10, Type = Payment.PaymentType.FINE, PayDate = date.AddDays(-23), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 95, ApplicationUserId = "10", BatchId = 2, AmountPayable = 10, AmountPaid = 10, Type = Payment.PaymentType.FINE, PayDate = date.AddDays(-23), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 96, ApplicationUserId = "11", BatchId = 2, AmountPayable = 10, AmountPaid = 10, Type = Payment.PaymentType.FINE, PayDate = date.AddDays(-23), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 97, ApplicationUserId = "12", BatchId = 2, AmountPayable = 10, AmountPaid = 10, Type = Payment.PaymentType.FINE, PayDate = date.AddDays(-23), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 98, ApplicationUserId = "13", BatchId = 2, AmountPayable = 10, AmountPaid = 10, Type = Payment.PaymentType.FINE, PayDate = date.AddDays(-23), Note = null, Status = Payment.PaymentStatus.ACTIVE });

            // fine batch id = 3
            payments.Add(new Payment() { Id = 99, ApplicationUserId = "4", BatchId = 3, AmountPayable = 50, AmountPaid = 50, Type = Payment.PaymentType.FINE, PayDate = date.AddDays(-22), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 100, ApplicationUserId = "8", BatchId = 3, AmountPayable = 40, AmountPaid = 40, Type = Payment.PaymentType.FINE, PayDate = date.AddDays(-22), Note = null, Status = Payment.PaymentStatus.ACTIVE });

            // fine batch id = 4
            payments.Add(new Payment() { Id = 101, ApplicationUserId = "9", BatchId = 4, AmountPayable = 15, AmountPaid = 15, Type = Payment.PaymentType.FINE, PayDate = date.AddDays(-17), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 102, ApplicationUserId = "10", BatchId = 4, AmountPayable = 15, AmountPaid = 15, Type = Payment.PaymentType.FINE, PayDate = date.AddDays(-17), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 103, ApplicationUserId = "11", BatchId = 4, AmountPayable = 15, AmountPaid = 15, Type = Payment.PaymentType.FINE, PayDate = date.AddDays(-17), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 104, ApplicationUserId = "12", BatchId = 4, AmountPayable = 15, AmountPaid = 15, Type = Payment.PaymentType.FINE, PayDate = date.AddDays(-17), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 105, ApplicationUserId = "13", BatchId = 4, AmountPayable = 15, AmountPaid = 15, Type = Payment.PaymentType.FINE, PayDate = date.AddDays(-17), Note = null, Status = Payment.PaymentStatus.ACTIVE });

            // fine batch id = 5
            payments.Add(new Payment() { Id = 106, ApplicationUserId = "4", BatchId = 5, AmountPayable = 20, AmountPaid = 20, Type = Payment.PaymentType.FINE, PayDate = date.AddDays(-18), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 107, ApplicationUserId = "5", BatchId = 5, AmountPayable = 15, AmountPaid = 15, Type = Payment.PaymentType.FINE, PayDate = date.AddDays(-18), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 108, ApplicationUserId = "6", BatchId = 5, AmountPayable = 25, AmountPaid = 25, Type = Payment.PaymentType.FINE, PayDate = date.AddDays(-18), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 109, ApplicationUserId = "7", BatchId = 5, AmountPayable = 25, AmountPaid = 25, Type = Payment.PaymentType.FINE, PayDate = date.AddDays(-18), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 110, ApplicationUserId = "8", BatchId = 5, AmountPayable = 25, AmountPaid = 25, Type = Payment.PaymentType.FINE, PayDate = date.AddDays(-18), Note = null, Status = Payment.PaymentStatus.ACTIVE });

            // fine batch id = 6
            payments.Add(new Payment() { Id = 111, ApplicationUserId = "9", BatchId = 6, AmountPayable = 10, AmountPaid = 10, Type = Payment.PaymentType.FINE, PayDate = date.AddDays(-10), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 112, ApplicationUserId = "10", BatchId = 6, AmountPayable = 20, AmountPaid = 20, Type = Payment.PaymentType.FINE, PayDate = date.AddDays(-10), Note = null, Status = Payment.PaymentStatus.ACTIVE });

            // fine batch id = 7
            payments.Add(new Payment() { Id = 113, ApplicationUserId = "4", BatchId = 7, AmountPayable = 40, AmountPaid = 40, Type = Payment.PaymentType.FINE, PayDate = date.AddDays(-11), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 114, ApplicationUserId = "5", BatchId = 7, AmountPayable = 45, AmountPaid = 45, Type = Payment.PaymentType.FINE, PayDate = date.AddDays(-11), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 115, ApplicationUserId = "6", BatchId = 7, AmountPayable = 45, AmountPaid = 45, Type = Payment.PaymentType.FINE, PayDate = date.AddDays(-11), Note = null, Status = Payment.PaymentStatus.ACTIVE });

            // fine batch id = 8
            payments.Add(new Payment() { Id = 116, ApplicationUserId = "9", BatchId = 8, AmountPayable = 10, AmountPaid = 10, Type = Payment.PaymentType.FINE, PayDate = date.AddDays(-6), Note = null, Status = Payment.PaymentStatus.ACTIVE });

            // fine batch id = 9
            payments.Add(new Payment() { Id = 113, ApplicationUserId = "4", BatchId = 9, AmountPayable = 20, AmountPaid = 20, Type = Payment.PaymentType.FINE, PayDate = date.AddDays(-5), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 114, ApplicationUserId = "5", BatchId = 9, AmountPayable = 20, AmountPaid = 20, Type = Payment.PaymentType.FINE, PayDate = date.AddDays(-5), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 115, ApplicationUserId = "6", BatchId = 9, AmountPayable = 20, AmountPaid = 20, Type = Payment.PaymentType.FINE, PayDate = date.AddDays(-5), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 116, ApplicationUserId = "7", BatchId = 9, AmountPayable = 20, AmountPaid = 20, Type = Payment.PaymentType.FINE, PayDate = date.AddDays(-5), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 117, ApplicationUserId = "8", BatchId = 9, AmountPayable = 20, AmountPaid = 20, Type = Payment.PaymentType.FINE, PayDate = date.AddDays(-5), Note = null, Status = Payment.PaymentStatus.ACTIVE });

            // fine batch id = 10
            payments.Add(new Payment() { Id = 118, ApplicationUserId = "9", BatchId = 15, AmountPayable = 25, AmountPaid = 25, Type = Payment.PaymentType.FINE, PayDate = date.AddDays(-1), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 119, ApplicationUserId = "10", BatchId = 15, AmountPayable = 25, AmountPaid = 25, Type = Payment.PaymentType.FINE, PayDate = date.AddDays(-1), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 120, ApplicationUserId = "11", BatchId = 15, AmountPayable = 25, AmountPaid = 25, Type = Payment.PaymentType.FINE, PayDate = date.AddDays(-1), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 121, ApplicationUserId = "13", BatchId = 15, AmountPayable = 25, AmountPaid = 25, Type = Payment.PaymentType.FINE, PayDate = date.AddDays(-1), Note = null, Status = Payment.PaymentStatus.ACTIVE });

            // fine batch id = 11
            payments.Add(new Payment() { Id = 122, ApplicationUserId = "5", BatchId = 11, AmountPayable = 10, AmountPaid = 10, Type = Payment.PaymentType.FINE, PayDate = date.AddDays(0), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 123, ApplicationUserId = "6", BatchId = 11, AmountPayable = 20, AmountPaid = 20, Type = Payment.PaymentType.FINE, PayDate = date.AddDays(0), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 124, ApplicationUserId = "8", BatchId = 11, AmountPayable = 30, AmountPaid = 30, Type = Payment.PaymentType.FINE, PayDate = date.AddDays(0), Note = null, Status = Payment.PaymentStatus.ACTIVE });

            context.Payments.AddRange(payments);

            // reminder
            IList<Reminder> reminders = new List<Reminder>();

            // batch id = 1
            reminders.Add(new Reminder() { Id = 1, ApplicationUserId = "4", BatchId = 1, Note = "1st course fee reminder", Status = Reminder.ReminderStatus.DONE });
            reminders.Add(new Reminder() { Id = 2, ApplicationUserId = "5", BatchId = 1, Note = "1st course fee reminder", Status = Reminder.ReminderStatus.DONE });
            reminders.Add(new Reminder() { Id = 3, ApplicationUserId = "6", BatchId = 1, Note = "1st course fee reminder", Status = Reminder.ReminderStatus.DONE });
            reminders.Add(new Reminder() { Id = 4, ApplicationUserId = "7", BatchId = 1, Note = "1st course fee reminder", Status = Reminder.ReminderStatus.DONE });
            reminders.Add(new Reminder() { Id = 5, ApplicationUserId = "8", BatchId = 1, Note = "1st course fee reminder", Status = Reminder.ReminderStatus.DONE });

            // batch id = 2
            reminders.Add(new Reminder() { Id = 6, ApplicationUserId = "9", BatchId = 2, Note = "1st course fee reminder", Status = Reminder.ReminderStatus.DONE });
            reminders.Add(new Reminder() { Id = 7, ApplicationUserId = "10", BatchId = 2, Note = "1st course fee reminder", Status = Reminder.ReminderStatus.DONE });
            reminders.Add(new Reminder() { Id = 8, ApplicationUserId = "11", BatchId = 2, Note = "1st course fee reminder", Status = Reminder.ReminderStatus.DONE });
            reminders.Add(new Reminder() { Id = 9, ApplicationUserId = "12", BatchId = 2, Note = "1st course fee reminder", Status = Reminder.ReminderStatus.DONE });
            reminders.Add(new Reminder() { Id = 10, ApplicationUserId = "13", BatchId = 2, Note = "1st course fee reminder", Status = Reminder.ReminderStatus.DONE });

            // batch id = 14
            reminders.Add(new Reminder() { Id = 11, ApplicationUserId = "9", BatchId = 14, Note = "2nd course fee reminder", Status = Reminder.ReminderStatus.PENDING });
            reminders.Add(new Reminder() { Id = 12, ApplicationUserId = "10", BatchId = 14, Note = "2nd course fee reminder", Status = Reminder.ReminderStatus.PENDING });
            reminders.Add(new Reminder() { Id = 13, ApplicationUserId = "11", BatchId = 14, Note = "2nd course fee reminder", Status = Reminder.ReminderStatus.PENDING });
            reminders.Add(new Reminder() { Id = 14, ApplicationUserId = "12", BatchId = 14, Note = "2nd course fee reminder", Status = Reminder.ReminderStatus.PENDING });
            reminders.Add(new Reminder() { Id = 15, ApplicationUserId = "13", BatchId = 14, Note = "2nd course fee reminder", Status = Reminder.ReminderStatus.PENDING });

            // batch id = 15
            reminders.Add(new Reminder() { Id = 16, ApplicationUserId = "4", BatchId = 15, Note = "1st course fee reminder", Status = Reminder.ReminderStatus.PENDING });
            reminders.Add(new Reminder() { Id = 17, ApplicationUserId = "5", BatchId = 15, Note = "1st course fee reminder", Status = Reminder.ReminderStatus.PENDING });
            reminders.Add(new Reminder() { Id = 18, ApplicationUserId = "6", BatchId = 15, Note = "1st course fee reminder", Status = Reminder.ReminderStatus.PENDING });
            reminders.Add(new Reminder() { Id = 19, ApplicationUserId = "7", BatchId = 15, Note = "1st course fee reminder", Status = Reminder.ReminderStatus.PENDING });
            reminders.Add(new Reminder() { Id = 20, ApplicationUserId = "8", BatchId = 15, Note = "1st course fee reminder", Status = Reminder.ReminderStatus.PENDING });

            // batch id = 16
            reminders.Add(new Reminder() { Id = 21, ApplicationUserId = "9", BatchId = 16, Note = "1st course fee reminder", Status = Reminder.ReminderStatus.PENDING });
            reminders.Add(new Reminder() { Id = 22, ApplicationUserId = "10", BatchId = 16, Note = "1st course fee reminder", Status = Reminder.ReminderStatus.PENDING });
            reminders.Add(new Reminder() { Id = 23, ApplicationUserId = "11", BatchId = 16, Note = "1st course fee reminder", Status = Reminder.ReminderStatus.PENDING });
            reminders.Add(new Reminder() { Id = 24, ApplicationUserId = "12", BatchId = 16, Note = "1st course fee reminder", Status = Reminder.ReminderStatus.PENDING });
            reminders.Add(new Reminder() { Id = 25, ApplicationUserId = "13", BatchId = 16, Note = "1st course fee reminder", Status = Reminder.ReminderStatus.PENDING });

            // batch id = 17
            reminders.Add(new Reminder() { Id = 26, ApplicationUserId = "4", BatchId = 17, Note = "1st course fee reminder", Status = Reminder.ReminderStatus.PENDING });
            reminders.Add(new Reminder() { Id = 27, ApplicationUserId = "5", BatchId = 17, Note = "1st course fee reminder", Status = Reminder.ReminderStatus.PENDING });
            reminders.Add(new Reminder() { Id = 28, ApplicationUserId = "6", BatchId = 17, Note = "1st course fee reminder", Status = Reminder.ReminderStatus.PENDING });
            reminders.Add(new Reminder() { Id = 29, ApplicationUserId = "7", BatchId = 17, Note = "1st course fee reminder", Status = Reminder.ReminderStatus.PENDING });
            reminders.Add(new Reminder() { Id = 30, ApplicationUserId = "8", BatchId = 17, Note = "1st course fee reminder", Status = Reminder.ReminderStatus.PENDING });

            // batch id = 18
            reminders.Add(new Reminder() { Id = 31, ApplicationUserId = "9", BatchId = 18, Note = "1st course fee reminder", Status = Reminder.ReminderStatus.PENDING });
            reminders.Add(new Reminder() { Id = 32, ApplicationUserId = "10", BatchId = 18, Note = "1st course fee reminder", Status = Reminder.ReminderStatus.PENDING });
            reminders.Add(new Reminder() { Id = 33, ApplicationUserId = "11", BatchId = 18, Note = "1st course fee reminder", Status = Reminder.ReminderStatus.PENDING });
            reminders.Add(new Reminder() { Id = 34, ApplicationUserId = "12", BatchId = 18, Note = "1st course fee reminder", Status = Reminder.ReminderStatus.PENDING });
            reminders.Add(new Reminder() { Id = 35, ApplicationUserId = "13", BatchId = 18, Note = "1st course fee reminder", Status = Reminder.ReminderStatus.PENDING });

            context.Reminders.AddRange(reminders);

            // discount
            IList<Discount> discounts = new List<Discount>();

            // batch id = 5
            discounts.Add(new Discount() { Id = 1, ApplicationUserId = "4", BatchId = 5, CoursePrice = 450, DiscountValue = 10, Status = Discount.DiscountStatus.ACTIVE });
            discounts.Add(new Discount() { Id = 2, ApplicationUserId = "5", BatchId = 5, CoursePrice = 450, DiscountValue = 10, Status = Discount.DiscountStatus.ACTIVE });
            discounts.Add(new Discount() { Id = 3, ApplicationUserId = "6", BatchId = 5, CoursePrice = 450, DiscountValue = 10, Status = Discount.DiscountStatus.ACTIVE });
            discounts.Add(new Discount() { Id = 4, ApplicationUserId = "7", BatchId = 5, CoursePrice = 450, DiscountValue = 10, Status = Discount.DiscountStatus.ACTIVE });
            discounts.Add(new Discount() { Id = 5, ApplicationUserId = "8", BatchId = 5, CoursePrice = 450, DiscountValue = 10, Status = Discount.DiscountStatus.ACTIVE });

            // batch id = 7
            discounts.Add(new Discount() { Id = 6, ApplicationUserId = "4", BatchId = 7, CoursePrice = 400, DiscountValue = 10, Status = Discount.DiscountStatus.ACTIVE });
            discounts.Add(new Discount() { Id = 7, ApplicationUserId = "5", BatchId = 7, CoursePrice = 400, DiscountValue = 10, Status = Discount.DiscountStatus.ACTIVE });
            discounts.Add(new Discount() { Id = 8, ApplicationUserId = "6", BatchId = 7, CoursePrice = 400, DiscountValue = 10, Status = Discount.DiscountStatus.ACTIVE });

            // batch id = 8
            discounts.Add(new Discount() { Id = 9, ApplicationUserId = "9", BatchId = 8, CoursePrice = 400, DiscountValue = 15, Status = Discount.DiscountStatus.ACTIVE });
            discounts.Add(new Discount() { Id = 10, ApplicationUserId = "10", BatchId = 8, CoursePrice = 400, DiscountValue = 15, Status = Discount.DiscountStatus.ACTIVE });
            discounts.Add(new Discount() { Id = 11, ApplicationUserId = "11", BatchId = 8, CoursePrice = 400, DiscountValue = 15, Status = Discount.DiscountStatus.ACTIVE });
            discounts.Add(new Discount() { Id = 12, ApplicationUserId = "12", BatchId = 8, CoursePrice = 400, DiscountValue = 15, Status = Discount.DiscountStatus.ACTIVE });
            discounts.Add(new Discount() { Id = 13, ApplicationUserId = "13", BatchId = 8, CoursePrice = 400, DiscountValue = 15, Status = Discount.DiscountStatus.ACTIVE });

            // batch id = 10
            discounts.Add(new Discount() { Id = 14, ApplicationUserId = "9", BatchId = 10, CoursePrice = 400, DiscountValue = 15, Status = Discount.DiscountStatus.ACTIVE });
            discounts.Add(new Discount() { Id = 15, ApplicationUserId = "10", BatchId = 10, CoursePrice = 400, DiscountValue = 15, Status = Discount.DiscountStatus.ACTIVE });
            discounts.Add(new Discount() { Id = 16, ApplicationUserId = "11", BatchId = 10, CoursePrice = 400, DiscountValue = 15, Status = Discount.DiscountStatus.ACTIVE });
            discounts.Add(new Discount() { Id = 17, ApplicationUserId = "12", BatchId = 10, CoursePrice = 400, DiscountValue = 15, Status = Discount.DiscountStatus.ACTIVE });
            discounts.Add(new Discount() { Id = 18, ApplicationUserId = "13", BatchId = 10, CoursePrice = 400, DiscountValue = 15, Status = Discount.DiscountStatus.ACTIVE });

            // batch id = 11
            discounts.Add(new Discount() { Id = 19, ApplicationUserId = "4", BatchId = 11, CoursePrice = 450, DiscountValue = 20, Status = Discount.DiscountStatus.ACTIVE });
            discounts.Add(new Discount() { Id = 20, ApplicationUserId = "5", BatchId = 11, CoursePrice = 450, DiscountValue = 20, Status = Discount.DiscountStatus.ACTIVE });
            discounts.Add(new Discount() { Id = 21, ApplicationUserId = "6", BatchId = 11, CoursePrice = 450, DiscountValue = 20, Status = Discount.DiscountStatus.ACTIVE });
            discounts.Add(new Discount() { Id = 22, ApplicationUserId = "7", BatchId = 11, CoursePrice = 450, DiscountValue = 20, Status = Discount.DiscountStatus.ACTIVE });
            discounts.Add(new Discount() { Id = 23, ApplicationUserId = "8", BatchId = 11, CoursePrice = 450, DiscountValue = 20, Status = Discount.DiscountStatus.ACTIVE });

            // batch id = 12
            discounts.Add(new Discount() { Id = 24, ApplicationUserId = "9", BatchId = 12, CoursePrice = 450, DiscountValue = 10, Status = Discount.DiscountStatus.ACTIVE });
            discounts.Add(new Discount() { Id = 25, ApplicationUserId = "10", BatchId = 12, CoursePrice = 450, DiscountValue = 10, Status = Discount.DiscountStatus.ACTIVE });
            discounts.Add(new Discount() { Id = 26, ApplicationUserId = "11", BatchId = 12, CoursePrice = 450, DiscountValue = 10, Status = Discount.DiscountStatus.ACTIVE });
            discounts.Add(new Discount() { Id = 27, ApplicationUserId = "12", BatchId = 12, CoursePrice = 450, DiscountValue = 10, Status = Discount.DiscountStatus.ACTIVE });
            discounts.Add(new Discount() { Id = 28, ApplicationUserId = "13", BatchId = 12, CoursePrice = 450, DiscountValue = 10, Status = Discount.DiscountStatus.ACTIVE });

            // batch id = 13
            discounts.Add(new Discount() { Id = 29, ApplicationUserId = "4", BatchId = 13, CoursePrice = 450, DiscountValue = 15, Status = Discount.DiscountStatus.ACTIVE });
            discounts.Add(new Discount() { Id = 30, ApplicationUserId = "5", BatchId = 13, CoursePrice = 450, DiscountValue = 15, Status = Discount.DiscountStatus.ACTIVE });
            discounts.Add(new Discount() { Id = 31, ApplicationUserId = "6", BatchId = 13, CoursePrice = 450, DiscountValue = 15, Status = Discount.DiscountStatus.ACTIVE });
            discounts.Add(new Discount() { Id = 32, ApplicationUserId = "7", BatchId = 13, CoursePrice = 450, DiscountValue = 15, Status = Discount.DiscountStatus.ACTIVE });
            discounts.Add(new Discount() { Id = 33, ApplicationUserId = "8", BatchId = 13, CoursePrice = 450, DiscountValue = 15, Status = Discount.DiscountStatus.ACTIVE });

            // batch id = 15
            discounts.Add(new Discount() { Id = 34, ApplicationUserId = "4", BatchId = 15, CoursePrice = 450, DiscountValue = 10, Status = Discount.DiscountStatus.ACTIVE });
            discounts.Add(new Discount() { Id = 35, ApplicationUserId = "5", BatchId = 15, CoursePrice = 450, DiscountValue = 10, Status = Discount.DiscountStatus.ACTIVE });
            discounts.Add(new Discount() { Id = 36, ApplicationUserId = "6", BatchId = 15, CoursePrice = 450, DiscountValue = 10, Status = Discount.DiscountStatus.ACTIVE });
            discounts.Add(new Discount() { Id = 37, ApplicationUserId = "7", BatchId = 15, CoursePrice = 450, DiscountValue = 10, Status = Discount.DiscountStatus.ACTIVE });
            discounts.Add(new Discount() { Id = 38, ApplicationUserId = "8", BatchId = 15, CoursePrice = 450, DiscountValue = 10, Status = Discount.DiscountStatus.ACTIVE });

            // batch id = 17
            discounts.Add(new Discount() { Id = 39, ApplicationUserId = "4", BatchId = 17, CoursePrice = 400, DiscountValue = 20, Status = Discount.DiscountStatus.ACTIVE });
            discounts.Add(new Discount() { Id = 40, ApplicationUserId = "5", BatchId = 17, CoursePrice = 400, DiscountValue = 20, Status = Discount.DiscountStatus.ACTIVE });
            discounts.Add(new Discount() { Id = 41, ApplicationUserId = "6", BatchId = 17, CoursePrice = 400, DiscountValue = 20, Status = Discount.DiscountStatus.ACTIVE });
            discounts.Add(new Discount() { Id = 42, ApplicationUserId = "7", BatchId = 17, CoursePrice = 400, DiscountValue = 20, Status = Discount.DiscountStatus.ACTIVE });
            discounts.Add(new Discount() { Id = 43, ApplicationUserId = "8", BatchId = 17, CoursePrice = 400, DiscountValue = 20, Status = Discount.DiscountStatus.ACTIVE });

            context.Discounts.AddRange(discounts);

            // list certificate
            IList<Certificate> certificates = new List<Certificate>();

            // batch id = 1
            certificates.Add(new Certificate() { Id = 1, ApplicationUserId = "4", BatchId = 1, RegistrationDate = date.AddDays(-10), Note = null, Status = Certificate.CertificateStatus.PENDING });
            certificates.Add(new Certificate() { Id = 2, ApplicationUserId = "5", BatchId = 1, RegistrationDate = date.AddDays(-10), Note = null, Status = Certificate.CertificateStatus.PENDING });
            certificates.Add(new Certificate() { Id = 3, ApplicationUserId = "6", BatchId = 1, RegistrationDate = date.AddDays(-10), Note = null, Status = Certificate.CertificateStatus.PENDING });
            certificates.Add(new Certificate() { Id = 4, ApplicationUserId = "7", BatchId = 1, RegistrationDate = date.AddDays(-10), Note = null, Status = Certificate.CertificateStatus.PENDING });
            certificates.Add(new Certificate() { Id = 5, ApplicationUserId = "8", BatchId = 1, RegistrationDate = date.AddDays(-10), Note = null, Status = Certificate.CertificateStatus.PENDING });

            // batch id = 2
            certificates.Add(new Certificate() { Id = 6, ApplicationUserId = "9", BatchId = 2, RegistrationDate = date.AddDays(-9), Note = null, Status = Certificate.CertificateStatus.PENDING });
            certificates.Add(new Certificate() { Id = 7, ApplicationUserId = "10", BatchId = 2, RegistrationDate = date.AddDays(-9), Note = null, Status = Certificate.CertificateStatus.PENDING });
            certificates.Add(new Certificate() { Id = 8, ApplicationUserId = "11", BatchId = 2, RegistrationDate = date.AddDays(-9), Note = null, Status = Certificate.CertificateStatus.PENDING });
            certificates.Add(new Certificate() { Id = 9, ApplicationUserId = "12", BatchId = 2, RegistrationDate = date.AddDays(-9), Note = null, Status = Certificate.CertificateStatus.PENDING });
            certificates.Add(new Certificate() { Id = 10, ApplicationUserId = "13", BatchId = 2, RegistrationDate = date.AddDays(-9), Note = null, Status = Certificate.CertificateStatus.PENDING });

            // batch id = 3
            certificates.Add(new Certificate() { Id = 11, ApplicationUserId = "4", BatchId = 3, RegistrationDate = date.AddDays(-8), Note = null, Status = Certificate.CertificateStatus.PENDING });
            certificates.Add(new Certificate() { Id = 12, ApplicationUserId = "5", BatchId = 3, RegistrationDate = date.AddDays(-8), Note = null, Status = Certificate.CertificateStatus.PENDING });
            certificates.Add(new Certificate() { Id = 13, ApplicationUserId = "6", BatchId = 3, RegistrationDate = date.AddDays(-8), Note = null, Status = Certificate.CertificateStatus.PENDING });
            certificates.Add(new Certificate() { Id = 14, ApplicationUserId = "7", BatchId = 3, RegistrationDate = date.AddDays(-8), Note = null, Status = Certificate.CertificateStatus.PENDING });
            certificates.Add(new Certificate() { Id = 15, ApplicationUserId = "8", BatchId = 3, RegistrationDate = date.AddDays(-8), Note = null, Status = Certificate.CertificateStatus.PENDING });

            // batch id = 4
            certificates.Add(new Certificate() { Id = 16, ApplicationUserId = "9", BatchId = 4, RegistrationDate = date.AddDays(-7), Note = null, Status = Certificate.CertificateStatus.PENDING });
            certificates.Add(new Certificate() { Id = 17, ApplicationUserId = "10", BatchId = 4, RegistrationDate = date.AddDays(-7), Note = null, Status = Certificate.CertificateStatus.PENDING });
            certificates.Add(new Certificate() { Id = 18, ApplicationUserId = "11", BatchId = 4, RegistrationDate = date.AddDays(-7), Note = null, Status = Certificate.CertificateStatus.PENDING });
            certificates.Add(new Certificate() { Id = 19, ApplicationUserId = "12", BatchId = 4, RegistrationDate = date.AddDays(-7), Note = null, Status = Certificate.CertificateStatus.PENDING });
            certificates.Add(new Certificate() { Id = 20, ApplicationUserId = "13", BatchId = 4, RegistrationDate = date.AddDays(-7), Note = null, Status = Certificate.CertificateStatus.PENDING });

            // batch id = 5
            certificates.Add(new Certificate() { Id = 21, ApplicationUserId = "4", BatchId = 5, RegistrationDate = date.AddDays(-6), Note = null, Status = Certificate.CertificateStatus.PENDING });
            certificates.Add(new Certificate() { Id = 22, ApplicationUserId = "5", BatchId = 5, RegistrationDate = date.AddDays(-6), Note = null, Status = Certificate.CertificateStatus.PENDING });
            certificates.Add(new Certificate() { Id = 23, ApplicationUserId = "6", BatchId = 5, RegistrationDate = date.AddDays(-6), Note = null, Status = Certificate.CertificateStatus.PENDING });
            certificates.Add(new Certificate() { Id = 24, ApplicationUserId = "7", BatchId = 5, RegistrationDate = date.AddDays(-6), Note = null, Status = Certificate.CertificateStatus.PENDING });
            certificates.Add(new Certificate() { Id = 25, ApplicationUserId = "8", BatchId = 5, RegistrationDate = date.AddDays(-6), Note = null, Status = Certificate.CertificateStatus.PENDING });

            // batch id = 6
            certificates.Add(new Certificate() { Id = 26, ApplicationUserId = "9", BatchId = 6, RegistrationDate = date.AddDays(-5), Note = null, Status = Certificate.CertificateStatus.PENDING });
            certificates.Add(new Certificate() { Id = 27, ApplicationUserId = "10", BatchId = 6, RegistrationDate = date.AddDays(-5), Note = null, Status = Certificate.CertificateStatus.PENDING });
            certificates.Add(new Certificate() { Id = 28, ApplicationUserId = "11", BatchId = 6, RegistrationDate = date.AddDays(-5), Note = null, Status = Certificate.CertificateStatus.PENDING });
            certificates.Add(new Certificate() { Id = 29, ApplicationUserId = "12", BatchId = 6, RegistrationDate = date.AddDays(-5), Note = null, Status = Certificate.CertificateStatus.PENDING });
            certificates.Add(new Certificate() { Id = 30, ApplicationUserId = "13", BatchId = 6, RegistrationDate = date.AddDays(-5), Note = null, Status = Certificate.CertificateStatus.PENDING });

            // batch id = 7
            certificates.Add(new Certificate() { Id = 31, ApplicationUserId = "4", BatchId = 7, RegistrationDate = date.AddDays(-4), Note = null, Status = Certificate.CertificateStatus.PENDING });
            certificates.Add(new Certificate() { Id = 32, ApplicationUserId = "5", BatchId = 7, RegistrationDate = date.AddDays(-4), Note = null, Status = Certificate.CertificateStatus.PENDING });
            certificates.Add(new Certificate() { Id = 33, ApplicationUserId = "6", BatchId = 7, RegistrationDate = date.AddDays(-4), Note = null, Status = Certificate.CertificateStatus.PENDING });
            certificates.Add(new Certificate() { Id = 34, ApplicationUserId = "7", BatchId = 7, RegistrationDate = date.AddDays(-4), Note = null, Status = Certificate.CertificateStatus.PENDING });
            certificates.Add(new Certificate() { Id = 35, ApplicationUserId = "8", BatchId = 7, RegistrationDate = date.AddDays(-4), Note = null, Status = Certificate.CertificateStatus.PENDING });

            // batch id = 8
            certificates.Add(new Certificate() { Id = 36, ApplicationUserId = "9", BatchId = 8, RegistrationDate = date.AddDays(-3), Note = null, Status = Certificate.CertificateStatus.PENDING });
            certificates.Add(new Certificate() { Id = 37, ApplicationUserId = "10", BatchId = 8, RegistrationDate = date.AddDays(-3), Note = null, Status = Certificate.CertificateStatus.PENDING });
            certificates.Add(new Certificate() { Id = 38, ApplicationUserId = "11", BatchId = 8, RegistrationDate = date.AddDays(-3), Note = null, Status = Certificate.CertificateStatus.PENDING });
            certificates.Add(new Certificate() { Id = 39, ApplicationUserId = "12", BatchId = 8, RegistrationDate = date.AddDays(-3), Note = null, Status = Certificate.CertificateStatus.PENDING });
            certificates.Add(new Certificate() { Id = 40, ApplicationUserId = "13", BatchId = 8, RegistrationDate = date.AddDays(-3), Note = null, Status = Certificate.CertificateStatus.PENDING });

            // batch id = 9
            certificates.Add(new Certificate() { Id = 41, ApplicationUserId = "4", BatchId = 9, RegistrationDate = date.AddDays(-2), Note = null, Status = Certificate.CertificateStatus.PENDING });
            certificates.Add(new Certificate() { Id = 42, ApplicationUserId = "5", BatchId = 9, RegistrationDate = date.AddDays(-2), Note = null, Status = Certificate.CertificateStatus.PENDING });
            certificates.Add(new Certificate() { Id = 43, ApplicationUserId = "6", BatchId = 9, RegistrationDate = date.AddDays(-2), Note = null, Status = Certificate.CertificateStatus.PENDING });
            certificates.Add(new Certificate() { Id = 44, ApplicationUserId = "7", BatchId = 9, RegistrationDate = date.AddDays(-2), Note = null, Status = Certificate.CertificateStatus.PENDING });
            certificates.Add(new Certificate() { Id = 45, ApplicationUserId = "8", BatchId = 9, RegistrationDate = date.AddDays(-2), Note = null, Status = Certificate.CertificateStatus.PENDING });

            // batch id = 10
            certificates.Add(new Certificate() { Id = 46, ApplicationUserId = "9", BatchId = 10, RegistrationDate = date.AddDays(-1), Note = null, Status = Certificate.CertificateStatus.PENDING });
            certificates.Add(new Certificate() { Id = 47, ApplicationUserId = "10", BatchId = 10, RegistrationDate = date.AddDays(-1), Note = null, Status = Certificate.CertificateStatus.PENDING });
            certificates.Add(new Certificate() { Id = 48, ApplicationUserId = "11", BatchId = 10, RegistrationDate = date.AddDays(-1), Note = null, Status = Certificate.CertificateStatus.PENDING });
            certificates.Add(new Certificate() { Id = 49, ApplicationUserId = "12", BatchId = 10, RegistrationDate = date.AddDays(-1), Note = null, Status = Certificate.CertificateStatus.PENDING });
            certificates.Add(new Certificate() { Id = 50, ApplicationUserId = "13", BatchId = 10, RegistrationDate = date.AddDays(-1), Note = null, Status = Certificate.CertificateStatus.PENDING });

            // batch id = 11
            certificates.Add(new Certificate() { Id = 51, ApplicationUserId = "4", BatchId = 11, RegistrationDate = date.AddDays(0), Note = null, Status = Certificate.CertificateStatus.PENDING });
            certificates.Add(new Certificate() { Id = 52, ApplicationUserId = "5", BatchId = 11, RegistrationDate = date.AddDays(0), Note = null, Status = Certificate.CertificateStatus.PENDING });
            certificates.Add(new Certificate() { Id = 53, ApplicationUserId = "6", BatchId = 11, RegistrationDate = date.AddDays(0), Note = null, Status = Certificate.CertificateStatus.PENDING });
            certificates.Add(new Certificate() { Id = 54, ApplicationUserId = "7", BatchId = 11, RegistrationDate = date.AddDays(0), Note = null, Status = Certificate.CertificateStatus.PENDING });
            certificates.Add(new Certificate() { Id = 55, ApplicationUserId = "8", BatchId = 11, RegistrationDate = date.AddDays(0), Note = null, Status = Certificate.CertificateStatus.PENDING });

            context.Certificates.AddRange(certificates);

            // list feedback
            IList<Feedback> feedbacks = new List<Feedback>();

            feedbacks.Add(new Feedback() { Id = 1, FbEmail = "phuonganh01@gmail.com", FbPhone = "0984288003", FbName = "Phuong Anh", Type = Feedback.FeedbackType.REGISTER , Content = "Sign up for a web programming course", Note = null, Status = Feedback.FeedbackStatus.PENDING });
            feedbacks.Add(new Feedback() { Id = 2, FbEmail = "lathanh@gmail.com", FbPhone = "0923123412", FbName = "La Thanh", Type = Feedback.FeedbackType.REGISTER , Content = "Sign up for a mobile programming course", Note = null, Status = Feedback.FeedbackStatus.PENDING });
            feedbacks.Add(new Feedback() { Id = 3, FbEmail = "chithien@gmail.com", FbPhone = "0987123654", FbName = "Chi Thien", Type = Feedback.FeedbackType.DETAIL , Content = "Consulting .NET course", Note = null, Status = Feedback.FeedbackStatus.PENDING });
            feedbacks.Add(new Feedback() { Id = 4, FbEmail = "dantruong@gmail.com", FbPhone = "0984213123", FbName = "Dan Truong", Type = Feedback.FeedbackType.DETAIL , Content = "Consulting .NET course", Note = null, Status = Feedback.FeedbackStatus.PENDING });
            feedbacks.Add(new Feedback() { Id = 5, FbEmail = "tuelam@gmail.com", FbPhone = "0213436123", FbName = "Tue Lam", Type = Feedback.FeedbackType.REGISTER , Content = "Sign up for a web programming course", Note = null, Status = Feedback.FeedbackStatus.PENDING });
            feedbacks.Add(new Feedback() { Id = 6, FbEmail = "hoavinh0110@gmail.com", FbPhone = "0984288123", FbName = "Hoa Vinh", Type = Feedback.FeedbackType.REGISTER , Content = "Sign up for a web programming course", Note = null, Status = Feedback.FeedbackStatus.PENDING });
            feedbacks.Add(new Feedback() { Id = 7, FbEmail = "damvinhhung@gmail.com", FbPhone = "0881234123", FbName = "Dam Vinh Hung", Type = Feedback.FeedbackType.REGISTER , Content = "Sign up for a web programming course", Note = null, Status = Feedback.FeedbackStatus.PENDING });
            feedbacks.Add(new Feedback() { Id = 8, FbEmail = "tolam@gmail.com", FbPhone = "0962337711", FbName = "To Lam", Type = Feedback.FeedbackType.DETAIL , Content = "Consulting Java Spring Boot course", Note = null, Status = Feedback.FeedbackStatus.DONE });
            feedbacks.Add(new Feedback() { Id = 9, FbEmail = "lamchithien@gmail.com", FbPhone = "0123987678", FbName = "Lam Chi Thien", Type = Feedback.FeedbackType.DETAIL , Content = "Consulting PHP Laravel course", Note = null, Status = Feedback.FeedbackStatus.DONE });
            feedbacks.Add(new Feedback() { Id = 10, FbEmail = "kienphu@gmail.com", FbPhone = "0881231239", FbName = "Kien Phu", Type = Feedback.FeedbackType.REGISTER , Content = "Sign up for a mobile programming course", Note = null, Status = Feedback.FeedbackStatus.DONE });
            feedbacks.Add(new Feedback() { Id = 11, FbEmail = "hoavy@gmail.com", FbPhone = "0976123512", FbName = "Hoa Vy", Type = Feedback.FeedbackType.DETAIL , Content = "Consulting NodeJS course", Note = null, Status = Feedback.FeedbackStatus.DONE });
            feedbacks.Add(new Feedback() { Id = 12, FbEmail = "truongthanh@gmail.com", FbPhone = "0123612345", FbName = "Truong Thanh", Type = Feedback.FeedbackType.DETAIL , Content = "Consulting PHP Laravel course", Note = null, Status = Feedback.FeedbackStatus.DONE });

            context.Feedbacks.AddRange(feedbacks);

            base.Seed(context);
        }
    }
}

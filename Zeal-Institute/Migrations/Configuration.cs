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

            context.Users.AddOrUpdate(new ApplicationUser() { Id = "1", FullName = "Admin", Email = "admin@gmail.com", UserName = "admin@gmail.com", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Admin", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0987654321", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "Admin", CreatedAt = DateTime.Now });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "2", FullName = "Hong Hanh", Email = "honghanh@gmail.com", UserName = "hongluyen@gmail.com", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Giao Vu", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0966123123", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "2", RollNumber = "MSG1", CreatedAt = DateTime.Now });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "3", FullName = "Dao Hong Luyen", Email = "hongluyen@gmail.com", UserName = "ongluyeh@gmail.com", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Giao Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0958567567", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "GV1", CreatedAt = DateTime.Now });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "4", FullName = "La Phuong", Email = "laphuong@gmail.com", UserName = "laphuong@gmail.com", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0983454545", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00631", CreatedAt = DateTime.Now });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "5", FullName = "Van Hien", Email = "vanhien@gmail.com", UserName = "vanhien@gmail.com", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0962336611", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00632", CreatedAt = DateTime.Now });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "6", FullName = "Dinh Nam", Email = "dinhnam@gmail.com", UserName = "dinhnam@gmail.com", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0988712312", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00633", CreatedAt = DateTime.Now });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "7", FullName = "Van Quy", Email = "vanquy@gmail.com", UserName = "vanquy@gmail.com", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0881231230", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00634", CreatedAt = DateTime.Now });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "8", FullName = "Duc Tung", Email = "ductung@gmail.com", UserName = "ductung@gmail.com", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0234123987", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00635", CreatedAt = DateTime.Now });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "9", FullName = "Huy Cuong", Email = "huycuong@gmail.com", UserName = "huycuong@gmail.com", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0123567345", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00636", CreatedAt = DateTime.Now });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "10", FullName = "Van Loi", Email = "vanloi@gmail.com", UserName = "vanloi@gmail.com", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0912381234", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00637", CreatedAt = DateTime.Now });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "11", FullName = "Le Vinh", Email = "levinh@gmail.com", UserName = "levinh@gmail.com", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0912309876", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00638", CreatedAt = DateTime.Now });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "12", FullName = "Duy Phuong", Email = "duyphuong@gmail.com", UserName = "duyphuong@gmail.com", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0912312394", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00639", CreatedAt = DateTime.Now });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "13", FullName = "Kim Nghi", Email = "kimnghi@gmail.com", UserName = "kimnghi@gmail.com", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0988199612", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00640", CreatedAt = DateTime.Now });
            
            
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

            courses.Add(new Course() { 
                Id = 1,
                Name = "ASP .Net Mvc", 
                Thumbnail = "https://res.cloudinary.com/phuonglvd00631fptaptech/image/upload/v1617569229/samples/ZealProject/asp-net-mvc_bczbht.png", 
                Code = "ASPNETMCV", 
                Price = 400, 
                Description = "Design Website with Asp .Net Mvc 5", 
                IntroCourse = "<h2>Description</h2><p> Learn Web Development with one of the most upcoming framework for Microsoft which is ASP.NET MVC using C#.ASP.NET MVC is most common requirement now when you are looking for a new job in.NET world and with this course you will have the knowledge that is needed for the same.</p><p>I have designed this course by taking in picture anyone who has been working with ASP.NET&nbsp;C#&nbsp;, but they think its time to learn the most upcoming trend which is ASP.NET&nbsp;MVC.&nbsp;This course will help you get a solid understanding of the basic building blocks of MVC&nbsp;and you will also take a look at some advance topics in MVC&nbsp;as we build Book Rental application from scratch</p><p>The key to success is practice and that is what you would be doing over and over as you would write controllers, actions and view from scratch and work your&nbsp;way to success, while doing so you would get solid understanding of the flow of MVC&nbsp;along with other concepts.</p><p>So jump right in to kick start your career in ASP.NET&nbsp;MVC&nbsp;or to take your career to next level!<br/></p><h2>Who this course is for:</h2><ul><li>Anyone who is willing to learn .NET MVC using C#</li><li>Anyone who wants to take their existing MVC skills to next level by building a complete application</li></ul>",
                Status = Course.CourseStatus.ACTIVE });
            courses.Add(new Course() { 
                Id = 2, 
                Name = "Swift IOS",
                Thumbnail = "https://res.cloudinary.com/phuonglvd00631fptaptech/image/upload/v1617569372/samples/ZealProject/swift_nvy0tm.png", Code = "SWIFT", Price = 450, 
                Description = "Became iOS App Developer with Just One Course", 
                IntroCourse = "<h2>Description</h2><b>Important notice before you enroll in this masterclass!</b><p>Creating a 50+ hour course with high-quality production value takes a lot of time. I don't want to keep you waiting, so I have decided to release the first half of the content before I finish publishing the remaining lectures.</p><p>The 2021 edition of this SwiftUI Masterclass course is already more than 25+ hours long and it will be much longer by the end of this year.</p><p>Each month I release a new exciting and practical project about how to build an iOS 14, a macOS, even a watchOS application from scratch, or other useful learning material about app development in Swift 5+ programming language.</p><h2>Why should you take this iOS 14 course?</h2><p>Visually learn SwiftUI 2 and build top-notch iOS 14, iPadOS mobile apps, Apple Watch apps, and even macOS desktop applications. This complete iOS application development course with the latest SwiftUI is designed to teach you how to become an advanced iOS and macOS app developer using Apple's native user interface framework: SwiftUI.</p>",
                Status = Course.CourseStatus.ACTIVE });
            courses.Add(new Course() { 
                Id = 3, 
                Name = "Node Js", 
                Thumbnail = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTD0W3nhKa6JLPyIThAkBTv13I6DE98Oo5NRw&usqp=CAU", 
                Code = "NODEJS", 
                Price = 400, 
                Description = "Learn Node.js, runtime environment, from the pros", 
                IntroCourse = "<h2><b>Description</b></h2><p>Do you want to build fast and powerful back-end applications with JavaScript? Would you like to become a more complete and in-demand developer?</p><p>Then Node.js is the hot technology for you to learn right now, and you came to the right place to do it!</p><p>Welcome to the Complete Node.js, Express, and MongoDB Bootcamp, your fast track to modern back-end development.</p><p>This course is the perfect all-in-one package that will take you from a complete beginner to an advanced, highly-skilled Node.js developer.</p><p>Like all my other courses, this one is completely project-based! And not just any project: it's a complete, beautiful, and feature-rich application, containing both a RESTful API and a server-side rendered website. It's the most fantastic and complete project that you will find in any Node.js course on the internet!</p><p>By building this huge project, you will learn all the skills that you need in order to plan, build, and deploy your own modern back-end applications with Node.js and related technologies.</p><p>(If you feel like exploring the project, you can do so at www.natours.dev. And this is only a small part of the project! Log in with laura@example.com and password test1234</p><h2><b>After finishing this course, you will:</b></h2><p>1) Be building you own fast, scalable, and powerful Node.js RESTful APIs or web applications;</p><p>2) Truly understand how Node.js works behind the scenes;</p><p>3) Be able to work with NoSQL data and model data in real-world situations (a hugely important skill);</p><p>4) Know how modern back-end development works, and how all the different technologies fit together (hard to understand from scattered tutorials and videos);</p><p>5) Have experience in professionally-used tools and libraries like Express, Mongoose, Stripe, Sendgrid, Atlas, Compass, Git, Heroku, and many more;</p><p>6) Have built a complete application, which is a perfect starting point for your own applications in the future.</p><p>Please note that this course is NOT for absolute web development beginners, so you should already be familiar with basic JavaScript. NO back-end experience required though!</p>",
                Status = Course.CourseStatus.ACTIVE });
            courses.Add(new Course() { 
                Id = 4, 
                Name = "Java Spring Boot", 
                Thumbnail = "https://i.ytimg.com/vi/vtPkZShrvXQ/maxresdefault.jpg", 
                Code = "JAVAWEB", Price = 450,
                Description = "Creating Your First Spring Boot Application", 
                IntroCourse = "<h2><b>Description</b></h2><p>There is no doubt that having Spring Framework skills on your résumé will make you a more employable Java developer.</p><p>Spring developers are in high demand and are paid handsomely.  However, the framework is huge.  That’s because it consists of lots of modules and projects.  Learning it can take you months.  You will often find that a Java Spring tutorial or training course will focus on parts of the framework that don’t get used that much.</p><h2><b>What skills do you need to take the course?</b></h2><p>This course is for anyone who wants to get into Spring framework programming.  We assume you have never used Spring previously.</p><p>Any Java Enterprise edition (Java EE) technology requires you to know at least some Java programming. That’s because Java EE is built on top of the Java Standard Edition (Java SE).  That’s the regular Java language.</p><p>The Spring Framework is built on top of Java EE, and thus you need to have some basic Java programming skills to be able to go through this course.</p><p>If you’ve been through at least some of the Java Masterclass on Udemy (created by one of the instructors in this course) or similar Java training, then you will have no problem going through the course.</p>",
                Status = Course.CourseStatus.ACTIVE });
            courses.Add(new Course() { 
                Id = 5, 
                Name = "Kotlin Android", 
                Thumbnail = "https://i.ytimg.com/vi/Iz08OTTjR04/maxresdefault.jpg", 
                Code = "KOTLIN", Price = 450, 
                Description = "Building Android apps with the Kotlin programming language", 
                IntroCourse = "<h2><b>Description</b></h2><p>What do you get in this course?</p><p>In this course, you will discover the power of Android app development, and obtain the skills to dramatically increase your career prospects as a software developer. You’ll also have a head start over other developers using obsolete tools and earlier versions of Android.</p><h2><b>This is what you’ll learn in the course:</b></h2><p>Develop apps for the very latest version of Android that also work on older Android devices running older versions of the Android operating system.</p><p>Download, install and configure the necessary (free) software.</p><p>Create your first app.</p><p>Build a range of apps demonstrating key aspects of the Android framework.</p><p>Test your apps on emulators or a real Android phone or tablet.</p><p>You’ll learn Kotlin programming because Google are recommending and pushing adoption of Kotlin for Android app development.  Included are Kotlin tutorial videos that will get you up to speed fast.</p><p>Ensure your apps work with current and older Android versions on phones and tablets.</p><p>Use Android studio 3.2, the newest version of Google's premier Android tool.</p><p>Learn how to use databases, web services, and even get your apps to speak!</p><p>Understand the all new Constraint layout, for drag and drop screen creation.</p><p>Use powerful libraries of code </p>",
                Status = Course.CourseStatus.ACTIVE });
            courses.Add(new Course() { 
                Id = 6, 
                Name = "HTML&CSS JS", 
                Thumbnail = "https://viblo.asia/uploads/3fc1e5e8-1263-4d3a-bab9-cfe7050ef9fd.jpeg", 
                Code = "HTMLCSS", Price = 250,
                Description = "Introduction Web Design with HTML, CSS, JS", 
                IntroCourse = "<h2><b>Description</b></h2><p>COMPLETELY REDONE ON OCTOBER 12th 2020, WITH OVER 500 BRAND NEW VIDEOS!</p><p>Hi! Welcome to the brand new version of The Web Developer Bootcamp, Udemy's most popular web development course.  This course was just completely overhauled to prepare students for the 2021 job market, with over 60 hours of brand new content. This is the only course you need to learn web development. There are a lot of options for online developer training, but this course is without a doubt the most comprehensive and effective on the market.</p><h2><p>Who this course is for:</p></h2><p>This course is for anyone who wants to learn about web development, regardless of previous experience</p><p>It's perfect for complete beginners with zero experience</p><p>It's also great for anyone who does have some experience in a few of the technologies(like HTML and CSS) but not all</p><p>If you want to take ONE COURSE to learn everything you need to know about web development, take this course</p>",
                Status = Course.CourseStatus.ACTIVE });
            courses.Add(new Course() { 
                Id = 7, 
                Name = "PHP Laravel", 
                Thumbnail = "https://i.ytimg.com/vi/EcYXsp78Xy8/mqdefault.jpg", 
                Code = "PHPL", Price = 350, 
                Description = "PHP with Laravel for beginners - Become a Master in Laravel", 
                IntroCourse = "<h2><b>Description</b></h2><p>Learn php 7 the latest version of one of the most popular web programming languages and not only that but also the best full stack framework. Go from beginner to pro in just a few hours. This course is made for those that wish to get a job as soon as possible (ASAP). Learn the skills to help you on your journey as web developer with all of todays best practices. Build real projects that you can add in your portfolio.</p><h2><b>Who this course is for:</b></h2><p>Junior Developers</p><p>Mid Developers</p><p>Senior Developers</p>",
                Status = Course.CourseStatus.ACTIVE });
            courses.Add(new Course(){
                Id = 8,
                Name = "Database Sql Server",
                Thumbnail = "https://phanmemgoc.vn/wp-content/uploads/2020/04/Sql-server.png",
                Code = "SQLSERVER",
                Price = 500,
                Description = "SQL for Beginners with Microsoft SQL Server Database",
                IntroCourse = "<h2><b>Description</b></h2><p>Data is a every where. SQL is a skill that is required across industries, functions and roles. . Application of Big Data starts with understanding the fundamentals of data and SQL.</p><p>If you are already familiar with SQL then you can skip this course. This course teaches you all the SQL you need start using it with confidence  This course won't go into advanced level SQL concepts. I strongly believe in short and simple courses that can get you ready in few hours as opposed to days.</p><h2><b>What you'll learn</b></h2><p>Database fundamentals</p><p>Database Structure</p><p>How to restore a backup database</p><p>Write SQL queries with confidence</p><p>Select the data from tables</p><p>Join multiple tables</p><p>Insert records into the database</p><p>Delete records</p><p>Create outer joins</p><p>Manipulate selected data with SQL functions</p><p>Import and Export data from SQL Server</p>",
                Status = Course.CourseStatus.ACTIVE
            });
            courses.Add(new Course()
            {
                Id = 9,
                Name = "Python",
                Thumbnail = "https://st.quantrimang.com/photos/image/2020/10/30/nhung-thay-doi-trong-python-moi-nhat-size-696x364-znd.jpg",
                Code = "PYTHON",
                Price = 400,
                Description = "Complete Python Developer in 2021: Zero to Mastery",
                IntroCourse = "<h2><b>Description</b></h2><p>Become a modern and complete Python developer! Join a live online community of over 400,000+ developers and a course taught by an industry expert that has actually worked both in Silicon Valley and Toronto. This is a brand new Python course just launched this year (updated this month)! Graduates of Andrei’s courses are now working at Google, Tesla, Amazon, Apple, IBM, JP Morgan, Facebook, + other top tech companies.</p><h2><b>What you'll learn</b></h2><p>Become a professional Python Developer and get hired</p><p>Master modern Python 3.9(latest) fundamentals as well as advanced topics</p><p>Learn Object Oriented Programming</p><p>Learn Function Programming</p><p>Build 12+ real world Python projects you can show off</p><p>Learn how to use Python in Web Development</p><p>Learn Machine Learning with Python</p><p>Build a Machine Learning Model</p><p>Learn Data Science - Analyze and Visualize Data</p><p>Build a professional Portfolio Website</p><p>Use Python to process: Images, CSVs, PDFs, and other Files</p><p>Build a Web Scraper with Python and BeautifulSoup</p>",
                Status = Course.CourseStatus.ACTIVE
            });
            courses.Add(new Course()
            {
                Id = 10,
                Name = "Flutter",
                Code = "FLU",
                Thumbnail = "https://www.signitysolutions.com/blog/wp-content/uploads/2020/04/Flutter-app-development-signity-solutions-1024x512.png",
                Price = 400,
                Description = "Flutter Artificial Intelligence Course - Build 15+ AI Apps",
                IntroCourse = "<h2><b>Description</b></h2><p>In this course you will learn how to make your own Artificial Intelligence Apps using Flutter (Android+iOS) with TensorFlow Lite.</p><p>We will develop 15+ AI Apps with Flutter using TensorFlow Machine Learning and Deep Learning Concepts. In this course you will also learn how to train a model/machine for your apps. And how to import and use these trained models after training in your flutter app (android+iOS app).</p><p>This is a complete step by step course. At the end of this course you will be able to make your own Ai, Deep Learning and Machine Learning Apps for the Android Smart Phones and iOS [iPhones] using Flutter SDK with TensorFlow Lite.</p><h2><b>What you'll learn</b></h2><p>Flutter Deep Learning</p><p>Flutter Machine Learning</p><p>Flutter Artificial Intelligence</p><p>Skills and Techniques to develop any Artificial Intelligence idea into a mobile phone app</p><p>Implementing (NLP) Natural Language Processing Algorithm for Mobile Apps Development</p><p>Implementing (CNN) Convolutional Neural Network for Mobile Apps Development</p><p>Optical Character Recognition</p><p>Understanding of Different Types of Neural Networks & How you can use them</p><p>you will learn and make 15+ Ai Apps</p><p>and Much more.</p>",
                Status = Course.CourseStatus.ACTIVE
            });
            courses.Add(new Course()
            {
                Id = 11,
                Name = "Ruby",
                Code = "RUBY",
                Thumbnail = "https://timviec365.vn/pictures/images/neu-ai-do-hoi-ban-ve-ruby-on-rails.jpeg",
                Price = 350,
                Description = "Learn Ruby and Ruby on Rails 5 - the perfect starter course",
                IntroCourse = "<h2><b>Description</b></h2><p>The Ruby and Ruby on Rails Starter Course, completely re-designed and upgraded in November 2017, provides a simple introduction to programming using Ruby and to Web Applications Development using the Rails framework (Rails 5, but can be applied to Rails 4 as well). This course is for students who have no prior experience in programming and is an optional pre-course to The Complete Ruby on Rails Developer or The Professional Ruby on Rails Developer with Rails 5 courses here on Udemy.</p><p>Why Ruby on Rails? Since its introduction, Ruby on Rails has rapidly become one of the most powerful tools for building web applications for startups and existing software houses. Some of the top sites using Ruby on Rails are Basecamp, Twitter, Shopify, Github, LivingSocial, Groupon, Hulu, Airbnb, Yellow Pages and much more.</p><p>This course provides a structured introduction to programming, with varied data structures as simple mini projects as developed moving on to Rails where a Todo web app project is developed. It utilizes video and text lectures, homework and exercises. There will also be references to free resources available on the internet to supplement the course materials.</p><h2><b>What you'll learn</b></h2><p>Build basic Rails applications</p><p>Learn MVC structure and put it to action</p><p>Take the first step towards becoming a Rails developer</p><p>Learn basics of Ruby programming language</p>",
                Status = Course.CourseStatus.ACTIVE
            });
            courses.Add(new Course()
            {
                Id = 12,
                Name = "Data Structures&Algorithms",
                Code = "DSA",
                Thumbnail = "https://fsoft-academy.edu.vn/public/uploads/images/Learning-Data-Structures-and-Algorithms-is-Important1-1024x424.png",
                Price = 600,
                Description = "Master the Coding Interview: Data Structures + Algorithms",
                IntroCourse = "<h2><b>Description</b></h2><p>Want to land a job at a great tech company like Google, Microsoft, Facebook, Netflix, Amazon, or other companies but you are intimidated by the interview process and the coding questions? Do you find yourself feeling like you get stuck every time you get asked a coding question? This course is your answer. Using the strategies, lessons, and exercises in this course, you will learn how to land offers from all sorts of companies.</p><p>Many developers who are self taught, feel that one of the main disadvantages they face compared to college educated graduates in computer science is the fact that they don't have knowledge about algorithms, data structures and the notorious Big-O Notation. Get on the same level as someone with computer science degree by learning the fundamental building blocks of computer science which will give you a big boost during interviews.</p><h2><b>What you'll learn</b></h2><p>Ace coding interviews given by some of the top tech companies</p><p>Become more confident and prepared for your next coding interview</p><p>Learn, implement, and use different Data Structures</p><p>Learn, implement and use different Algorithms</p><p>Get more interviews</p><p>Professionally handle offers and negotiate raises</p><p>Become a better developer by mastering computer science fundamentals</p>",
                Status = Course.CourseStatus.ACTIVE
            });
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
            examDetails.Add(new ExamDetail() { ExamId = 3, ApplicationUserId = "4", Mark = 80, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 3, ApplicationUserId = "5", Mark = 75, Note = null });
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

            //// batch id = 1
            //certificates.Add(new Certificate() { Id = 1, ApplicationUserId = "4", BatchId = 1, RegistrationDate = date.AddDays(-10), Note = null, Status = Certificate.CertificateStatus.PENDING });
            //certificates.Add(new Certificate() { Id = 2, ApplicationUserId = "5", BatchId = 1, RegistrationDate = date.AddDays(-10), Note = null, Status = Certificate.CertificateStatus.PENDING });
            //certificates.Add(new Certificate() { Id = 3, ApplicationUserId = "6", BatchId = 1, RegistrationDate = date.AddDays(-10), Note = null, Status = Certificate.CertificateStatus.PENDING });
            //certificates.Add(new Certificate() { Id = 4, ApplicationUserId = "7", BatchId = 1, RegistrationDate = date.AddDays(-10), Note = null, Status = Certificate.CertificateStatus.PENDING });
            //certificates.Add(new Certificate() { Id = 5, ApplicationUserId = "8", BatchId = 1, RegistrationDate = date.AddDays(-10), Note = null, Status = Certificate.CertificateStatus.PENDING });

            //// batch id = 2
            //certificates.Add(new Certificate() { Id = 6, ApplicationUserId = "9", BatchId = 2, RegistrationDate = date.AddDays(-9), Note = null, Status = Certificate.CertificateStatus.PENDING });
            //certificates.Add(new Certificate() { Id = 7, ApplicationUserId = "10", BatchId = 2, RegistrationDate = date.AddDays(-9), Note = null, Status = Certificate.CertificateStatus.PENDING });
            //certificates.Add(new Certificate() { Id = 8, ApplicationUserId = "11", BatchId = 2, RegistrationDate = date.AddDays(-9), Note = null, Status = Certificate.CertificateStatus.PENDING });
            //certificates.Add(new Certificate() { Id = 9, ApplicationUserId = "12", BatchId = 2, RegistrationDate = date.AddDays(-9), Note = null, Status = Certificate.CertificateStatus.PENDING });
            //certificates.Add(new Certificate() { Id = 10, ApplicationUserId = "13", BatchId = 2, RegistrationDate = date.AddDays(-9), Note = null, Status = Certificate.CertificateStatus.PENDING });

            //// batch id = 3
            //certificates.Add(new Certificate() { Id = 11, ApplicationUserId = "4", BatchId = 3, RegistrationDate = date.AddDays(-8), Note = null, Status = Certificate.CertificateStatus.PENDING });
            //certificates.Add(new Certificate() { Id = 12, ApplicationUserId = "5", BatchId = 3, RegistrationDate = date.AddDays(-8), Note = null, Status = Certificate.CertificateStatus.PENDING });
            //certificates.Add(new Certificate() { Id = 13, ApplicationUserId = "6", BatchId = 3, RegistrationDate = date.AddDays(-8), Note = null, Status = Certificate.CertificateStatus.PENDING });
            //certificates.Add(new Certificate() { Id = 14, ApplicationUserId = "7", BatchId = 3, RegistrationDate = date.AddDays(-8), Note = null, Status = Certificate.CertificateStatus.PENDING });
            //certificates.Add(new Certificate() { Id = 15, ApplicationUserId = "8", BatchId = 3, RegistrationDate = date.AddDays(-8), Note = null, Status = Certificate.CertificateStatus.PENDING });

            //// batch id = 4
            //certificates.Add(new Certificate() { Id = 16, ApplicationUserId = "9", BatchId = 4, RegistrationDate = date.AddDays(-7), Note = null, Status = Certificate.CertificateStatus.PENDING });
            //certificates.Add(new Certificate() { Id = 17, ApplicationUserId = "10", BatchId = 4, RegistrationDate = date.AddDays(-7), Note = null, Status = Certificate.CertificateStatus.PENDING });
            //certificates.Add(new Certificate() { Id = 18, ApplicationUserId = "11", BatchId = 4, RegistrationDate = date.AddDays(-7), Note = null, Status = Certificate.CertificateStatus.PENDING });
            //certificates.Add(new Certificate() { Id = 19, ApplicationUserId = "12", BatchId = 4, RegistrationDate = date.AddDays(-7), Note = null, Status = Certificate.CertificateStatus.PENDING });
            //certificates.Add(new Certificate() { Id = 20, ApplicationUserId = "13", BatchId = 4, RegistrationDate = date.AddDays(-7), Note = null, Status = Certificate.CertificateStatus.PENDING });

            // batch id = 5
            certificates.Add(new Certificate() { Id = 21, ApplicationUserId = "4", BatchId = 5, RegistrationDate = date.AddDays(-6), Note = null, Status = Certificate.CertificateStatus.DONE, ReceivedDate = date.AddDays(5) });
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
            certificates.Add(new Certificate() { Id = 31, ApplicationUserId = "4", BatchId = 7, RegistrationDate = date.AddDays(-4), Note = null, Status = Certificate.CertificateStatus.DONE, ReceivedDate = date.AddDays(5) });
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

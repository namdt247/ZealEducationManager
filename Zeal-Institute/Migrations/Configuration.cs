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

            context.Users.AddOrUpdate(new ApplicationUser() { Id = "1", FullName = "Admin", Email = "admin@gmail.com", UserName = "admin@gmail.com", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Admin", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = null, PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "Admin", CreatedAt = DateTime.Now });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "2", FullName = "Hong Hanh", Email = "honghanh@gmail.com", UserName = "honghanh@gmail.com", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Giao Vu", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = null, PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "2", RollNumber = "MSG1", CreatedAt = DateTime.Now });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "3", FullName = "Dao Hong Luyen", Email = "hongluyenh@gmail.com", UserName = "hongluyen@gmail.com", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Giao Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = null, PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "GV1", CreatedAt = DateTime.Now });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "4", FullName = "La Phuong", Email = "laphuong@gmail.com", UserName = "laphuong@gmail.com", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = null, PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00631", CreatedAt = DateTime.Now });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "5", FullName = "Van Hien", Email = "vanhien@gmail.com", UserName = "vanhien@gmail.com", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = null, PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00632", CreatedAt = DateTime.Now });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "6", FullName = "Dinh Nam", Email = "dinhnam@gmail.com", UserName = "dinhnam@gmail.com", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = null, PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00633", CreatedAt = DateTime.Now });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "7", FullName = "Van Quy", Email = "vanquy@gmail.com", UserName = "vanquy@gmail.com", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = null, PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00634", CreatedAt = DateTime.Now });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "8", FullName = "Duc Tung", Email = "ductung@gmail.com", UserName = "ductung@gmail.com", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = null, PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00635", CreatedAt = DateTime.Now });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "9", FullName = "Huy Cuong", Email = "huycuong@gmail.com", UserName = "huycuong@gmail.com", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = null, PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00636", CreatedAt = DateTime.Now });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "10", FullName = "Van Loi", Email = "vanloi@gmail.com", UserName = "vanloi@gmail.com", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = null, PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00637", CreatedAt = DateTime.Now });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "11", FullName = "Le Vinh", Email = "levinh@gmail.com", UserName = "levinh@gmail.com", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = null, PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00638", CreatedAt = DateTime.Now });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "12", FullName = "Duy Phuong", Email = "duyphuong@gmail.com", UserName = "duyphuong@gmail.com", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = null, PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00639", CreatedAt = DateTime.Now });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "13", FullName = "Kim Nghi", Email = "kimnghi@gmail.com", UserName = "kimnghi@gmail.com", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = null, PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00640", CreatedAt = DateTime.Now });

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
            payments.Add(new Payment() { Id = 34, ApplicationUserId = "7", BatchId = 7, AmountPayable = 400, AmountPaid = 360, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(-16), Note = null, Status = Payment.PaymentStatus.ACTIVE });
            payments.Add(new Payment() { Id = 35, ApplicationUserId = "8", BatchId = 7, AmountPayable = 400, AmountPaid = 360, Type = Payment.PaymentType.FEE, PayDate = date.AddDays(-16), Note = null, Status = Payment.PaymentStatus.ACTIVE });

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

            base.Seed(context);
        }
    }
}

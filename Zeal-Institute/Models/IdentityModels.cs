using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Zeal_Institute.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [StringLength(255)]
        [Required]
        public string FullName { get; set; }

        [StringLength(255)]
        [Required]
        public string RollNumber { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        [StringLength(255)]
        public string Avatar { get; set; }

        public string Description { get; set; }

        private DateTime temp = DateTime.Now;
        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("Create At")]
        public DateTime CreatedAt
        {
            get
            {
                return temp;
            }
            set
            {
                if (temp == null)
                {
                    temp = DateTime.Now;
                }
                else
                {
                    temp = value;
                }
            }
        }

        public virtual ICollection<Exam> Exams { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<Discount> Discounts { get; set; }
        public virtual ICollection<Certificate> Certificates { get; set; }
        public virtual ICollection<Reminder> Reminders { get; set; }

        public UserStatus Status { get; set; }

        public enum UserStatus
        {
            ACTIVE, DEACTIVE, DELETED
        }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Batch> Batches { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Reminder> Reminders { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
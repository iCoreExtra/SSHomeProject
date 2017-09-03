using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using SSHomeDataModel;
using SSHomeBusinessLayerTypes;
using System.Configuration;
using System;

namespace SSHomeProject.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IUser<int>
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string Phone2 { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int DesignationId { get; set; }
        /// <summary>
        ///     The salted/hashed form of the user password
        /// </summary>
        public virtual string PasswordHash { get; set; }
        public int StoreId { get; set; }
        public DateTime AnniversaryDate { get; set; }
        public string ImageUrl { get; set; }
        public DateTime DateOfJoining { get; set; }
        public bool IsSiteUser { get; set; }
        public int DepartmentId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool Status { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser, int> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            
            // Add custom user claims here

            userIdentity.AddClaim(new Claim("", ""));

            return userIdentity;
        }
    }

    //public class ApplicationDbContext : IRepositoryBL
    //{
    //    public ApplicationDbContext(string connectionName)            
    //    {
            
    //    }        

    //    public static ApplicationDbContext Create()
    //    {
    //        return new ApplicationDbContext(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
    //    }
    //}
}

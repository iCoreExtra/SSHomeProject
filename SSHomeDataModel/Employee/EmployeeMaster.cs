using System;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Security.Claims;


namespace SSHomeDataModel
{
    public class EmployeeMaster
    {
        public  EmployeeMaster()
        {

        }

        public EmployeeMaster(string userName): this()
        {
            UserName = userName;
        }

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

    }

}

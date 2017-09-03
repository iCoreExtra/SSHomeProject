using System;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using SSHomeProject.Models;
using SSHomeProject.Unity;
using SSHomeBusinessLayerTypes;
using System.Collections.Generic;
using SSHomeDataModel;
using SSHomeDatalayerCommon;
using SSHomeCommon;

namespace SSHomeProject
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your email service here to send an email.
            return Task.FromResult(0);
        }
    }

    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }
    }

    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.
    public class ApplicationUserManager : UserManager<ApplicationUser, int>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser, int> store)
            : base(store)
        {
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            ApplicationUserManager manager = new ApplicationUserManager(new UserStore(BootStrapper.Get<IEmployeeMasterBL>())); //as DbManager

            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<ApplicationUser, int>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };

            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug it in here.
            manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<ApplicationUser, int>
            {
                MessageFormat = "Your security code is {0}"
            });
            manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<ApplicationUser, int>
            {
                Subject = "Security Code",
                BodyFormat = "Your security code is {0}"
            });
            manager.EmailService = new EmailService();
            manager.SmsService = new SmsService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<ApplicationUser, int>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }

        public override Task<ApplicationUser> FindByNameAsync(string userName)
        {

            // call repository get generic claa obj or list back apply conversion
            return base.FindByNameAsync(userName);
        }

        

    }

    // Configure the application sign-in manager which is used in this application.
    public class ApplicationSignInManager : SignInManager<ApplicationUser, int>
    {
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUser user)
        {
            return user.GenerateUserIdentityAsync((ApplicationUserManager)UserManager);
        }

        public override Task<SignInStatus> PasswordSignInAsync(string userName, string password, bool isPersistent, bool shouldLockout)
        {

            return base.PasswordSignInAsync(userName, password, isPersistent, shouldLockout);
        }

        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        {
            return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
        }


        #region Other Methods

        

        #endregion
    }

    public class UserStore : IUserStore<ApplicationUser, int>, 
        IUserEmailStore<ApplicationUser, int>,
        IUserLockoutStore<ApplicationUser, int>,
        IUserPasswordStore<ApplicationUser, int>,
        IUserLoginStore<ApplicationUser, int>
    {
        private IEmployeeMasterBL _service;

        public UserStore(IEmployeeMasterBL service)
        {
            _service = service;
        }

        #region IUserStore 

        public Task CreateAsync(ApplicationUser user)
        {
            EmployeeMaster employee = new EmployeeMaster();
            ConvertIdentityObjectToDomainObject(user, employee);
            Result<EmployeeMaster> result = _service.Create(employee);
            return Task.FromResult<object>(null);
        }

        public Task DeleteAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _service.Dispose();
        }

        public Task<ApplicationUser> FindByEmailAsync(string email)
        {
            EmployeeMaster employeeMaster = _service.FindByEmail(email);
            if (employeeMaster != null)
            {
                ApplicationUser user = new ApplicationUser();
                ConvertEmployeeMasterToApplicationUser(employeeMaster, user);
                return Task.FromResult<ApplicationUser>(user);
            }
            return Task.FromResult<ApplicationUser>(null);
        }

        public Task<ApplicationUser> FindByIdAsync(int userId)
        {
            EmployeeMaster employeeMaster = _service.FindById(userId);
            if (employeeMaster != null)
            {
                ApplicationUser user = new ApplicationUser();
                ConvertEmployeeMasterToApplicationUser(employeeMaster, user);
                return Task.FromResult<ApplicationUser>(user);
            }
            return Task.FromResult<ApplicationUser>(null);
        }

        public Task<ApplicationUser> FindByNameAsync(string userName)
        {
            List<EmployeeMaster> result =_service.FindByName(userName);
            List<ApplicationUser> users = null;
            if (result != null && result.Count > 0)
            {
                users = result.Select(m => new ApplicationUser()
                {
                    Id = m.Id,
                    UserName = m.UserName,
                    Email = m.Email,
                    FirstName = m.FirstName,
                    LastName = m.LastName
                }).ToList();
                return Task.FromResult<ApplicationUser>(users[0]);
            }
            return Task.FromResult<ApplicationUser>(null);
        }

        #endregion

        #region IUserEmailStore Methods

        public Task<string> GetEmailAsync(ApplicationUser user)
        {
            return Task.FromResult<string>(user.Email);
        }

        public Task<bool> GetEmailConfirmedAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public Task SetEmailAsync(ApplicationUser user, string email)
        {
            throw new NotImplementedException();
        }

        public Task SetEmailConfirmedAsync(ApplicationUser user, bool confirmed)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        #endregion


        #region IUserLockoutStore Methods

        public Task<DateTimeOffset> GetLockoutEndDateAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public Task SetLockoutEndDateAsync(ApplicationUser user, DateTimeOffset lockoutEnd)
        {
            throw new NotImplementedException();
        }

        public Task<int> IncrementAccessFailedCountAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public Task ResetAccessFailedCountAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetAccessFailedCountAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetLockoutEnabledAsync(ApplicationUser user)
        {
            return Task.FromResult(false);
        }

        public Task SetLockoutEnabledAsync(ApplicationUser user, bool enabled)
        {
            return Task.FromResult<object>(null);
        }

        #endregion

        #region IUserPasswordStore Methods

        public Task SetPasswordHashAsync(ApplicationUser user, string passwordHash)
        {
            user.PasswordHash = passwordHash;
            return Task.FromResult(0);
        }

        public Task<string> GetPasswordHashAsync(ApplicationUser user)
        {
            user.PasswordHash = "sagar123";
            return Task.FromResult<string>(user.PasswordHash);
        }

        public Task<bool> HasPasswordAsync(ApplicationUser user)
        {
            return Task.FromResult<bool>(!String.IsNullOrEmpty(user.Password));
        }

        #endregion

        #region IUserStoreLogin Methods

        public Task AddLoginAsync(ApplicationUser user, UserLoginInfo login)
        {
            throw new NotImplementedException();
        }

        public Task RemoveLoginAsync(ApplicationUser user, UserLoginInfo login)
        {
            throw new NotImplementedException();
        }

        public Task<IList<UserLoginInfo>> GetLoginsAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUser> FindAsync(UserLoginInfo login)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Conversion Methods

        public void ConvertEmployeeMasterToApplicationUser(EmployeeMaster employee, ApplicationUser user)
        {
            user.Email = employee.Email;
            user.UserName = employee.UserName;
            user.Id = employee.Id;
            user.FirstName = employee.FirstName;
            user.LastName = employee.LastName;
        }

        public void ConvertIdentityObjectToDomainObject(ApplicationUser user, EmployeeMaster employee)
        {
            employee.UserName = user.Email;
            employee.Password = user.Password;
            employee.FirstName = user.FirstName;
            employee.LastName = user.LastName;
            employee.Mobile = user.Mobile;
            employee.Phone2 = user.Phone2;
            employee.Email = user.Email;
            employee.Email2 = user.Email2;
            employee.CreatedBy = 1;
            employee.DateOfBirth = user.DateOfBirth;
            employee.AnniversaryDate = DateTime.Now;
            employee.DesignationId = user.DesignationId;
            employee.StoreId = user.StoreId;
        }       

        #endregion
    }
}

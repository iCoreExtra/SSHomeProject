using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSHomeDataModel.Employee
{
    class UserClaimMaster
    {
        private EmployeeMaster _user;

        #region Scalar Properties
        public virtual int ClaimId { get; set; }
        public virtual Guid UserId { get; set; }
        public virtual string ClaimType { get; set; }
        public virtual string ClaimValue { get; set; }
        #endregion

        #region Navigation Properties
        public virtual EmployeeMaster User
        {
            get { return _user; }
            set
            {
                _user = value ?? throw new ArgumentNullException("value");
                UserId = value.Id;
            }
        }
        #endregion
    }
}

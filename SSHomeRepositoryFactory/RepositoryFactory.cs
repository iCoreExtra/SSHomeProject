using System;
using System.Collections.Generic;
using SSHomeCommon.Helpers;
using SSHomeRepositoryTypes;
using SSHomeRepository;
using System.Threading.Tasks;
using SSHomeRepository;

namespace SSHomeRepositoryFactory
{
    public static class RepositoryFactory
    {
        private static readonly Dictionary<Type, Type> container = new Dictionary<Type, Type>();

        // constructor
        static RepositoryFactory()
        {
            LoadContainer();
        }


        public static T GetRepository<T>() where T : IRepository
        {
            IRepository repository = null;

            if (container.ContainsKey(typeof(T)))
            {
                repository = ActivatorHelper.CreateObject(container[typeof(T)].Assembly.FullName,
                                                          container[typeof(T)].FullName, null) as IRepository;
            }

            return (T)repository;
        }


        private static void LoadContainer()
        {
            container.Add(typeof(IEmployeeMasterRepository), typeof(EmployeeMasterRepository));
            //RawItemMaster
            container.Add(typeof(IRawItemMasterRepository), typeof(RawItemMasterRepository));

            //UnitMaster
            container.Add(typeof(IUnitMasterRepository), typeof(UnitMasterRepository));

            //BrandMaster
            container.Add(typeof(IBrandMasterRepository), typeof(BrandMasterRepository));

            //ItemTypeMaster
            container.Add(typeof(IItemTypeMasterRepository), typeof(ItemTypeRepository));

            //ReferralMaster
            container.Add(typeof(IReferralMasterRepository), typeof(ReferralMasterRepository));

            //CustomerTypeMaster
            container.Add(typeof(ICustomerTypeMasterRepository), typeof(CustomerTypeMasterRepository));

            //StoreMaster
            container.Add(typeof(IStoreMasterRepository), typeof(StoreMasterRepository));

            //StateMaster
            container.Add(typeof(IStateMasterRepository), typeof(StateMasterRepository));

            //CityMaster
            container.Add(typeof(ICityMasterRepository), typeof(CityMasterRepository));

            //VendorMaster
            container.Add(typeof(IVendorMasterRepository), typeof(VendorMasterRepository));

            //ClientMaster
            container.Add(typeof(IClientMasterRepository), typeof(ClientMasterRepository));

            container.Add(typeof(ISpecificationCatalogueRepository), typeof(SpecificationCatalogueRepository));
        }
    }
}

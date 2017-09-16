using Microsoft.Practices.Unity;
using SSHomeBusinessLayer;
using SSHomeBusinessLayerTypes;
using SSHomeBusinessLayer;
using SSHomeBusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace SSHomeProject.Unity
{
    public static class BootStrapper
    {
        #region class members

        private static IUnityContainer container;

        #endregion class members


        #region constructors

        public static void Initialise()
        {
            container = BuildUnityContainer();

            DependencyResolver.SetResolver(new Microsoft.Practices.Unity.Mvc.UnityDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver =
            new Microsoft.Practices.Unity.WebApi.UnityDependencyResolver(container);
        }

        #endregion constructors


        #region public methods

        public static T Get<T>() where T : IBusinessLayer
        {
            return container.Resolve<T>();
        }

        #endregion public methods


        #region private methods

        private static IUnityContainer BuildUnityContainer()
        {
            container = new UnityContainer();
            //RawItemMaster
            container.RegisterType<IRawItemMasterBL,RawItemMasterBL>();

            //UnitMaster
            container.RegisterType<IUnitMasterBL,UnitMasterBL>();

            //BrandMaster
            container.RegisterType<IBrandMasterBL, BrandMasterBL>();

            //ItemTypeMaster
            container.RegisterType<IItemTypeMasterBL, ItemTypeMasterBL>();

            //ReferralMaster
            container.RegisterType<IReferralMasterBL, ReferralMasterBL>();

            //CustomerTypeMaster
            container.RegisterType<ICustomerTypeMasterBL, CustomerTypeMasterBL>();

            //StoreMaster
            container.RegisterType<IStoreMasterBL, StoreMasterBL>();

            //StateMaster
            container.RegisterType<IStateMasterBL, StateMasterBL>();

            //CityMaster
            container.RegisterType<ICityMasterBL, CityMasterBL>();

            //VendorMaster
            container.RegisterType<IVendorMasterBL, VendorMasterBL>();

            //ClientMaster
            container.RegisterType<IClientMasterBL, ClientMasterBL>();

            container.RegisterType<IEmployeeMasterBL, EmployeeMasterBL>();
            //container.RegisterType<AccountController>(new InjectionConstructor());
            //container.RegisterType<IAuthenticationManager>(new InjectionFactory(c => HttpContext.Current.GetOwinContext().Authentication));
            container.RegisterType<ISpecificationCatalogueBL, SpecificationCatalogueBL>();
            return container;
        }

        #endregion private methods
    }
}
using Microsoft.Practices.Unity;
using SSHomeBusinessLayerTypes;
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

            return container;
        }

        #endregion private methods
    }
}
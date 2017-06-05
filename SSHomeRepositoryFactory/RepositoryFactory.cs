using System;
using System.Collections.Generic;
using SSHomeCommon.Helpers;
using SSHomeRepositoryTypes;
using System.Threading.Tasks;

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
            
        }
    }
}

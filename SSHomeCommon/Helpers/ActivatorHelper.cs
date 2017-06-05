using System;
using System.Reflection;

namespace SSHomeCommon.Helpers
{
    public class ActivatorHelper
    {

        public static object CreateObject(string assemblyName, string className, object[] args)
        {
            object anObject = null;
            string initialPath = Environment.CurrentDirectory;

            try
            {
                if (String.IsNullOrEmpty(assemblyName))
                    throw new ArgumentNullException("assemblyName");

                if (String.IsNullOrEmpty(className))
                    throw new ArgumentNullException("className");

                Assembly assembly = Assembly.Load(assemblyName);
                if (assembly == null)
                    throw new Exception("Unable to load the assembly");

                Type classType = assembly.GetType(className);
                if (classType == null)
                    throw new Exception(string.Format("Class Type : [{0}] not found in assembly", className));

                anObject = assembly.CreateInstance(classType.ToString(), true,
                        BindingFlags.CreateInstance, null, args, null, null);
            }
            catch (TargetInvocationException ex)
            {
                throw ex.InnerException;
            }
            catch
            {
                throw;
            }
            finally	//Reset the CurrentDirectory to point at the current path before this method was called.
            {
                Environment.CurrentDirectory = initialPath;
            }

            return anObject;
        }
    }
}

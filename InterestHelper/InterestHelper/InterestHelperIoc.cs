using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterestHelper.IDataAccessLayer;
using InterestHelper.WebDataAccessLayer;
using Microsoft.Practices.Unity;

namespace InterestHelper
{
    internal static class InterestHelperIoc
    {
        private static readonly IUnityContainer Container = new UnityContainer();

        public static void InitializeIoc()
        {
            Container.RegisterType<IInputDataProvider, WebInputDataProvider>();
        }

        public static T Resolve<T>()
        {
            return Container.Resolve<T>();
        }
    }
}

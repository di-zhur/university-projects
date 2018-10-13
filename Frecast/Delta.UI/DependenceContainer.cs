using Delta.Analytics;
using Delta.DataAccess;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Delta.UI
{
    public static class DependenceContainer
    {
        private static IUnityContainer _unityContainer;

        public static IUnityContainer GetDependenceContainer
        {
            get
            {
                return _unityContainer;
            }
        }

        public static void Register()
        {
            _unityContainer = new UnityContainer();
            _unityContainer.RegisterType<IUnitOfWork, UnitOfWork>();
        }
    }
}

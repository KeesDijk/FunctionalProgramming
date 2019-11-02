using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity;

namespace InfraStrcuture
{
    public class GlobalIocContainer
    {
        private static readonly Lazy<GlobalIocContainer> _instance = new Lazy<GlobalIocContainer>(() => new GlobalIocContainer());
        private readonly IUnityContainer _container;

        private GlobalIocContainer()
        {
            _container = new UnityContainer();
        }

        public void AddExtension(UnityContainerExtension extensionModule)
        {
            if (extensionModule != null)
            {
                _container.AddExtension(extensionModule);
            }
        }

        public IUnityContainer Container
        {
            get { return _container; }
        }

        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        public T Resolve<T>(params InjectedParam[] args)
        {
            List<ResolverOverride> overrides = new List<ResolverOverride>();
            foreach (var arg in args)
            {
                var typeToConstruct = arg.TypeOfParam;
                var dependencyOverride = new DependencyOverride(typeToConstruct, arg.Value);
                overrides.Add(dependencyOverride);
            }

            return _container.Resolve<T>(overrides.ToArray());
        }

        public static GlobalIocContainer Instance()
        {
            return _instance.Value;
        }

        public void RegisterUserSpecificITypesOf(Assembly assemblyToLoad, string usernameOverride = "")
        {
            var username = string.IsNullOrEmpty(usernameOverride) ? Environment.UserName : usernameOverride;

            Debug.WriteLine(string.Format("Using Username: {0}", username));

            var types = assemblyToLoad
                .GetTypes()
                .Where(t => t.GetInterfaces().Any(i => i.Name.StartsWith("I")));

            foreach (var t in types)
            {
                Debug.WriteLine(string.Format("Type: {0}", t));
                var makeInterfaceName = MakeInterfaceName(t, username);
                Debug.WriteLine(String.Format("Looking for interface: {0}", makeInterfaceName));
                var @interface = t.GetInterface(makeInterfaceName, false);
                if (@interface != null)
                {
                    Debug.WriteLine(String.Format("Interface: {0}", @interface));
                    _container.RegisterType(@interface, t);
                }
                else
                {
                    Debug.WriteLine("Not Found");
                }
            }
        }

        private static string MakeInterfaceName(Type t, string username)
        {
            return "I" + t.Name.Replace(username.ToUpper(), string.Empty);
        }
    }
}

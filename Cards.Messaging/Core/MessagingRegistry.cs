using System;
using System.Linq;
using Cards.Messaging.Dispatchers;
using Cards.Messaging.Endpoints;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;
using StructureMap.TypeRules;

namespace Cards.Messaging.Core
{
    public class MessagingRegistry : Registry
    {
        public MessagingRegistry()
        {
            Scan(scanner =>
            {
                //Scan all other assemblies starting with the solutions prefix for public classes inheriting from StructureMaps Registry-class
                scanner.AssembliesFromApplicationBaseDirectory(
                    assembly => assembly.FullName.StartsWith("Cards."));
                scanner.With(new SingletonConvention<IMessageEndpoint>());
               

                For<IMessageDispatcher>().Singleton().Use<BasicMessageDispatcher>();
            });
        }
    }

    internal class SingletonConvention<TPluginFamily> : IRegistrationConvention
    {
        public void Process(Type type, Registry registry)
        {
            if (!type.IsConcrete() || !type.CanBeCreated() || !type.AllInterfaces().Contains(typeof(TPluginFamily))) return;

            registry.For(typeof(TPluginFamily)).Singleton().Use(type);
        }
    }
}

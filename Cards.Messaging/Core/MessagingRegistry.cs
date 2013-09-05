using System;
using System.Linq;
using Cards.Messaging.Dispatchers;
using Cards.Messaging.Endpoints;
using Cards.Messaging.Pipeline;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;
using StructureMap.TypeRules;

namespace Cards.Messaging.Core
{
    internal class MessagingRegistry : Registry
    {
        public MessagingRegistry()
        {
            Scan(scanner =>
            {
                //Scan all other assemblies starting with the solutions prefix for public classes inheriting from StructureMaps Registry-class
                scanner.AssembliesFromApplicationBaseDirectory();
                //scanner.With(new SingletonConvention<IMessageEndpoint>());

                scanner.AddAllTypesOf<IMessageEndpoint>();
                For<IMessageDispatcher>().Singleton().Use<BasicMessageDispatcher>();

            });
        }
    }

    internal class PipelineConfigRegistry : Registry
    {
        public PipelineConfigRegistry()
        {
            Scan(scanner =>
            {
                scanner.AssembliesFromApplicationBaseDirectory();
                scanner.AddAllTypesOf<PipelineRegistry>();
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

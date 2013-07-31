using Cards.Messaging.Dispatchers;
using Cards.Messaging.Endpoints;
using StructureMap.Configuration.DSL;

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
                scanner.AddAllTypesOf<IMessageEndpoint>();

                For<IMessageDispatcher>().Singleton().Use<BasicMessageDispatcher>();
            });
        }
    }
}

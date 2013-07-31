using StructureMap;

namespace Cards.Presentation.Core
{
    public class Initialization
    {
        public static void Initialize()
        {
            var container = new Container();
            container.Configure(i =>
                
                        i.Scan(scanner =>
                            {
                                //Scan all other assemblies starting with the solutions prefix for public classes inheriting from StructureMaps Registry-class
                                scanner.AssembliesFromApplicationBaseDirectory(
                                    assembly => assembly.FullName.StartsWith("Cards."));
                                scanner.LookForRegistries();
                            
                          
                            })

                );
            LocateBase.SetContainer(container);
            
        }
    }
}
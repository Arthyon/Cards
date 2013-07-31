using StructureMap;

namespace Cards.Presentation.Core
{
    public class LocateBase
    {
        protected static IContainer Container { get; private set; }

        public static void SetContainer(IContainer container)
        {
            Container = container;
        }
    }

    public class Locate<T> : LocateBase
    {
        public static T Instance { get { return Container.GetInstance<T>(); } }
    }
}
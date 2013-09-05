using Cards.Messaging.Pipeline;
using StructureMap;


namespace Cards.Messaging.Core
{
    public static class MessagingInitializer
    {
        public static void Initialize(IContainer container)
        {
            container.Configure(i => i.AddRegistry<MessagingRegistry>());
            ConfigurePipelines(container);
        }

        private static void ConfigurePipelines(IContainer container)
        {
            var collection = new PipelineCollection();

            using(var tempContainer = new Container(new PipelineConfigRegistry()))
            {
                foreach (var pipeline in tempContainer.GetAllInstances<PipelineRegistry>())
                {
                    pipeline.Configure(collection);
                }
            }

            container.Configure(i => i.For<IPipelineLocator>().Singleton().Use(collection));
        }
    }
}

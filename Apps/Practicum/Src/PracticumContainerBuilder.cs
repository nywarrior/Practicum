using Autofac;
using Practicum.Entities;

namespace Practicum
{
    /// <summary>
    /// 
    /// </summary>
    internal class PracticumContainerBuilder
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IContainer CreateContainer()
        {
            var containerBuilder = new ContainerBuilder();
            Register(containerBuilder);
            var container = containerBuilder.Build();
            return container;
        }

        private static void Register(ContainerBuilder containerBuilder)
        {
            // Register individual components
            containerBuilder.RegisterInstance<IMeal>(new Meal());
            containerBuilder.RegisterInstance<IScanner>(new Scanner());
            containerBuilder.RegisterInstance<IParser>(new Parser());
            containerBuilder.RegisterInstance<IValidator>(new Validator());
            containerBuilder.RegisterInstance<IOutputWriter>(new OutputWriter());
        }
    }
}

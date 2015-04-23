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

        private void Register(ContainerBuilder containerBuilder)
        {
            // Register individual components
            containerBuilder.Register(c => new Meal()).As<IMeal>();
            containerBuilder.Register(c => new Scanner()).As<IScanner>();
            containerBuilder.Register(c => new Parser()).As<IParser>();
            containerBuilder.Register(c => new Validator()).As<IValidator>();
            containerBuilder.Register(c => new OutputWriter()).As<IOutputWriter>();
            //containerBuilder.RegisterType<PracticumRunner>().UsingConstructor(typeof(IMeal));
        }
    }
}

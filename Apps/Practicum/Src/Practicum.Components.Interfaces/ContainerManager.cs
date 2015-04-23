using System;
using Autofac;

namespace Practicum.Components
{
    /// <summary>
    /// 
    /// </summary>
    public static class ContainerManager
    {
        private static volatile IContainer _container;
        private static readonly object SyncRoot = new Object();

        /// <summary>
        /// 
        /// </summary>
        public static IContainer Container
        {
            get
            {
                if (_container != null)
                {
                    return _container;
                }
                lock (SyncRoot)
                {
                    if (_container != null)
                    {
                        return _container;
                    }
                    _container = CreateContainer();
                }
                return _container;
            }
        }

        private static IContainer CreateContainer()
        {
            var practicumContainerBuilder = new PracticumContainerBuilder();
            var container = practicumContainerBuilder.CreateContainer();
            return container;
        }
    }
}

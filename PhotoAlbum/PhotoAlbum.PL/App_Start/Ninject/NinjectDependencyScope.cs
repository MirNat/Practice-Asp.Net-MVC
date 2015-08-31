using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using Ninject;
using Ninject.Syntax;

namespace PhotoAlbum.App_Start
{
    /// <summary>
    /// Creating Dependency Resolver
    /// </summary>
    public class NinjectDependencyScope : IDependencyScope
    {
        private IResolutionRoot resolver;

        /// <summary>
        /// Class Constructor
        /// </summary>
        /// <param name="resolver"></param>
        public NinjectDependencyScope(IResolutionRoot resolver)
        {
            this.resolver = resolver;
        }

        /// <summary>
        /// Returns a single service by type
        /// </summary>
        public object GetService(Type serviceType)
        {
            if (resolver == null)
            {
                throw new ObjectDisposedException("this", "This scope has been disposed");
            }
            return resolver.TryGet(serviceType);
        }

        /// <summary>
        /// Returns a list of services by type
        /// </summary>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            if (resolver == null)
            {
                throw new ObjectDisposedException("this", "This scope has been disposed");
            }
            return resolver.GetAll(serviceType);
        }

        /// <summary>
        /// Redemption of resources
        /// </summary>
        public void Dispose()
        {
            var disposable = resolver as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }
            resolver = null;
        }
    }
}
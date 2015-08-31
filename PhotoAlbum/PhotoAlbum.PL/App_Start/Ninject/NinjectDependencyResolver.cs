using System.Web.Http.Dependencies;
using Ninject;

namespace PhotoAlbum.App_Start
{
    /// <summary>
    /// This class is the resolver, but it is also the global scope so we derive from framework Scope.
    /// </summary>
    public class NinjectDependencyResolver : NinjectDependencyScope, IDependencyResolver
    {
        private IKernel kernel;

        /// <summary>
        /// Class Constructor
        /// </summary>
        /// <param name="kernel"></param>
        public NinjectDependencyResolver(IKernel kernel) : base(kernel)
        {
            this.kernel = kernel;
        }

        /// <summary>
        /// 
        /// </summary>
        public IDependencyScope BeginScope()
        {
            return new NinjectDependencyScope(kernel.BeginBlock());
        }
    }
}
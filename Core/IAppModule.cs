
namespace AATM.Core
{
    public interface IAppModule
    {
        /// <summary>
    /// Registers the services and dependencies for a specific application module.
    /// </summary>
        void RegisterServices(SimpleDIContainer container);
    }
}
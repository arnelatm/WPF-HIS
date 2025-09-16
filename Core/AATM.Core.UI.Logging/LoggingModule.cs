
namespace AATM.Core.UI.Logging
{
    public class LoggingModule : IAppModule
    {

        public void RegisterServices(SimpleDIContainer container)
        {
            // This is where we register the concrete log viewer form with the DI container.
            container.Register(typeof(FrmLogViewer), new FrmLogViewer());
        }

    }
}
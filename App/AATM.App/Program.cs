using AATM.Business.Services.Mock;
using AATM.Contracts.Interfaces.Services;
using AATM.Presentation;
using AATM.Presenters;
using AATM.Services;
using AATM.UI;
using System;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace AATM.App
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // This section is the "Composition Root" of the application.
            // We are creating all the concrete implementations and wiring them together here.

            // 1. Create the concrete View. This is the user interface class.
            MainForm mainForm = new MainForm();

            // 2. Create the concrete Service implementation. We'll use a mock service for now.
            ITranslationService translationService = new MockTranslationService();

            // 3. Create the Presenter, injecting the view and service as dependencies.
            // The Presenter is now completely decoupled from the specific implementations.
            TranslationPresenter translationPresenter = new TranslationPresenter(mainForm, translationService);

            // 4. Run the application with the main form.
            Application.Run(mainForm);
        }
    }
}
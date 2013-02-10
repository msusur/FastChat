using System;
using System.Windows.Forms;
using CodeFiction.Stack.Library.Core.Initializers.Loaders;
using Codefiction.FastChat.UI.Forms;

namespace CodeFiction.FastChat.UI
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            var bootstrapper = new ChatBootstrapper();
            bootstrapper.StartApplication(AssemblyLoader.AllLoader);

            Application.Run(new MainForm());
        }
    }
}

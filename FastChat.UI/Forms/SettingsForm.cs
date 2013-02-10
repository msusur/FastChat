using CodeFiction.FastChat.Business.Models;
using CodeFiction.FastChat.Business.Views;

namespace Codefiction.FastChat.UI.Forms
{
    public partial class SettingsForm : FormBase, ISettingsView
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        public SettingModel Settings
        {
            get { return settingsBinding.DataSource as SettingModel; }
            set { settingsBinding.DataSource = value; }
        }
    }
}

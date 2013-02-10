using CodeFiction.FastChat.Business.Abstractions;
using CodeFiction.FastChat.Business.Models;
using CodeFiction.FastChat.Business.Presenters;

namespace CodeFiction.FastChat.Business
{
    public class ChatApplication : IChatApplication
    {
        private readonly ISettingsPresenter _settingsPresenter;
        private readonly IMainFormPresenter _mainFormPresenter;
        public SettingModel Settings { get; set; }

        public ChatApplication(ISettingsPresenter settingsPresenter, IMainFormPresenter mainFormPresenter)
        {
            _settingsPresenter = settingsPresenter;
            _mainFormPresenter = mainFormPresenter;
        }

        public void SetUpConfiguration()
        {
            Settings = _settingsPresenter.LoadSettings();
            var result = FormResults.Ok;
            if (Settings == null)
            {
                _settingsPresenter.SetViewEmptyModel();
                result = _settingsPresenter.ShowDialog();
                if (result == FormResults.Ok)
                {
                    _settingsPresenter.SaveSettings();
                }
            }
            if (result == FormResults.Ok)
            {
                _mainFormPresenter.ShowDialog();
            }
        }
    }
}

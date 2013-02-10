using CodeFiction.FastChat.Business.Models;

namespace CodeFiction.FastChat.Business.Presenters
{
    public interface ISettingsPresenter : IPresenter
    {
        void SaveSettings();
        SettingModel LoadSettings();
        void SetViewEmptyModel();
    }
}
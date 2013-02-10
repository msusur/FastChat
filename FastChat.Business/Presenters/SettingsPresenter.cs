using CodeFiction.FastChat.Business.Abstractions;
using CodeFiction.FastChat.Business.Helpers;
using CodeFiction.FastChat.Business.Models;
using CodeFiction.FastChat.Business.Services;
using CodeFiction.FastChat.Business.Views;

namespace CodeFiction.FastChat.Business.Presenters
{
    public class SettingsPresenter : PresenterBase<ISettingsView>, ISettingsPresenter
    {
        private readonly IFileService _fileService;

        public SettingsPresenter(ISettingsView view, IFileService fileService)
            : base(view)
        {
            _fileService = fileService;
        }

        public void SaveSettings()
        {
            var serialized = SerializationUtil.Serialize(View.Settings);
            _fileService.SaveToFile(serialized, Constants.ConfigurationFile);
        }

        public SettingModel LoadSettings()
        {
            if (!_fileService.FileExists(Constants.ConfigurationFile))
            {
                return null;
            }
            var config = _fileService.ReadTextFromFile(Constants.ConfigurationFile);
            if (!string.IsNullOrEmpty(config))
            {
                View.Settings = SerializationUtil.Deserialize<SettingModel>(config);
            }
            return View.Settings;
        }

        public void SetViewEmptyModel()
        {
            View.Settings = new SettingModel();
        }
    }
}

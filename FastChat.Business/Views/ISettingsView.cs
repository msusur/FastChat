using CodeFiction.FastChat.Business.Abstractions;
using CodeFiction.FastChat.Business.Models;

namespace CodeFiction.FastChat.Business.Views
{
    public interface ISettingsView : IView
    {
        SettingModel Settings { get; set; }
    }
}

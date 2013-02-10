using CodeFiction.FastChat.Business.Helpers;
using CodeFiction.FastChat.Business.Models;
using CodeFiction.FastChat.Business.Presenters;
using CodeFiction.FastChat.Business.Services;
using CodeFiction.FastChat.Business.Views;
using Moq;

namespace FastChat.Business.Tests
{
    public class TestableSettingsPresenter : SettingsPresenter
    {
        public readonly Mock<ISettingsView> ViewMock;
        public readonly Mock<IFileService> FileService;

        TestableSettingsPresenter(Mock<ISettingsView> viewMock, Mock<IFileService> fileService)
            : base(viewMock.Object, fileService.Object)
        {
            ViewMock = viewMock;
            FileService = fileService;
        }

        public static TestableSettingsPresenter Create(SettingModel setting)
        {
            var fileService = new Mock<IFileService>();
            fileService.Setup(service => service.FileExists(It.IsAny<string>())).Returns(true);
            fileService.Setup(service => service.ReadTextFromFile(It.IsAny<string>()))
                       .Returns(SerializationUtil.Serialize(setting));

            var viewMock = new Mock<ISettingsView>();
            viewMock.SetupAllProperties();

            return new TestableSettingsPresenter(viewMock, fileService);
        }
    }
}

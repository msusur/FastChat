using CodeFiction.FastChat.Business;
using CodeFiction.FastChat.Business.Abstractions;
using CodeFiction.FastChat.Business.Models;
using CodeFiction.FastChat.Business.Views;
using CodeFiction.FastChat.UI;
using CodeFiction.Stack.Library.Core.Initializers.Loaders;
using Moq;
using NUnit.Framework;

namespace FastChat.Business.Tests
{
    [TestFixture]
    public class AppInitializationTests
    {
        private ChatBootstrapper _bootstrapper;

        private static readonly SettingModel SettingModelStub = new SettingModel
                                                           {
                                                               AutoJoinChannels = new string[] { "codefiction" },
                                                               Nick = "test",
                                                               Password = "0"
                                                           };

        [TestFixtureSetUp]
        public void TestInit()
        {
            _bootstrapper = new ChatBootstrapper();
            _bootstrapper.StartApplication(
                AssemblyLoader.FromAssembly(GetType().Assembly,
                typeof(Program).Assembly,
                typeof(IView).Assembly));
        }

        [Test]
        public void Check_if_settings_entered_when_starting_application_if_so_open_mainform()
        {
            var presenter = TestableSettingsPresenter.Create(SettingModelStub);
            var mainFormPresenter = TestableMainFormPresenter.Create();

            var application = new ChatApplication(presenter, mainFormPresenter);
            application.SetUpConfiguration();

            presenter.FileService.Verify(service => service.ReadTextFromFile(It.IsAny<string>()), Times.Once());
            presenter.ViewMock.Verify(view => view.Settings, Times.AtLeastOnce());
            mainFormPresenter.ViewMock.Verify(form => form.ShowDialog(), Times.Once());
            Assert.NotNull(application.Settings);
        }

        [Test]
        public void If_settings_not_entered_open_settings_when_starting_application()
        {
            var presenter = TestableSettingsPresenter.Create(null);
            var mainFormPresenter = TestableMainFormPresenter.Create();
            presenter.ViewMock.Setup(view => view.ShowDialog()).Returns(FormResults.Ok);

            var application = new ChatApplication(presenter, mainFormPresenter);
            application.SetUpConfiguration();

            presenter.FileService.Verify(service => service.ReadTextFromFile(It.IsAny<string>()), Times.Once());

            presenter.ViewMock.Verify(form => form.ShowDialog(), Times.Once());

            presenter.FileService.Verify(service => service.SaveToFile(It.IsAny<string>(), It.IsAny<string>()), Times.Once());
        }

        [TestFixtureTearDown]
        public void CleanUp()
        {
            _bootstrapper.StopApplication();
        }
    }
}

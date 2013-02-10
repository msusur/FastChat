using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFiction.FastChat.Business.Presenters;
using CodeFiction.FastChat.Business.Views;
using Moq;

namespace FastChat.Business.Tests
{
    internal class TestableMainFormPresenter : MainFormPresenter
    {
        public readonly Mock<IMainForm> ViewMock;

        TestableMainFormPresenter(Mock<IMainForm> viewMock)
            : base(viewMock.Object)
        {
            ViewMock = viewMock;
        }

        public static TestableMainFormPresenter Create()
        {
            return new TestableMainFormPresenter(new Mock<IMainForm>());
        }
    }
}

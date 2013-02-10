using CodeFiction.FastChat.Business.Abstractions;
using CodeFiction.FastChat.Business.Views;

namespace CodeFiction.FastChat.Business.Presenters
{
    public abstract class PresenterBase<TView>
        where TView : IView
    {
        protected TView View { get; private set; }

        protected PresenterBase(TView view)
        {
            View = view;
        }

        public virtual FormResults ShowDialog()
        {
            return View.ShowDialog();
        }
    }
}

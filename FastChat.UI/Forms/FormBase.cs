using System.Windows.Forms;
using CodeFiction.FastChat.Business.Abstractions;
using CodeFiction.FastChat.Business.Views;

namespace Codefiction.FastChat.UI.Forms
{
    public class FormBase : Form, IView
    {
        protected class DialogHelper
        {
            public static FormResults FromDialogResult(DialogResult result)
            {
                switch (result)
                {
                    case DialogResult.OK:
                        return FormResults.Ok;
                    case DialogResult.Yes:
                        return FormResults.Yes;
                    case DialogResult.No:
                        return FormResults.No;
                    default:
                        return FormResults.Cancel;
                }
            }
        }

        public new FormResults ShowDialog()
        {
            return DialogHelper.FromDialogResult(base.ShowDialog());
        }

    }
}

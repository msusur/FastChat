using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFiction.FastChat.Business.Abstractions;
using CodeFiction.FastChat.Business.Views;

namespace CodeFiction.FastChat.Business.Presenters
{
    public class MainFormPresenter : PresenterBase<IMainForm>, IMainFormPresenter
    {
        public MainFormPresenter(IMainForm view)
            : base(view)
        {
        }

        
    }
}

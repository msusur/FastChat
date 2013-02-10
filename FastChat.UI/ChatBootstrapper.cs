using CodeFiction.FastChat.Business;
using CodeFiction.Stack.Library.Core.Initializers;
using CodeFiction.Stack.Library.CoreContracts;

namespace CodeFiction.FastChat.UI
{
    public class ChatBootstrapper : Bootstrapper
    {
        protected override void OnDependencyLoading(IDependencyResolver resolver)
        {
            base.OnDependencyLoading(resolver);

            resolver.Register<IChatApplication, ChatApplication>();
        }
    }
}
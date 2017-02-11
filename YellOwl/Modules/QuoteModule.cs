using Forismatic;
using Ninject.Modules;
using YellOwl.Abstractions.Provider;

namespace YellOwl.Modules
{
    public class QuoteModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ITextProvider>().To<ForismaticProvider>().InThreadScope();
        }
    }
}
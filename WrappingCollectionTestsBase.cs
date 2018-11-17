using System.Windows.Threading;
using LogoFX.Client.Testing.Infra;

namespace FailingTest
{
    public abstract class WrappingCollectionTestsBase
    {
        protected WrappingCollectionTestsBase()
        {
            Dispatch.Current = new SameThreadDispatch();
        }
    }
}
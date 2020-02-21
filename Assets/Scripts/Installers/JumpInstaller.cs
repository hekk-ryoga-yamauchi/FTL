using Contracts.Jump;
using Models;
using Presenters;
using Zenject;

namespace Installers
{
    public class JumpInstaller: MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<string>().FromInstance("Hello World!");
            
            // presenters
            Container.Bind<INodesPresenter>().To<NodesPresenter>().AsSingle().NonLazy();
            
        }

    }
}
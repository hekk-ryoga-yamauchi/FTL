using Contracts.Game;
using Presenters.Game;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<string>().FromInstance("Hello World!");
        
        // Presenters
        Container.Bind<IUnitsPresenter>().To<UnitsPresenter>().AsSingle().NonLazy();

        //

    }
}

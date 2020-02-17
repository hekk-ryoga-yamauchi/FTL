using Zenject;

namespace Installers
{
    public class BattleInstaller: MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<string>().FromInstance("Hello World!");
        }
    }
}
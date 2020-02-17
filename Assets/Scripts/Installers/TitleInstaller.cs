using Zenject;

namespace Installers
{
    public class TitleInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<string>().FromInstance("Hello World!");
        }
    }
}
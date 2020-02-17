using Zenject;

namespace Installers
{
    public class CustomInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<string>().FromInstance("Hello World!");


        }
    }
}
using Zenject;

namespace Installers
{
    public class JumpInstaller: MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<string>().FromInstance("Hello World!");
        }

    }
}
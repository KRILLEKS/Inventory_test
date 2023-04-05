using Infrastructure.Factory;
using Infrastructure.Services.AssetProvider;
using Infrastructure.Services.StaticDataProvider;
using Zenject;

namespace Infrastructure
{
   // it's named as "Bootstrap" cause it should be invoked in a bootstrap state
   public class BootstrapInstaller : MonoInstaller
   {
      public override void InstallBindings()
      {
         Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();
         Container.Bind<IUIFactory>().To<UIFactory>().AsSingle();
         Container.Bind<IStaticDataProvider>().To<StaticDataProvider>().AsSingle();
      }
   }
}

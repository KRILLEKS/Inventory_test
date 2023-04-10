using Infrastructure.Factory;
using Infrastructure.Serialization.SerializationServices;
using Infrastructure.Services.AssetProvider;
using Infrastructure.Services.ItemsProvider;
using Infrastructure.Services.StaticDataProvider;
using Inventory.InventoryHandleRelated;
using Inventory.InventoryUIUpdater;
using Zenject;

namespace Infrastructure
{
   // it's named as "Bootstrap" cause it should be invoked in a bootstrap state
   public class BootstrapInstaller : MonoInstaller
   {
      public override void InstallBindings()
      {
         Container.BindInterfacesAndSelfTo<ItemProvider>().AsSingle();
         Container.BindInterfacesAndSelfTo<ButtonAssistedInventory>().AsSingle();

         Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();
         Container.Bind<IUIFactory>().To<UIFactory>().AsSingle();
         Container.Bind<IStaticDataProvider>().To<StaticDataProvider>().AsSingle();
         Container.Bind<IInventoryUIActualizer>().To<InventoryUIActualizer>().AsSingle();

         Container.Bind<IJsonSerializer>().To<JsonSerializer>().AsSingle();
         Container.Bind<ISaveLoadService>().To<SaveLoadService>().AsSingle();
      }
   }
}

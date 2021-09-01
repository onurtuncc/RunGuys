using Zenject;
using UnityEngine;
public class DefaultInstaller : MonoInstaller
{
    public GameObject paintWall;
    public GameObject playerModel;
    public GameObject player;

    public override void InstallBindings()
    {

        Container.Bind<IMovementManager>().To<MovementManager>().AsSingle();
        Container.Bind<ILevelManager>().To<LevelManager>().AsSingle();
        Container.Bind<IAnimationManager>().To<AnimationManager>().AsSingle();
        Container.Bind<PaintBrush>().FromComponentOn(paintWall).AsSingle();
        Container.Bind<Animator>().FromComponentOn(playerModel).AsSingle();
        Container.Bind<MovementController>().FromComponentOn(player).AsSingle();
        Container.Bind<Rigidbody>().FromComponentOn(player).AsSingle();
        
      
    }
}
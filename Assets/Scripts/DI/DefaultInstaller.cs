using Zenject;

public class DefaultInstaller : MonoInstaller
{
    public override void InstallBindings()
    {

        Container.Bind<IMovementManager>().To<MovementManager>().AsSingle();
        Container.Bind<ILevelManager>().To<LevelManager>().AsSingle();
        Container.Bind<IAnimationManager>().To<AnimationManager>().AsSingle();
        
    }
}
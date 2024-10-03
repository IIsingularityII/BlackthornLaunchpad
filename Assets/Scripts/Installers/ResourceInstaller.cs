using Scripts.ResourceFeature;
using UnityEngine;
using Zenject;

public class ResourceInstaller : MonoInstaller
{
    [SerializeField] private ResourceFeatureOnScene feature;
    public override void InstallBindings()
    {
        Container.Bind<ResourceFeatureOnScene>().FromInstance(feature).AsSingle();
        Container.QueueForInject(feature);
    }
}
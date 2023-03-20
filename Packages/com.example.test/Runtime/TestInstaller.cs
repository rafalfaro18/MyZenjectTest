using Zenject;
using UnityEngine;
using System.Collections;

public class TestInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<string>().FromInstance("Hello World!");
        Container.Bind<IGreeter>().To<Greeter>().AsSingle().NonLazy();
    }
}

public class Greeter : IGreeter
{
    string id = System.Guid.NewGuid().ToString();
    [Inject]
    string message;
    public void Start()
    {
        Debug.Log(this.id);
        Debug.Log(message);
    }
}
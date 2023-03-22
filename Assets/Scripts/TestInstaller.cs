using Zenject;
using UnityEngine;
using System.Collections;

public class TestInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<string>().FromInstance("Hello World from a Mock class that implements IGreeter interface!");
        Container.Bind<IGreeter>().To<GreeterMock>().AsSingle().NonLazy();
    }
}

public class GreeterMock : IGreeter
{
    string id = System.Guid.NewGuid().ToString();
    [Inject]
    string message;
    public void Start()
    {
        Debug.Log(this.id);
        Debug.Log(message);
    }

    public void SayHello(UserJoinedSignal userJoinedInfo){
        Debug.Log("Hello " + userJoinedInfo.Username + "! From a Mock class that implements IGreeter interface!");
    }
}
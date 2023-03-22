using Zenject;
using UnityEngine;
using System.Collections;
using System;
using System.Linq;

public class TestInstaller : MonoInstaller
{
    public UnityEngine.Object prefab;
    public override void InstallBindings()
    {
        SignalBusInstaller.Install(Container);
        Container.DeclareSignal<UserJoinedSignal>();
        Container.Bind<string>().FromInstance("Hello World!");
        Container.Bind<IGreeter>().To<Greeter>().AsSingle().NonLazy();
        Container.BindSignal<UserJoinedSignal>().ToMethod<IGreeter>(x => x.SayHello).FromResolve();
        Container.Bind<GameInitializer>().FromComponentInNewPrefab(prefab).AsSingle().NonLazy();
    }
}

public class UserJoinedSignal
{
    public string Username;
}

public class Greeter : IGreeter
{
    string id = System.Guid.NewGuid().ToString();
    [Inject]
    string message;

    readonly SignalBus _signalBus;

    public Greeter(SignalBus signalBus)
    {
        _signalBus = signalBus;
    }

    public void SayHello(UserJoinedSignal userJoinedInfo)
    {
        Debug.Log("Hello " + userJoinedInfo.Username + "!");
    }
    
    public void Start()
    {
        Debug.Log(this.id);
        Debug.Log(message);
    }
}
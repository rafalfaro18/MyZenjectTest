using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameInitializer : MonoBehaviour
{
    SignalBus _signalBus;

    [Inject]
    public void Init(SignalBus signalBus)
    {
        _signalBus = signalBus;
    }

    private void Start()
    {
        StartCoroutine(WaitToFire());
    }

    IEnumerator WaitToFire() {
        yield return new WaitForSeconds(4f);
        _signalBus.Fire(new UserJoinedSignal() { Username = "Bob" });
    }
}

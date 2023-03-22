using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TestScript : MonoBehaviour
{
    IGreeter _bar;

    [Inject]
    public void Init(IGreeter bar)
    {
        _bar = bar;
    }

    // Start is called before the first frame update
    void Start()
    {
        _bar.Start();
    }

    // Update is called once per frame
    void Update()
    {

    }
}

public interface IGreeter
{
    void Start();
    void SayHello(UserJoinedSignal userJoinedInfo);
}


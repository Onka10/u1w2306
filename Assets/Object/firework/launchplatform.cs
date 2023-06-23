using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class launchplatform : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        MasterInput.I.OnSpace
        .Subscribe(_ => Fire())
        .AddTo(this);
    }

    // Update is called once per frame
    void Fire()
    {
        // obj.Go();
    }
}

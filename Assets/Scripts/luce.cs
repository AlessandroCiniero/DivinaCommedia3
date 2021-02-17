using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class luce : MonoBehaviour
{
    Light myLight;

    void Start()
    {
        myLight = GetComponent<Light>();
    }

    void Update()
    {
        if (VirgilioSuicidi.state == 3)
            myLight.intensity = 2000f;
        else
            myLight.intensity = 0f;

    }
}

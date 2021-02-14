using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passi : MonoBehaviour
{
    AudioSource _passo;

    // Start is called before the first frame update
    void Start()
    {
        _passo = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //
        
        if (Input.GetKeyDown("w") || Input.GetKeyDown("a") || Input.GetKeyDown("s") || Input.GetKeyDown("d"))
        
        {
            _passo.Play();
        }
       else if (Input.GetKeyUp("w") || Input.GetKeyUp("a") || Input.GetKeyUp("s") || Input.GetKeyUp("d"))
       
        {
            if (!(Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d")))
            _passo.Stop();
        }
    }
}

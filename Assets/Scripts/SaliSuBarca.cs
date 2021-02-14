using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaliSuBarca : MonoBehaviour
{
    private bool asd;
    // Start is called before the first frame update
    void Start()
    {
        asd = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (VirgilioIracondi.state == 0 && asd)
        {
            Debug.Log("Dante sale");
            asd = false;
            transform.position = new Vector3(695.42f, 3.2f, 864.45f);
        }
    }
}

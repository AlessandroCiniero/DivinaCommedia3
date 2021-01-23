using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutscene : MonoBehaviour
{
    private float asd = 0f;
    public GameObject virgilio;
    
    void Start()
    {
        
    }

    void Update()
    {
        asd += Time.deltaTime;
        Debug.Log(asd);

        if (asd > 5) {
            virgilio.transform.Translate(1, 1, 1);
         }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arpia : MonoBehaviour
{
    float timeCounter = 0;
    public float speed;
    float width;
    float height;

    // Start is called before the first frame update
    void Start()
    {
        
        speed = 15;
        
        /*width = 40;
        height = 40;*/
    }

    // Update is called once per frame
    void Update()
    {
        timeCounter = Time.deltaTime*speed;
        /* float x = Mathf.Cos(timeCounter)*width + 334;
         float y = 70;
         float z = Mathf.Sin(timeCounter)*height + 374;
         transform.position = new Vector3(x, y, z);
     */
        transform.Rotate(0, timeCounter, 0);

    }
}

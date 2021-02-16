using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaliSuBarca : MonoBehaviour
{
    private bool asd;
    public GameObject boat;

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


        //CAMBIO SCENA
        if (boat.transform.position.x < 330 && VirgilioIracondi.state == 4 && MouseLook.active == true)
        {
            SceneManager.LoadScene("Cutscene#1");
        }
    }
}

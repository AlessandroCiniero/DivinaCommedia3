using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class pergamena : MonoBehaviour
{

    public GameObject _pergamena;

    public void Start() {

        
    }

    public void Update()
    {
        if (Input.GetKeyDown("e")) {
            Debug.Log("toggle pergamena");
            TogglePergamena();
        }

    }

    public void TogglePergamena() {

        if (_pergamena != null)
        {
            bool isActive = _pergamena.activeSelf;
            _pergamena.SetActive(!isActive);
        }
    }
}

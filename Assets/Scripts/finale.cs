using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class finale : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(ExampleCoroutine());

    }

    IEnumerator ExampleCoroutine()
    {

        yield return new WaitForSeconds(10);

        Esci();
    }

    public void Esci()
    {
        Debug.Log("Esci!");
        Application.Quit();
    }
}

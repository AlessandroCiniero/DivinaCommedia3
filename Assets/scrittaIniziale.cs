using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class scrittaIniziale : MonoBehaviour
{
    public Animator animator;

    void Start()
    {
        StartCoroutine(ExampleCoroutine());
    }

    IEnumerator ExampleCoroutine()
    {

        yield return new WaitForSeconds(12);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}

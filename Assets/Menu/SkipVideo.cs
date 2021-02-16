using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SkipVideo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ExampleCoroutine());

    }

    IEnumerator ExampleCoroutine()
    {

        yield return new WaitForSeconds(12);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space")) {

            SceneManager.LoadScene("Iracondi_scena");

        }
    }
}

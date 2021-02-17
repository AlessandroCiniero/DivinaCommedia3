using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CambioScena : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Eretici_scena" && VirgilioEretici.state == 3 && transform.position.x > 1130 && transform.position.z < 300)
        {
            SceneManager.LoadScene("Violenti_scena");
        }
        if (SceneManager.GetActiveScene().name == "Violenti_scena" && VirgilioViolenti.state == 4 && transform.position.x > 840)
        {
            SceneManager.LoadScene("Suicidi_scena");
        }
        if (SceneManager.GetActiveScene().name == "Violenti_scena" && VirgilioViolenti.state == 5 && transform.position.x > 840)
        {
            SceneManager.LoadScene("Suicidi_scena");
        }
        if (SceneManager.GetActiveScene().name == "Suicidi_scena" && VirgilioSuicidi.state == 3 && transform.position.z < 70 && transform.position.x > 610 && transform.position.x < 700)
        {
            SceneManager.LoadScene("schermataFinale");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Dante Entrato nel trigger");
    }
}

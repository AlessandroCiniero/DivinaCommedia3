using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    void Start()
    {
        Cursor.visible = true;
    }
    public void Gioca()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Esci() {
        Debug.Log("Esci!");
        Application.Quit();
    }
}

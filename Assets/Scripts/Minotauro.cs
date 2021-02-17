using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Minotauro : Interactable
{
    private float distance;


    public GameObject InfoText;
    public GameObject ContinueText;
    public GameObject DanteController;




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        distance = InteractionManager.distance;
    }


    public override void Interact(GameObject caller)
    {
        InteractionManager.active = false;

        //Lock rotation and movement
        MouseLook.active = false;
        PlayerMovement.active = false;



        InfoText.GetComponent<Text>().text = "Il Minotauro si morde sopraffatto dall’ira. Non obbedisce agli ordini di Virgilio, sembra che tu debba ancora trovare qualcosa.";

        ContinueText.GetComponent<Text>().text = "Clicca per continuare.";


        //Left Click to Continue

        StartCoroutine(WaitForLeftClick());

    }


    IEnumerator WaitForLeftClick()
    {
        yield return new WaitForSeconds(1f);
        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {

                InfoText.GetComponent<Text>().text = "";
                ContinueText.GetComponent<Text>().text = "";

                InteractionManager.active = true;
                MouseLook.active = true;
                PlayerMovement.active = true;


                yield break;
            }

            yield return null;
        }
    }

    public override bool ObtainType()
    {
        return false;
    }
}
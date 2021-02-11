using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;


public class Ramo : Interactable
{
    private float distance;

    public GameObject DialogueName;
    public GameObject DialogueText;
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
        if (VirgilioSuicidi.state == 0 || VirgilioSuicidi.state == 1)
        {
            //Set State 0-->2/1-->3
            VirgilioSuicidi.state += 2;

            //Lock Interaction
            InteractionManager.active = false;

            //Lock rotation and movement
            MouseLook.active = false;
            PlayerMovement.active = false;

            //Break Ramo






            DialogueName.GetComponent<Text>().text = "PIER DELLE VIGNE";

            DialogueText.GetComponent<Text>().text = "Perché mi spezzi?";

            ContinueText.GetComponent<Text>().text = "Clicca per continuare.";




            //Left Click to Continue

            StartCoroutine(WaitForLeftClick());



            //StartCoroutine(ResetChat());
        }

    }

    IEnumerator ResetChat()
    {
        yield return new WaitForSeconds(5f);
        DialogueName.GetComponent<Text>().text = "";
        DialogueText.GetComponent<Text>().text = "";

        InteractionManager.active = true;
        MouseLook.active = true;
        PlayerMovement.active = true;

        //Reset animation and movement

    }

    IEnumerator WaitForLeftClick()
    {
        yield return new WaitForSeconds(1f);
        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                DialogueName.GetComponent<Text>().text = "";
                DialogueText.GetComponent<Text>().text = "";
                ContinueText.GetComponent<Text>().text = "";

                InteractionManager.active = true;
                MouseLook.active = true;
                PlayerMovement.active = true;

                yield break;
            }

            yield return null;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;


public class Cespuglio : Interactable
{
    private float distance;

    public GameObject DialogueName;
    public GameObject DialogueText;
    public GameObject ContinueText;
    public GameObject DanteController;
    bool m_Play;

    public AudioSource[] ass;

    // Start is called before the first frame update
    void Start()
    {
        ass = GetComponents<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        distance = InteractionManager.distance;
    }


    public override void Interact(GameObject caller)
    {
        if (VirgilioSuicidi.state == 0 || VirgilioSuicidi.state == 2)
        {
            //Set State 0-->1/2-->3
            VirgilioSuicidi.state++;

            //Lock Interaction
            InteractionManager.active = false;

            //Lock rotation and movement
            MouseLook.active = false;
            PlayerMovement.active = false;


            //Bush Sound
            ass[0].Play();



            DialogueName.GetComponent<Text>().text = "ANIMA FIORENTINA";

            DialogueText.GetComponent<Text>().text = "O anime che siete giunte a vedere lo scempio disonesto che ha separato da me le mie fronde, raccoglietele al piede del triste cespuglio. Io mi impiccai nella mia casa";

            ContinueText.GetComponent<Text>().text = "Clicca per continuare.";




            //Left Click to Continue

            StartCoroutine(WaitForLeftClick());



            //StartCoroutine(ResetChat());
        }

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

                ass[1].Play();


                yield break;
            }

            yield return null;
        }
    }


}
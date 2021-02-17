using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class AnimeEretici : Interactable
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



        InfoText.GetComponent<Text>().text = "Ogni eresiarca è sepolto vicino ai suoi seguaci e più l’eresia commessa è grave più sono alte le fiamme che li imprigionano. Saranno tutti richiusi quando le anime torneranno qui dalla valle di Giudizio Universale coi corpi che hanno lasciato sulla Terra.";

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
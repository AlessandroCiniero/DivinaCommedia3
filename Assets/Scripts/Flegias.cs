using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;


public class Flegias : Interactable
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

        if (VirgilioIracondi.state == 0)
        {
            //Set State 0-->1
            VirgilioIracondi.state++;



            //fai partire barca

            //quando la barca è arrivata state++


        }
    }
}
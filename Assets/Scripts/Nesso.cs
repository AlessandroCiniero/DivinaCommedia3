using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;


public class Nesso : Interactable
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
        if (VirgilioViolenti.state == 1) //parlo con Nesso per la prima volta
        {
            //Set State 1-->2
            VirgilioViolenti.state++;

            //Lock Interaction
            InteractionManager.active = false;

            //Lock rotation and movement
            MouseLook.active = false;
            PlayerMovement.active = false;
            //this.transform.LookAt(new Vector3(DanteController.transform.position.x, this.transform.position.y, DanteController.transform.position.y));


            DialogueName.GetComponent<Text>().text = "NESSO";

            DialogueText.GetComponent<Text>().text = "Seguitemi.";

            ContinueText.GetComponent<Text>().text = "Clicca per continuare.";


            //Left Click to Continue

            StartCoroutine(WaitForLeftClick());

        }

        if (VirgilioViolenti.state == 3)
        {
            //Set State 3-->4
            //VirgilioViolenti.state++;

            //Lock Interaction
            InteractionManager.active = false;

            //Lock rotation and movement
            MouseLook.active = false;
            PlayerMovement.active = false;
            //this.transform.LookAt(new Vector3(DanteController.transform.position.x, this.transform.position.y, DanteController.transform.position.y));


            DialogueName.GetComponent<Text>().text = "NESSO";

            DialogueText.GetComponent<Text>().text = "Sono tiranni, che offesero gli altri nella persona e negli averi. Così come tu vedi, da questa parte, che il liquido bollente man mano si abbassa, voglio che tu creda che dall'altra parte il fiume abbassa progressivamente il fondale, finché raggiunge il punto dove i tiranni gemono.";

            ContinueText.GetComponent<Text>().text = "Clicca per continuare.";

           

            //Left Click to Continue

            StartCoroutine(WaitForLeftClick());


        }
        if (VirgilioViolenti.state == 5) //parlo con Nesso per la ultima volta (facoltativo)
        {
            
            //Lock Interaction
            InteractionManager.active = false;

            //Lock rotation and movement
            MouseLook.active = false;
            PlayerMovement.active = false;
            //this.transform.LookAt(new Vector3(DanteController.transform.position.x, this.transform.position.y, DanteController.transform.position.y));


            DialogueName.GetComponent<Text>().text = "NESSO";

            DialogueText.GetComponent<Text>().text = "Attraversate il ponte più avanti. Vi condurrà al secondo girone di questo cerchio.";

            ContinueText.GetComponent<Text>().text = "Clicca per continuare.";


            //Left Click to Continue

            StartCoroutine(WaitForLeftClick());

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

                if (VirgilioViolenti.state == 2)
                {
                    //bisogna cominciare il movimento e aspettare se Dante è troppo lontano
                    //alla fine bisogna aggiornare lo stato a 3
                    //VirgilioViolenti.state = 3;
                }
                if (VirgilioViolenti.state == 3)
                {
                    VirgilioViolenti.state++;
                }

                yield break;
            }

            yield return null;
        }
    }


}
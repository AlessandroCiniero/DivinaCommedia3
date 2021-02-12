using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;


public class VirgilioViolenti : Interactable
{
    private float distance;
    public static int state = 0;
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
        //Lock Interaction
        InteractionManager.active = false;

        //Lock rotation and movement
        MouseLook.active = false;
        PlayerMovement.active = false;

        //Set animation rotation and movement

        this.GetComponent<Animator>().Play("Idle");
        this.GetComponent<NavMeshAgent>().enabled = false;
        this.GetComponent<Movimento>().enabled = false;


        //this.transform.LookAt(new Vector3(DanteController.transform.position.x, this.transform.position.y, DanteController.transform.position.y));

        if (state == 0) //bisogna parlare con chirone
        {
            DialogueName.GetComponent<Text>().text = "VIRGILIO";

            DialogueText.GetComponent<Text>().text = "Osserva, Dante. Nel fiume di sangue bollente chiamato Flegetonte, sono dannati i violenti contro il prossimo. Trova il capo di quei centauri di guardia, forse saprà indicarci la strada. Ricordati anche di controllare la tua pergamena.";

            ContinueText.GetComponent<Text>().text = "Clicca per continuare.";
        }
        
        if (state == 1) //parlato con chirone, bisogna parlare con nesso
        {
            DialogueName.GetComponent<Text>().text = "VIRGILIO";

            DialogueText.GetComponent<Text>().text = "Parla con Nesso.";

            ContinueText.GetComponent<Text>().text = "Clicca per continuare.";
        }

        //state 2

        if (state == 2) //parlato con nesso, bisogna seguirlo
        {
            DialogueName.GetComponent<Text>().text = "VIRGILIO";

            DialogueText.GetComponent<Text>().text = "Continua a seguire Nesso. Saprà condurci in un punto in cui il fiume sarà attraversabile";

            ContinueText.GetComponent<Text>().text = "Clicca per continuare.";
        }

        //state 3

        if (state == 3) //nesso si è fermato
        {
            DialogueName.GetComponent<Text>().text = "VIRGILIO";

            DialogueText.GetComponent<Text>().text = "Parla nuovamente con Nesso.";

            ContinueText.GetComponent<Text>().text = "Clicca per continuare.";
        }

        //state 4 fine livello

        //Left Click to Continue

        StartCoroutine(WaitForLeftClick());



        //StartCoroutine(ResetChat());
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
        //this.GetComponent<Animator>().Play("Standard Walk");
        this.GetComponent<NavMeshAgent>().enabled = true;
        this.GetComponent<Movimento>().enabled = true;

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

                //Reset animation and movement
                //this.GetComponent<Animator>().Play("Standard Walk");
                this.GetComponent<NavMeshAgent>().enabled = true;
                this.GetComponent<Movimento>().enabled = true;

                yield break;
            }

            yield return null;
        }
    }
}
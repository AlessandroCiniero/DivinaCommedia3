using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.SceneManagement;


public class Info : Interactable
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
        //if this object is . then...

        InteractionManager.active = false;

        //Lock rotation and movement
        MouseLook.active = false;
        PlayerMovement.active = false;

        if (SceneManager.GetActiveScene().name == "Iracondi_scena")
        {
            InfoText.GetComponent<Text>().text = "I Dannati immersi nel pantano fangoso sono coloro che peccarono d’ira. Sono nudi e dall’aspetto triste. Si colpiscono non solo con le mani, ma con la testa, il petto, i piedi e si strappano la carne a morsi. Sotto l’acqua ci sono anime che sospirano facendo gorgogliare la superficie dell’acqua, come puoi facilmente sentire…";

            ContinueText.GetComponent<Text>().text = "Clicca per continuare.";
        }

        if (SceneManager.GetActiveScene().name == "Eretici_scena")
        {
            InfoText.GetComponent<Text>().text = "Qui ci sono gli eresiarchi coi loro seguaci d'ogni setta, essi risiedono nelle tombe che sono cosparse delle fiamme, che li arroventano in modo tale che nessun lavoro artigianale richiede un ferro più caldo. Tutti i coperchi sono aperti e puntellati, e ne escono lamenti così miseri che sembrano proprio quelli di anime dannate.";

            ContinueText.GetComponent<Text>().text = "Clicca per continuare.";
        }

        if (SceneManager.GetActiveScene().name == "Violenti_scena")
        {
            InfoText.GetComponent<Text>().text = "I Violenti hanno come pena quella di essere immersi nel sangue bollente che riempe il fiume del Flegetonte. Alcune anime sono immerse fino alle ciglia, coloro che offesero gli altri nella persona e negli averi. Alcuni sembrano uscire dal sangue fino alla gola. Dei dannati tengono fuori dal fiume la testa e tutto il petto. In determinati punti il sangue diventa sempre più basso, così che cuoce solo i piedi dei dannati.";

            ContinueText.GetComponent<Text>().text = "Clicca per continuare.";
        }

        if (SceneManager.GetActiveScene().name == "Suicidi_scena")
        {
            InfoText.GetComponent<Text>().text = "I suicidi soffrono come pena quella di essere trasformati in alberi, tormentati dalle azioni delle arpie. Le foglie non sono verdi, ma di colore scuro; i rami non sono lisci, ma nodosi e contorti; non ci sono frutti, ma spine velenose. Si levano lamenti da ogni parte, ma si vede nessuno che li emette.";

            ContinueText.GetComponent<Text>().text = "Clicca per continuare.";
        }




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
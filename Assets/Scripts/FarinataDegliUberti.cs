using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;


public class FarinataDegliUberti : Interactable
{
    private float distance;

    public GameObject DialogueName;
    public GameObject DialogueText;
    public GameObject ContinueText;
    public GameObject DanteController;

    AudioSource _risata;
    AudioSource _feedback;
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
        if (VirgilioEretici.state == 0 || VirgilioEretici.state == 1)
        {
            //Set State 0-->2/1-->3
            VirgilioEretici.state += 2;
            ass[0].Play();

            //Lock Interaction
            InteractionManager.active = false;

            //Lock rotation and movement
            MouseLook.active = false;
            PlayerMovement.active = false;



            DialogueName.GetComponent<Text>().text = "FARINATA DEGLI UBERTI";

            DialogueText.GetComponent<Text>().text = "O toscano, che te ne vai per la città del fuoco parlando in modo così dignitoso, abbi la compiacenza di trattenerti. Il tuo accento indica che sei nato in quella nobile patria alla quale, forse, fui troppo fastidioso.";

            ContinueText.GetComponent<Text>().text = "Clicca per continuare.";




            //Left Click to Continue

            StartCoroutine(Dialogue1());


        }

    }

    IEnumerator Dialogue1()
    {
        yield return new WaitForSeconds(1f);
        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                DialogueText.GetComponent<Text>().text = "Chi furono i tuoi avi?";
                StartCoroutine(Dialogue2());
                yield break;
            }

            yield return null;
        }
    }

    IEnumerator Dialogue2()
    {
        yield return new WaitForSeconds(1f);
        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                DialogueText.GetComponent<Text>().text = "Essi furono aspri nemici miei, dei miei avi e della mia parte politica(Ghibellini), al punto che per due volte li cacciai da Firenze.";
                StartCoroutine(Dialogue3());
                yield break;
            }

            yield return null;
        }
    }

    IEnumerator Dialogue3()
    {
        yield return new WaitForSeconds(1f);
        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                DialogueName.GetComponent<Text>().text = "DANTE";
                DialogueText.GetComponent<Text>().text = "Se essi furono cacciati, tornarono poi da ogni parte, in entrambe le occasioni; ma i vostri avi, invece, non furono altrettanto bravi.";
                StartCoroutine(Dialogue4());
                yield break;
            }

            yield return null;
        }
    }

    IEnumerator Dialogue4()
    {
        yield return new WaitForSeconds(1f);
        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                DialogueName.GetComponent<Text>().text = "FARINATA DEGLI UBERTI";
                DialogueText.GetComponent<Text>().text = "Se i miei avi hanno appreso male l'arte di rientrare in Firenze, ciò mi procura più sofferenza di questa tomba. Ma non passeranno cinquanta fasi lunari (meno di quattro anni) che anche tu saprai quant'è dolorosa quell'arte";
                StartCoroutine(WaitForLeftClick());
                yield break;
            }

            yield return null;
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

                //feedback +
                ass[1].Play();

                yield break;
            }

            yield return null;
        }
    }


}
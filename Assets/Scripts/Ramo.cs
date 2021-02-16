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
    private Rigidbody _rb;

    public AudioSource[] ass;


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.isKinematic = true; // Activated

        ass = GetComponents<AudioSource>();

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
            _rb.isKinematic = false;  // Deactivated

            //Snap Sound
            ass[0].Play();



            DialogueName.GetComponent<Text>().text = "PIER DELLE VIGNE";

            DialogueText.GetComponent<Text>().text = "Perché mi spezzi?";

            ContinueText.GetComponent<Text>().text = "Clicca per continuare.";




            //Left Click to Continue

            StartCoroutine(Dialogue1());



            //StartCoroutine(ResetChat());
        }

    }

    IEnumerator Dialogue1()
    {
        yield return new WaitForSeconds(1f);
        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                DialogueText.GetComponent<Text>().text = "Perché mi laceri? Non hai alcuno spirito di pietà? Fummo uomini, e adesso siamo diventati cespugli: la tua mano sarebbe certamente più pietosa, se anche fossimo state anime di serpenti";
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
                DialogueText.GetComponent<Text>().text = "Con le tue dolci parole mi alletti in tal modo che non posso stare zitto e a voi non sia fastidioso se io mi attardo un po' a parlare di me. Io sono colui che tenne entrambe le chiavi del cuore di Federico II, e che le usò così bene nel chiudere e nell'aprire.";
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
                DialogueText.GetComponent<Text>().text = "Il mio animo, spinto da un amaro piacere, credendo di sfuggire il disonore con la morte, mi rese ingiusto contro me stesso, che pure non avevo colpe. Come le altre anime, anche noi andremo a riprendere i nostri corpi(il giorno del Giudizio), ma non per rivestircene: infatti non è giusto riavere ciò che ci si è tolti.";
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
                DialogueText.GetComponent<Text>().text = "Li trascineremo qui e i nostri corpi saranno appesi per la triste selva, ciascuno all'albero della propria ombra nemica.";
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

                ass[1].Play();

                yield break;
            }

            yield return null;
        }
    }

    public override bool ObtainType()
    {
        return true;
    }

}
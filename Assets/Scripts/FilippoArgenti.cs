using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;


public class FilippoArgenti : Interactable
{
    private float distance;

    public GameObject DialogueName;
    public GameObject DialogueText;
    public GameObject ContinueText;
    public GameObject DanteController;

    AudioSource _feedback;


    // Start is called before the first frame update
    void Start()
    {
        _feedback = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = InteractionManager.distance;
    }
    

    public override void Interact(GameObject caller)
    {
        if (VirgilioIracondi.state == 2)
        {

            //Lock Interaction
            InteractionManager.active = false;

            //Lock rotation and movement
            MouseLook.active = false;
            PlayerMovement.active = false;



            DialogueName.GetComponent<Text>().text = "FILIPPO ARGENTI";

            DialogueText.GetComponent<Text>().text = "Tu chi sei, che giungi all'Inferno prima del tempo?";

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
                DialogueText.GetComponent<Text>().text = "O anima disdegnosa, benedetta colei che rimase incinta di te! Quello nel mondo fu una persona orgogliosa; non c'è alcuna sua buona azione che renda onore alla sua memoria, così la sua anima è qui, furiosa.";
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
                DialogueText.GetComponent<Text>().text = "Quanti uomini si credono in vita dei grandi re, mentre qui all'Inferno saranno come porci nel fango, lasciando di sé un orribile ricordo!";
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
                DialogueText.GetComponent<Text>().text = "Maestro, avrei gran desiderio di vederlo sprofondare in questa melma, prima di lasciare la palude.";
                StartCoroutine(Dialogue3());
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
                DialogueName.GetComponent<Text>().text = "ANIME";
                DialogueText.GetComponent<Text>().text = "Addosso a Filippo Argenti!";
                //far partire l'animazione delle anime che si buttano su filippo
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

                //Set State 2-->3 

                if (VirgilioIracondi.state == 2)
                { 
                    VirgilioIracondi.state = 3;
                    _feedback.Play();
                
                }
                //far ripartire la barca
                //nello script della barca appena si ferma far passare o stato a 4


                yield break;
            }

            yield return null;
        }
    }


}
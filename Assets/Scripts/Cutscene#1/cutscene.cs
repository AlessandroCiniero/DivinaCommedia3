using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutscene : MonoBehaviour
{
    private float asd = 0f;
    public Animator _animatorVirgilio;
    public Animator _animatorDemone;

    public GameObject _virgilio;
    public GameObject _demone;
    public GameObject _cancello;

    private bool primaVoltaVirgilio;
    private bool primaVoltaDemone;

    void Start()
    {
        primaVoltaVirgilio = true;
        primaVoltaDemone = true;

    }

    void Update()
    {
        asd += Time.deltaTime;
        Debug.Log(asd);

        //CANCELLO
        if (asd > 36)
        {
            _cancello.transform.Translate(0, 0.13f, 0);
        }

        //VIRGILIO
        if (asd > 33) {
            _animatorVirgilio.SetBool("virgilioCammina", false);
        }
        else if (asd > 26)
        {
            if (primaVoltaVirgilio)
            {
                primaVoltaVirgilio = false;
                _virgilio.transform.Rotate(0, 180, 0);
            }

            _animatorVirgilio.SetBool("virgilioCammina", true);
        }
        else if (asd > 18)
        {
            _animatorVirgilio.SetBool("virgilioCammina", false);
            //virgilio.transform.Rotate(0, 180, 0);
        }
        else if (asd > 11) {
            _animatorVirgilio.SetBool("virgilioCammina", true);
        }
        else _animatorVirgilio.SetBool("virgilioCammina", false);


        //DEMONE
        if (asd > 31)
        {
            if (primaVoltaDemone)
            {
                primaVoltaDemone = false;
                _demone.transform.Rotate(0, 180, 0);
            }
            _animatorDemone.SetBool("demoneCammina", true);
            _animatorDemone.SetBool("demoneEsulta", false);
        }
        else if (asd > 28)
        {
            _animatorDemone.SetBool("demoneCammina", false);
            _animatorDemone.SetBool("demoneEsulta", false);
        }
        else if (asd > 18)
        {
            _animatorDemone.SetBool("demoneCammina", false);
            _animatorDemone.SetBool("demoneEsulta", true);
        }
        else if (asd > 14)
        {
            _animatorDemone.SetBool("demoneCammina", true);
        }

    }
}

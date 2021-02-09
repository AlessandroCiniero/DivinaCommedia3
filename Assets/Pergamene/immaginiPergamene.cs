using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class immaginiPergamene : MonoBehaviour
{
    private Image _image; 

    public Sprite sprite1;
    public Sprite sprite2;
    public int asd;

    void Start()
    {
        _image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (asd == 0)
            _image.sprite = sprite1;
        else 
            _image.sprite = sprite2;
    }
}

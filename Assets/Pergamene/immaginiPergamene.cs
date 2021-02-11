using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class immaginiPergamene : MonoBehaviour
{
    private Image _image; 

    public Sprite vuoto;
    public Sprite parziale1;
    public Sprite parziale2;
    public Sprite pieno;

    private int state;

    void Start()
    {
        _image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        state = VirgilioSuicidi.state;
        if (state == 0)
            _image.sprite = vuoto;
        else if (state == 2)
            _image.sprite = parziale1;
        else if (state == 1)
            _image.sprite = parziale2;
        else if (state == 3)
            _image.sprite = pieno;
    }
}

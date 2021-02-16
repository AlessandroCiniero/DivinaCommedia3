﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public abstract bool ObtainType();
    public abstract void Interact(GameObject caller);
}

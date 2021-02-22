using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimeRandomiche : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator _anim;

    void Start()
    {
        StartCoroutine(ExampleCoroutine());
        _anim = GetComponent<Animator>();

    }

    IEnumerator ExampleCoroutine()
    {

        yield return new WaitForSeconds(Random.Range(5, 15));

        _anim.SetInteger("a", Random.Range(0, 3));

        StartCoroutine(ExampleCoroutine());

    }


    // Update is called once per frame
    void Update()
    {

    }
}

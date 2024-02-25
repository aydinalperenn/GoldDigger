using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeAnimation : MonoBehaviour
{

    float timer = 2f;

    void Start()
    {
        
    }


    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            GetComponent<Animator>().Play(0);
            timer = Random.Range(1.5f, 3f);
        }
    }
}

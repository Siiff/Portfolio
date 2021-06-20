using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float frente;
    //float re;
    float girar;
    // Start is called before the first frame update
    void Start()
    {
        frente = 10;
        girar = 60;
        //re = 5;
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, (frente * Time.deltaTime));
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, (-frente * Time.deltaTime));
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, (- girar * Time.deltaTime), 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, (girar * Time.deltaTime), 0);
        }
    }
}

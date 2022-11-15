using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kure : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody kure;
    void Start()
    {
        kure = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-1*Time.deltaTime,0,0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(1 * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, 1 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -1 * Time.deltaTime);
        }


    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        print(gameObject.name + " ve " + collisionInfo.collider.tag + " arasinda çarpişma algilandi.");
    }
}

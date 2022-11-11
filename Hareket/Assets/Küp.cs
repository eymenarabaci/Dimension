using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Küp : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody kup;
    private int a = 2;

    void Start()
    {
        kup = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
            kup.AddForce(0, 0, 0);
        
    }
}

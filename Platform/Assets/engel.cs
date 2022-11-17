using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class engel : MonoBehaviour
{
    GameObject Player;
    bool OnPlane;
    Transform P_transform;
    float z;
    float fark;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      Player = GameObject.FindGameObjectWithTag("Player");
        OnPlane = Player.GetComponent<Character_kontrol>().onPlane;
        P_transform = Player.GetComponent<Transform>();
        z = (float)transform.position.z;
        fark = z - (float)P_transform.position.z;
        print(fark);
        if(OnPlane == true)
        {
            
         if(fark <= 3)
            {
              z  += (float)2.5;
              this.transform.position = new Vector3 (transform.position.x,transform.position.y,z);
            }
        }
    }
}

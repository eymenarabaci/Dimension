using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sahte : MonoBehaviour
{
    public List<GameObject> myList = new List<GameObject>();
    int i = 0;
    int rasgele;
    GameObject Gercek;
    int j = 0;


    // Start is called before the first frame update
    void Start()
    {
        while (myList.Count <= transform.childCount-1)
        {
            myList.Add(transform.GetChild(i).gameObject);
            i++;
        }

        

    }

    // Update is called once per frame
    void Update()
    {
        while (j <= 0){rasgele = Random.Range(1, 4); j++;}
        print("rasgele = " + rasgele);
        Gercek = myList[rasgele];
        int re = rasgele;
        print(Gercek.name);
        Gercek.tag = "Gercek";
        print(Gercek.tag);
        
        

    }
}

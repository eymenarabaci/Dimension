using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraTakip : MonoBehaviour
{
    public GameObject Hedef_obj;
    public Transform Hedef;
    public Vector3 Hedef_Mesafe;
    public int Hýz;
    private bool jump;
    private float fareX, fareY;
    public float hassasiyet;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        jump = Hedef_obj.GetComponent<Character_kontrol>().finish_jump;

        if (jump == false)
        {

            Hýz = 600;

        }

        else
        {
            Hýz = 20;
        }

    }
    private void LateUpdate()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, Hedef.position + Hedef_Mesafe, Time.deltaTime * Hýz);
        fareX += Input.GetAxis("Mouse X") * hassasiyet;
        fareY += Input.GetAxis("Mouse Y") * hassasiyet;
        this.transform.eulerAngles = new Vector3(-fareY, fareX, 0);
        Hedef.transform.eulerAngles = new Vector3(0, fareX, 0);
    }
}
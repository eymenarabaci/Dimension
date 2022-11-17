using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_kontrol : MonoBehaviour
{
    public Animator Hareket;
    public Rigidbody Character;
    public bool onPlane;
    public bool finish_jump;
    public float jump_speed;
    public float Speed;
    private int plane = 3;
    public GameObject stater_point;
    private Vector3 last_point;
    private GameObject carp;
    public GameObject engel;
    private Vector3 engel_start;
    bool hareketli;

    void Start()
    {
        engel_start = engel.transform.position;
        Character = GetComponent<Rigidbody>();
       last_point = stater_point.transform.position;
        hareketli = true;

    }
    IEnumerator Timer()
    {
        onPlane = false;
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => finish_jump == true);
        Hareket.SetTrigger("finish_jump");
        Hareket.ResetTrigger("Jump");
        onPlane = true;
    }
    IEnumerator Timer1(Collision collision)
    {
        carp = collision.gameObject;
        carp.SetActive(false);
        yield return new WaitForSeconds((float)0.2);
        hareketli = false;
        yield return new WaitForSeconds((float)0.4);
        hareketli = true;
        carp.SetActive(true);


    }
    void Update()
    {
       if(hareketli == true) {
            Walk();
            if (Input.GetKey(KeyCode.Space) && onPlane == true)
            {
                Hareket.SetTrigger("Jump");
                Hareket.ResetTrigger("IDLE");
                Jump();
                StartCoroutine(Timer());
            }
        }
    }
    void Walk()
    {
        float yatay = Input.GetAxis("Horizontal");
        float dikey = Input.GetAxis("Vertical");
        Hareket.SetFloat("Horizontal", yatay);
        Hareket.SetFloat("Vertical", dikey);
        this.gameObject.transform.Translate(yatay * (float)Speed * Time.deltaTime, 0,dikey * (float)Speed * Time.deltaTime);
    }
    void Jump()
    {
        Character.AddForce(0,(float)jump_speed,0,ForceMode.Impulse);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.layer == plane && collision.gameObject.tag != "sahte") //eðer platform etiketli nesneye deðerse
        {
            Debug.Log("Yerde");
            onPlane = true; //yerDemi deðiþkeninin deðerini true(doðru) yap.
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == plane && collision.gameObject.tag != "sahte") //eðer platform etiketli nesneye deðerse
        {
            Debug.Log("Yerde deðil");
            Hareket.ResetTrigger("finish_jump");
            onPlane = false;
            finish_jump = false;
        }  
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.layer == plane) //eðer platform etiketli nesneye deðerse
        {
            if (collision.gameObject.tag != "sahte")
            {
                Debug.Log("Yerde");
                finish_jump = true; //finish_jump deðiþkeninin deðerini true(doðru) yap. 
            }
            else
            {

                StartCoroutine(Timer1(collision));

            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "tuzak") {
            transform.position = last_point;
            engel.transform.position = engel_start;
        }
        if (other.tag == "kontrol")
        {
            last_point = other.transform.position;
            engel.transform.position = engel_start;
        }
    }
}

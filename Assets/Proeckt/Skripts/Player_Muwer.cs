using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Player_Muwer : MonoBehaviour
{
    public float speed, helse;
    public Vector3 muwe;
    public Transform bodey, cam;
    public Rigidbody rb;
    public Image helser;
    public Animator anim, damag;
    float timer = 0;
    public static Player_Muwer rid { get; set; }
    void Awake()
    {
        if (rid == null)
        {
            rid = this;
        }
        else
        {
            Destroy(this);
        }
    }
    void OnDestroy()
    {
        rid = null;
    }

    public void Damag(Vector3 nap)
    {
        if (helse > 10)
        {
            rb.AddForce(nap * 10);
            helse -= 10;
            helser.fillAmount = helse / 100;
            damag.SetTrigger("Damag");
        }
        else
        {
            Interface.rid.Sum(2, true, 0);
        }
    }
    public void Kik() 
    {
        if (timer < Time.time)
        {
            timer = Time.time + 0.3f;
            anim.SetTrigger("Kik");
        }
        else 
        {
            anim.SetTrigger("Kik2");
        }
    }

    private void FixedUpdate()
    {
        cam.transform.position = Vector3.Lerp(cam.transform.position, transform.position + rb.velocity, Time.deltaTime);
        if (muwe != Vector3.zero)
        {
            anim.SetFloat("Speed", rb.velocity.magnitude/3);
            bodey.rotation = Quaternion.Lerp(bodey.rotation, Quaternion.LookRotation(muwe),speed * Time.deltaTime);
            rb.AddForce(transform.forward * speed);
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
        }
        
    }
}

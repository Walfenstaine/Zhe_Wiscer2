using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    public GameObject klet;
    public Transform next;
    public GameObject kitty;
    public ParticleSystem ps;
    public void Remaine() 
    {
        Instantiate(kitty, transform.position,Quaternion.identity);
        klet.SetActive(false);
        ps.Play();
    }
    public void Reload() 
    {
        klet.SetActive(true);
        gameObject.tag = "Kitty";
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<Enemy>().OnPoint(next);
        }
    }
}

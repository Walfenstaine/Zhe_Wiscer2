using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator anim;
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player" || other.tag == "Invise" || other.tag == "Enemy" || other.tag == "TNT")
        {
            anim.SetBool("Open", true);
        }
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.tag == "Player" || other.tag == "Invise" || other.tag == "Enemy" || other.tag == "TNT")
        {
            anim.SetBool("Open", false);
        }
    }
}

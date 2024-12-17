using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Door dor;
    public string animName;
    public Animator anim;
    bool open = false;
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player" || other.tag == "Invise" || other.tag == "Neytral")
        {
            anim.SetBool(animName, true);
            dor.enabled = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.tag == "Player" || other.tag == "Invise" || other.tag == "Neytral")
        {
            dor.enabled = true;
            anim.SetBool(animName, false);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public string animName;
    public Animator anim;
    bool open = false;
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player" || other.tag == "Invise" || other.tag == "Enemy")
        {
            anim.SetBool(animName, true);

        }
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.tag == "Player" || other.tag == "Invise" || other.tag == "Enemy")
        {
            anim.SetBool(animName, false);
        }
    }
}

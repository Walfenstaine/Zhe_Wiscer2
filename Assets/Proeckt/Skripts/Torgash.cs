using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class Torgash : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Interface.rid.Sum(4, true, 0.2f);
            Droper_Inventar.rid.torg = true;
            Player_Muwer.rid.muwe = Vector3.zero;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Droper_Inventar.rid.torg = false;
    }
}

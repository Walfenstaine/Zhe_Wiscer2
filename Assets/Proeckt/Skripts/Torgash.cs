using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class Torgash : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Invise")
        {
            Droper_Inventar.rid.torg = true;
            for (int i = 0; i < Player_Muwer.rid.kitis.Count; i++)
            {
                Player_Muwer.rid.kitis[i].target = transform;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Droper_Inventar.rid.torg = false;
    }
}

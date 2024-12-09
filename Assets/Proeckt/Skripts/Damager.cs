using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
    bool damag = false;
    public void Kik()
    {
        if (damag) 
        {
            if (Player_Muwer.rid) 
            {
                var rid = Player_Muwer.rid.transform.position - transform.position;
                Player_Muwer.rid.Damag(rid);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            damag = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            damag = false;
        }
    }
}

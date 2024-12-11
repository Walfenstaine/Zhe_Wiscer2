using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class Sword : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Vector3 v = new Vector3(other.transform.position.x, Player_Muwer.rid.transform.position.y, other.transform.position.z);
            Player_Muwer.rid.transform.LookAt(v);
            if (YandexGame.savesData.svord_Helse > 20)
            {
                other.GetComponent<Enemy>().Damag((int)YandexGame.savesData.svord_Helse / 2);
            }
            else
            {
                other.GetComponent<Enemy>().Damag(10);
            }

            YandexGame.savesData.svord_Helse -= Random.Range(0, 0.2f);
        }
        else 
        {
            if (other.tag == "Kitty") 
            {
                other.tag = "Neytral";
                other.GetComponent<Point>().Remaine();
            }
        }
    }
}

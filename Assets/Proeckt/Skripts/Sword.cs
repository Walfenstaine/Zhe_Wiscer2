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
            if (YandexGame.savesData.svord_Helse > 20)
            {
                other.GetComponent<Enemy>().Damag((int)YandexGame.savesData.svord_Helse / 2);
            }
            else 
            {
                other.GetComponent<Enemy>().Damag(10);
            }
           
            YandexGame.savesData.svord_Helse -= Random.Range(0,3.2f);
        }
    }
}

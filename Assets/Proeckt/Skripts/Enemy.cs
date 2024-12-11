using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using YG;
public class Enemy : MonoBehaviour
{
    public Transform target, point;
    public GameObject[] loot;
    public NavMeshAgent agent;
    public Image helser;
    public Animator anim, ded;
    public float speed, helse;
    bool aliv = true;
    public void Damag(int damag) 
    {
        if (helse > damag)
        {
            var rid = Player_Muwer.rid.transform.position - transform.position;
            agent.velocity = (-rid * 20);
            helse -= damag;
            helser.fillAmount = helse / 100;
            anim.SetTrigger("Damag");
        }
        else 
        {
            if (aliv)
            {
                int index = Random.Range(0, 5);
                Instantiate(loot[index], transform.position, Quaternion.identity);
                YandexGame.savesData.record += 1;
                YandexGame.NewLeaderboardScores("LEADER666", YandexGame.savesData.record);
                Interface.rid.SaveGame();
                ded.SetTrigger("Dead");
                
                Destroy(gameObject,1);
                aliv = false;
            }
        }
    }
    public void OnPoint(Transform t)
    {
        point = t;
    }
    private void FixedUpdate()
    {
        if (target != null)
        {
            agent.destination = target.position;
        }
        else 
        {
            if (point != null) 
            {
                agent.destination = point.position;
            }
        }
    }
}

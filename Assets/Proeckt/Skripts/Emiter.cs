using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class Emiter : MonoBehaviour
{
    public int maxEmits;
    public List<Enemy> enemies;
    public Transform[] points;
    public GameObject prefab; 
    public float spawnInterval = 2f;

    bool active = true;
    float timer = 0;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Neytral")
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].target = Player_Muwer.rid.transform;
            }
            other.tag = "Player";
            active = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.tag == "Player")
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].target = null;
            }
            other.tag = "Neytral";
            active = true;
        }
    }

    void Emit() 
    {
        int i = Random.Range(1, maxEmits);
        for (int j = 0; j < i; j++) 
        {
            enemies.Add(Instantiate(prefab.GetComponent<Enemy>()));
            int p = Random.Range(0, points.Length);
            enemies[j].transform.position = points[p].transform.position + transform.forward;
            enemies[j].point = points[p];

        }
        for (int n = 0; n < points.Length; n++)
        {
            points[n].GetComponent<Point>().Reload();
        }
    }
    private void FixedUpdate()
    {
        if (active) 
        {
            if (enemies.Count == 0)
            {
                Emit();
            }
        }
       
        for (int i = 0; i < enemies.Count; i++) 
        {
            if (enemies[i] == null) 
            {
                enemies.RemoveAt(i);
            }
        }
    }
}

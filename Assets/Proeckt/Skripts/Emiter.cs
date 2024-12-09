using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class Emiter : MonoBehaviour
{
    public GameObject prefab; // Префаб объекта Gall
    public float spawnInterval = 2f; // Интервал между спаунами в секундах

    bool active = true;
    float timer = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            active = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            active = true;
        }
    }
    private void FixedUpdate()
    {
        if (active) 
        {
            if (Time.time > timer) 
            {
                Instantiate(prefab, transform.position, Quaternion.identity);
                timer = Time.time + spawnInterval;
            }
        }
    }
}

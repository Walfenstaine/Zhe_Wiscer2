using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public AudioClip breake;
    public float svordHelse = 100;
    public float atak;
    public static Sword rid { get; set; }
    void Awake()
    {
        if (rid == null)
        {
            rid = this;
        }
        else
        {
            Destroy(this);
        }
    }
    void OnDestroy()
    {
        rid = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Vector3 v = new Vector3(other.transform.position.x, Player_Muwer.rid.transform.position.y, other.transform.position.z);
            Player_Muwer.rid.transform.LookAt(v);
            other.GetComponent<Enemy>().Damag((int)atak);
            Debug.Log("Damag");
            svordHelse -= atak/2;
        }
        else 
        {
            if (other.tag == "Kitty") 
            {
                if (Player_Muwer.rid.kitis.Count < 10)
                {
                    SoundPlayer.regit.Play(breake);
                    other.tag = "Neytral";
                    other.GetComponent<Point>().Remaine();
                }
            }
        }
    }
    private void FixedUpdate()
    {
        if (svordHelse < 100) 
        {
            svordHelse += 3 * Time.unscaledDeltaTime;
        }
    }
}

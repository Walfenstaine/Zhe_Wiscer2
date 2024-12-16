using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class Loot : MonoBehaviour
{
    public int index_Icon;
    public AudioClip clip;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Invise")
        {
            SoundPlayer.regit.Play(clip);
            YandexGame.savesData.inv[index_Icon] += 1;
            Destroy(gameObject);
            Interface.rid.SaveGame();
        }
    }
}

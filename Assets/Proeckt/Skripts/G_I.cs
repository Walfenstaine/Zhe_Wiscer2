using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;
public class G_I : MonoBehaviour
{
    public Text coins, record;
    public Image svord;
    private void FixedUpdate()
    {
        coins.text = ": " + YandexGame.savesData.coins;
        record.text = ": " + YandexGame.savesData.record;
        svord.fillAmount = YandexGame.savesData.svord_Helse / 100;
    }
}

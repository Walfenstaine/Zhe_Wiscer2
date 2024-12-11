using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;
public class G_I : MonoBehaviour
{
    public Text coins, record, kitty;
    public Image svord, helse;
    private void FixedUpdate()
    {
        coins.text = ": " + YandexGame.savesData.coins;
        record.text = ": " + YandexGame.savesData.record;
        svord.fillAmount = YandexGame.savesData.svord_Helse / 100;
        helse.fillAmount = Player_Muwer.rid.helse / 100;
        kitty.text = ": " + Player_Muwer.rid.kitis.Count;
    }
}

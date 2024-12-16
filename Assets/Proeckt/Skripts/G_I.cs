using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;
public class G_I : MonoBehaviour
{
    public Color norm, danger;
    public Animator katama;
    public Text coins, record, kitty, kitty2;
    public Image svord, helse;

    public static G_I rid { get; set; }
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
    public void Katana()
    {
        katama.SetTrigger("And");
    }

    private void FixedUpdate()
    {
        if (Player_Muwer.rid.kitis.Count >= 10)
        {
            kitty.color = danger;
            kitty2.color = danger;
        }
        else
        {
            kitty.color = norm;
            kitty2.color = norm;
        }
        coins.text = ": " + YandexGame.savesData.coins;
        record.text = ": " + YandexGame.savesData.record;
        svord.fillAmount = Sword.rid.svordHelse/100;
        helse.fillAmount = Player_Muwer.rid.helse / 100;
        kitty.text = ": " + Player_Muwer.rid.kitis.Count;
    }
}

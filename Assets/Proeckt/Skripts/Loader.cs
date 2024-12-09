using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class Loader : MonoBehaviour
{



    public void Starter()
    {
        YandexGame.savesData.lvl = "Scene1";
        YandexGame.savesData.coins = 30;
        YandexGame.savesData.record = 0;
        YandexGame.savesData.svord_Helse = 100;
        YandexGame.SaveProgress();
        SceneManager.LoadScene(YandexGame.savesData.lvl);
    }

    public void loader() 
    {
        SceneManager.LoadScene(YandexGame.savesData.lvl);
    }
}

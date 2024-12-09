using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;
using YG;

public class Interface : MonoBehaviour
{
    public UnityEvent[] sumer;
    public static Interface rid { get; set; }

    float timer = 0;
    bool isSaved = false;
    void Awake()
    {
        Sum(0, true, 0);
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
    public void Sum(int index, bool cursor, float scale)
    {
        sumer[index].Invoke();
        CursorEvent(cursor);
        Time.timeScale = scale;
    }
    public void SaveGame() 
    {
        if (timer < Time.time) 
        {
            YandexGame.SaveProgress();
            timer = Time.time + 1;
            isSaved = true;
        }
    }
    private void FixedUpdate()
    {
        if (isSaved) 
        {
            if (timer < Time.time) 
            {
                YandexGame.SaveProgress();
                isSaved = false;
            }
        }
    }
    void CursorEvent(bool activ)
    {
        if (activ)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        Cursor.visible = activ;
    }
}

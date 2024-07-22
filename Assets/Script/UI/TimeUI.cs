using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeUI : MonoBehaviour
{
    public Text timeText;

    /// <summary> 経過時間をON/OFFできる関数 </summary>
    public bool playTimer;
    /// <summary> 今の経過時間 </summary>
    float nowTime;

    // Start is called before the first frame update
    void Start()
    {
        if (timeText == null)
        {
            Debug.LogError("時間を表示するテキストUIが割り当てられてないよ");
        }
    }

    // Update is called once per frame
    void Update()
    {
        var goalObj = GameObject.Find("Goal");

        if (timeText != null)
        {
            if (goalObj != null)
            nowTime += Time.deltaTime;
            int minutes = Mathf.FloorToInt(nowTime / 60);
            int seconds = Mathf.FloorToInt(nowTime % 60);
            int milliseconds = Mathf.FloorToInt((nowTime * 100) % 100);

            timeText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
        }
    }
}

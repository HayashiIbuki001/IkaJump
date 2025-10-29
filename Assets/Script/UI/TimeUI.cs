using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeUI : MonoBehaviour
{
    public Text timeText;

    public GoalManager goalManager;

    /// <summary> �o�ߎ��Ԃ�ON/OFF�ł���֐� </summary>
    public bool playTimer;
    /// <summary> ���̌o�ߎ��� </summary>
    private float time;
    public float Time => time;

    // Start is called before the first frame update
    void Start()
    {
        if (timeText == null)
        {
            Debug.LogError("���Ԃ�\������e�L�X�gUI�����蓖�Ă��ĂȂ���");
        }

        playTimer = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (playTimer && !goalManager.IsGoal)
        {
            time += UnityEngine.Time.deltaTime;
            int minutes = Mathf.FloorToInt(time / 60);
            int seconds = Mathf.FloorToInt(time % 60);
            int milliseconds = Mathf.FloorToInt((time * 100) % 100);

            timeText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
        }
    }

    public void ResetTime()
    {
        time = 0;
    }
}

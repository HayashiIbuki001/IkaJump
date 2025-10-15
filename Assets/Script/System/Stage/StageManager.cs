using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public int stageCount = 0;
    public bool counter = false;
    public bool counted = false;

    // GoalUI スクリプトへの参照
    private GoalUI goalUI;

    void Start()
    {
        // シーン内の GoalUI を探す
        goalUI = FindFirstObjectByType<GoalUI>();
        if (goalUI == null)
        {
            Debug.LogError("GoalUI がシーン内に見つかりません");
        }
    }

    // Update はフレームごとに呼ばれる
    public void Update()
    {
        // ゲーム内の Goal タグが付いたオブジェクトがすべて消えたかチェック
        if (GameObject.FindGameObjectsWithTag("Goal").Length == 0)
        {
            counter = true;
            StageCounter();
        }

        if (GameObject.FindGameObjectsWithTag("Goal").Length == 1)
        {
            counter = false;
            counted = false;
        }
    }

    // ステージカウンターを増やす関数
    public void StageCounter()
    {
        if (counter)
        {
            if (!counted)
            {
                stageCount++;
                Debug.Log("ステージカウント: " + stageCount);
                counted = true;

                //ここに追加
                if (goalUI != null)
                {
                    goalUI.DisplayGoalText("Stage " + stageCount + "\nClear!");
                }
            }
        }
    }
}

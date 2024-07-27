using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public int stageCount = 0;

    // Update はフレームごとに呼ばれる
    public void Update()
    {
        // ゲーム内の Goal タグが付いたオブジェクトがすべて消えたかチェック
        if (GameObject.FindGameObjectsWithTag("Goal").Length == 0)
        {
            // ステージカウンターを増やす
            StageCounter();
        }
    }

    // ステージカウンターを増やす関数
    public void StageCounter()
    {
        stageCount++;
        Debug.Log("ステージカウント: " + stageCount);
    }
}

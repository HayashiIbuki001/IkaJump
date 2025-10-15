using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour
{
    // StageManager スクリプトへの参照
    private StageManager stageManager;

    void Start()
    {
        // シーン内の StageManager を探す
        stageManager = FindFirstObjectByType<StageManager>();
    }

    void OnDestroy()
    {
        // Goal オブジェクトが破壊されたときに StageManager の Update メソッドを呼ぶ
        stageManager.Update();
    }
}
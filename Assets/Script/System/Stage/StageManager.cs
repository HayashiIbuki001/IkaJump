using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    public int stageCount = 0;
    public bool counter = false;
    public bool counted = false;

    // GoalUI スクリプトへの参照
    private GoalUI goalUI;

    private StageUI stageUI;

    void Start()
    {
        // シーン内の GoalUI を探す
        goalUI = FindObjectOfType<GoalUI>();
        if (goalUI == null)
        {
            Debug.LogError("GoalUI がシーン内に見つかりません");
        }

        stageUI = FindObjectOfType<StageUI>();

        stageUI.StageText(stageCount);
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

                // 新しいシーンを読み込むコルーチンを開始
                StartCoroutine(LoadNextScene());
            }
        }
    }

    IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(3f);

        //次のシーンの名前を作成
        //Stage1,Stage2,Stage3...
        string nextSceneName = "Stage" + (stageCount + 1);

        // 次のシーンを読み込む
        SceneManager.LoadScene(nextSceneName);
        Debug.Log("Stage2を読み込みます");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPlace : MonoBehaviour
{
    // 配置するオブジェクトを指定（SerializeFieldを追加）
    [SerializeField]
    private GameObject groundObject;

    // ゴールになるオブジェクトを指定（SerializeFieldを追加）
    [SerializeField]
    private GameObject goalObject;

    // オブジェクトの配置数
    [SerializeField, Tooltip("オブジェクトの配置数")]
    private int numberOfObjects = 10;

    // y軸の間隔
    [SerializeField, Tooltip("y軸の間隔")]
    private float ySpacing = 9.1f;

    void Start()
    {
        // エラーチェック
        ErrorCheck();

        // オブジェクトを配置
        PlaceObjects();
    }

    void ErrorCheck()
    {
        if (groundObject == null)
        {
            Debug.LogError("GroundObjectがアタッチされていません");
        }

        if (goalObject == null)
        {
            Debug.LogError("GoalObjectがアタッチされていません");
        }
    }

    void PlaceObjects()
    {
        // 一番高いy軸の位置を記録するための変数
        float maxYPosition = 0f;

        for (int i = 0; i < numberOfObjects; i++)
        {
            // y軸の位置をySpacingずつ増加
            float yPosition = ySpacing * (i + 1);

            // x軸のランダムな位置を取得（範囲を -16 ~ 0 に設定）
            float randomX = Random.Range(-16f, 0f);

            // オブジェクトの新しい位置を設定
            Vector3 newPosition = new Vector3(randomX, yPosition, 0f);

            // オブジェクトを指定された位置にインスタンス化
            Instantiate(groundObject, newPosition, Quaternion.identity);

            // 一番高いy軸の位置を更新
            if (yPosition > maxYPosition)
            {
                maxYPosition = yPosition;
            }
        }

        // ゴールオブジェクトの配置
        if (goalObject != null)
        {
            float goalYPosition = maxYPosition + ySpacing;
            // ゴールオブジェクトのx軸位置を -10 に固定
            float goalX = -8f;
            Vector3 goalPosition = new Vector3(goalX, goalYPosition, 0f);
            Instantiate(goalObject, goalPosition, Quaternion.identity);
        }
    }
}
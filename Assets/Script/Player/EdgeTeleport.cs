using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeTeleport : MonoBehaviour
{
    [SerializeField, Tooltip("右端のx座標")] float RightEdge = 3.06f;
    [SerializeField, Tooltip("左端のx座標")] float LeftEdge = -19.19f;
    private Vector2 playerPos;

    void Update()
    {
        playerPos = transform.position;

        //右端
        if (playerPos.x > RightEdge)
        {
            //左端から0.05f右にTP
            playerPos.x = LeftEdge + 0.05f;

            this.transform.position = playerPos;
            //Debug.Log("左端にTP");
        }

        //左端
        if (playerPos.x < LeftEdge)
        {
            //右端から0.05f左にTP
            playerPos.x = RightEdge - 0.05f;

            this.transform.position = playerPos;
            //Debug.Log("右端にTP");
        }
    }
}

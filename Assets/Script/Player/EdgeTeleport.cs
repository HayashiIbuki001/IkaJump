using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeTeleport : MonoBehaviour
{
    [SerializeField, Tooltip("�E�[��x���W")] float RightEdge = 3.06f;
    [SerializeField, Tooltip("���[��x���W")] float LeftEdge = -19.19f;
    private Vector2 playerPos;

    void Update()
    {
        playerPos = transform.position;

        //�E�[
        if (playerPos.x > RightEdge)
        {
            //���[����0.05f�E��TP
            playerPos.x = LeftEdge + 0.05f;

            this.transform.position = playerPos;
            //Debug.Log("���[��TP");
        }

        //���[
        if (playerPos.x < LeftEdge)
        {
            //�E�[����0.05f����TP
            playerPos.x = RightEdge - 0.05f;

            this.transform.position = playerPos;
            //Debug.Log("�E�[��TP");
        }
    }
}

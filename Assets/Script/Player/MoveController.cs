using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    /// <summary> 左右に移動するスピード </summary>
    [SerializeField] public float speed;

    /// <summary> ジャンプしているかどうか </summary>
    public bool isJump;

    private bool Finished;

    public new Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        //rigidbodyつける
        rigidbody = GetComponent<Rigidbody2D>();

        Finished = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isJump == true)
        {
            Move();
        }
    }

    /// <summary> 移動の制御 </summary>
    void Move()
    {
        if (!Finished)
        {
            //Aか左矢印を押している
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(speed * -0.01f, 0, 0);
            }
            //Dか右矢印を押している
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(speed * 0.01f, 0, 0);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            // 接触した位置の法線ベクトルを取得
            Vector2 contactNormal = collision.contacts[0].normal;
            // 足場の上から接触した場合のみisJumpをfalseにする
            if (contactNormal.y > 0.5f)
            {
                isJump = false;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isJump = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Goal")
        {
            //Debug.Log("goal");
            Finished = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    [SerializeField,Tooltip("ジャンプ威力")] public float jumpPowerParcentage;
    public new Rigidbody2D rigidbody;
    /// <summary> ジャンプ可能か </summary>
    public bool jumpTrigger;
    /// <summary> チャージ時間 </summary>
    private float chargeTime;

    [SerializeField,Tooltip("最大チャージ時間")] public float maxCharge = 2;

    /// <summary> ジャンプ完了か </summary>
    private bool Finished;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        jumpTrigger = true;
        Finished = false;
    }

    // Update is called once per frame
    void Update()
    {
        JumpDetection();
        VariableSharing();
        Finish();
    }

    /// <summary> ジャンプボタンを押したら </summary>
    void JumpDetection()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            JumpCharge();
        }

        if (jumpTrigger)
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                Jump();
                jumpTrigger = false;
            }
        }
    }

    void JumpCharge()
    {
        if (chargeTime < maxCharge)
        {
            chargeTime += Time.deltaTime;
        }
        else if (chargeTime > maxCharge)
        {
            chargeTime = maxCharge;
        }
    }

    void Jump()
    {
        rigidbody.AddForce(Vector3.up * chargeTime * (jumpPowerParcentage / 100) * 100);
        chargeTime = 0;
    }

    void Finish()
    {
        if (Finished)
        {
            //Rigidbody変更
            rigidbody.linearVelocity = Vector3.zero;
            rigidbody.bodyType = RigidbodyType2D.Kinematic;
        }
    }


    /// <summary>
    /// 他スクリプトに渡す
    /// </summary>
    void VariableSharing()
    {
        //MoveController moveController = GetComponent<MoveController>();
        //moveController.isJump = revJumpTrigger;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //地面と重なったら
        if (collision.gameObject.tag == "Ground")
        {
            // 地面の上にいないとジャンプできないように
            // 接地面の法線を取得
            Vector2 contactNormal = collision.contacts[0].normal;
            if (contactNormal.y > 0.5f)
            {
                jumpTrigger = true;
            } 
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            jumpTrigger = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Goal")
        {
            //Debug.Log("goal");
            Finished = true;
        }

        if (collision.gameObject.tag == "Death")
        {
            Finished = true;
        }
    }
}

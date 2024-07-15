using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    /// <summary> ジャンプ力倍率 </summary>
    [SerializeField] public float jumpPowerParcentage;
    public new Rigidbody2D rigidbody;
    /// <summary> ジャンプ可能かどうか </summary>
    public bool jumpTrigger;
    ///<sumary> jumpTriggerの逆　</sumary>
    private bool revJumpTrigger;
    /// <summary> チャージしている時間 </summary>
    private float chargeTime;
    /// <summary> 最大チャージまでの秒数 </summary>
    [SerializeField] public float maxCharge = 2;
    // Start is called before the first frame update
    void Start()
    {
        //rigidbodyつける
        rigidbody = GetComponent<Rigidbody2D>();

        jumpTrigger = true;
        revJumpTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        JumpDetection();
        VariableSharing();
    }

    /// <summary> ジャンプの動作を検知する</summary>
    void JumpDetection()
    {
        //ジャンプボタンが押されている
        if (Input.GetKey(KeyCode.Space))
        {
            JumpCharge();
        }

        if (jumpTrigger == true)
        {
            //ジャンプボタンを離した
            if (Input.GetKeyUp(KeyCode.Space))
            {
                Jump();
                jumpTrigger = false;
                revJumpTrigger = true;
            }
        }
    }

    void JumpCharge()
    {
        if (chargeTime < maxCharge)
        {
            //チャージした時間を代入
            chargeTime += Time.deltaTime;
            //Debug.Log(chargeTime);
        }
        else if(chargeTime > maxCharge)
        { 
            chargeTime = maxCharge;
        }
    }

    void Jump()
    {
            //ジャンプ力
            rigidbody.AddForce(Vector3.up * chargeTime * (jumpPowerParcentage / 100) * 100);
            //Debug.Log(chargeTime * (jumpPowerParcentage / 100) * 100);
            //チャージリセット
            chargeTime = 0;       
    }

    /// <summary>
    /// 他スクリプトの変数を呼ぶ
    /// </summary>
    void VariableSharing()
    {
        //MoveController moveController = GetComponent<MoveController>();
        //moveController.isJump = revJumpTrigger;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //地面にいるとき
        if (collision.gameObject.tag == "Ground")
        {
            jumpTrigger = true;
            revJumpTrigger = false;
            //Debug.Log("地面いる");
        }
        
    }
}

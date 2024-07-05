using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    /// <summary> ジャンプ力倍率 </summary>
    [SerializeField] public float jumpPowerParcentage;
    public new Rigidbody2D rigidbody;
    /// <summary> ジャンプ可能かどうか </summary>
    private bool jumpTrigger;
    /// <summary> チャージしている時間 </summary>
    private float chargeTime;
    // Start is called before the first frame update
    void Start()
    {
        //rigidbodyつける
        rigidbody = GetComponent<Rigidbody2D>();

        jumpTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        //ジャンプボタンが押される
        if (Input.GetKey(KeyCode.Space))
        {
            JumpCharge();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            Jump();
        }
    }

    void JumpCharge()
    {
        //チャージした時間を代入
        chargeTime += Time.deltaTime;
        //Debug.Log(chargeTime);
    }

    void Jump()
    {
        //ジャンプ力
        rigidbody.AddForce(Vector3.up * chargeTime * (jumpPowerParcentage / 100) * 100);
        Debug.Log(chargeTime * (jumpPowerParcentage / 100) * 100);
        //チャージリセット
        chargeTime = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //地面にいるとき
        if (collision.gameObject.tag == "Ground")
        {
            jumpTrigger = true;
        }
    }
}

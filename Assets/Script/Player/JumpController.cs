using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    /// <summary> �W�����v�͔{�� </summary>
    [SerializeField] public float jumpPowerParcentage;
    public new Rigidbody2D rigidbody;
    /// <summary> �W�����v�\���ǂ��� </summary>
    private bool jumpTrigger;
    /// <summary> �`���[�W���Ă��鎞�� </summary>
    private float chargeTime;
    // Start is called before the first frame update
    void Start()
    {
        //rigidbody����
        rigidbody = GetComponent<Rigidbody2D>();

        jumpTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        //�W�����v�{�^�����������
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
        //�`���[�W�������Ԃ���
        chargeTime += Time.deltaTime;
        //Debug.Log(chargeTime);
    }

    void Jump()
    {
        //�W�����v��
        rigidbody.AddForce(Vector3.up * chargeTime * (jumpPowerParcentage / 100) * 100);
        Debug.Log(chargeTime * (jumpPowerParcentage / 100) * 100);
        //�`���[�W���Z�b�g
        chargeTime = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //�n�ʂɂ���Ƃ�
        if (collision.gameObject.tag == "Ground")
        {
            jumpTrigger = true;
        }
    }
}

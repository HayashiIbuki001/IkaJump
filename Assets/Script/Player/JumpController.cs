using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    /// <summary> �W�����v�͔{�� </summary>
    [SerializeField] public float jumpPowerParcentage;
    public new Rigidbody2D rigidbody;
    /// <summary> �W�����v�\���ǂ��� </summary>
    public bool jumpTrigger;
    /// <summary> �`���[�W���Ă��鎞�� </summary>
    private float chargeTime;
    /// <summary> �ő�`���[�W�܂ł̕b�� </summary>
    [SerializeField] public float maxCharge = 2;

    /// <summary> �S�[������ </summary>
    private bool Finished;
    // Start is called before the first frame update
    void Start()
    {
        //rigidbody����
        rigidbody = GetComponent<Rigidbody2D>();

        jumpTrigger = true;
        //revJumpTrigger = false;
        Finished = false;
    }

    // Update is called once per frame
    void Update()
    {
        JumpDetection();
        VariableSharing();
        Finish();
    }

    /// <summary> �W�����v�̓�������m����</summary>
    void JumpDetection()
    {
        //�W�����v�{�^����������Ă���
        if (Input.GetKey(KeyCode.Space))
        {
            JumpCharge();
        }

        if (jumpTrigger == true)
        {
            //�W�����v�{�^���𗣂���
            if (Input.GetKeyUp(KeyCode.Space))
            {
                Jump();
                jumpTrigger = false;
                //revJumpTrigger = true;
            }
        }
    }

    void JumpCharge()
    {
        if (chargeTime < maxCharge)
        {
            //�`���[�W�������Ԃ���
            chargeTime += Time.deltaTime;
            //Debug.Log(chargeTime);
        }
        else if (chargeTime > maxCharge)
        {
            chargeTime = maxCharge;
        }
    }

    void Jump()
    {
        //�W�����v��
        rigidbody.AddForce(Vector3.up * chargeTime * (jumpPowerParcentage / 100) * 100);
        //Debug.Log(chargeTime * (jumpPowerParcentage / 100) * 100);
        //�`���[�W���Z�b�g
        chargeTime = 0;
    }

    void Finish()
    {
        if (Finished)
        {
            //Rigidbody���~
            rigidbody.velocity = Vector3.zero;

            //�d�͂��~������
            rigidbody.isKinematic = true;
        }
    }


    /// <summary>
    /// ���X�N���v�g�̕ϐ����Ă�
    /// </summary>
    void VariableSharing()
    {
        //MoveController moveController = GetComponent<MoveController>();
        //moveController.isJump = revJumpTrigger;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //�n�ʂɂ���Ƃ�
        if (collision.gameObject.tag == "Ground")
        {
            // �ڐG�����ʒu�̖@���x�N�g�����擾
            Vector2 contactNormal = collision.contacts[0].normal;
            // ����̏ォ��ڐG�����ꍇ�̂�jumpTrigger��true�ɂ���
            if (contactNormal.y > 0.5f)
            {
                jumpTrigger = true;
                //Debug.Log("�n�ʂ���");
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
    }
}

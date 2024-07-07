using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    /// <summary> ���E�Ɉړ�����X�s�[�h </summary>
    [SerializeField] public float speed;

    /// <summary> �W�����v���Ă��邩�ǂ��� </summary>
    public bool isJump;

    

    public new Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        //rigidbody����
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isJump == true)
        {
            Move();
        }
    }

    /// <summary> �ړ��̐��� </summary>
    void Move()
    {

        //A�������������Ă���
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(speed * -0.01f,0, 0);
        }
        //D���E���������Ă���
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(speed * 0.01f, 0, -0);
        }
    }
}

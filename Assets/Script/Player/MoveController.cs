using UnityEngine;

public class MoveController : MonoBehaviour
{
    /// <summary> ���E�Ɉړ�����X�s�[�h </summary>
    [SerializeField] public float speed;
    private float moveX = 0f;

    /// <summary> �W�����v���Ă��邩�ǂ��� </summary>
    public bool isJump;

    private bool Finished;

    public new Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        //rigidbody����
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

    /// <summary> �ړ��̐��� </summary>
    void Move()
    {
        if (!Finished)
        {
            //A�������������Ă���
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                moveX = -1f;
            }
            //D���E���������Ă���
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                moveX = 1f;
            }
            else
            {
                moveX = 0f;
            }

                transform.Translate(moveX * speed * Time.deltaTime, 0, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            // �ڐG�����ʒu�̖@���x�N�g�����擾
            Vector2 contactNormal = collision.contacts[0].normal;
            // ����̏ォ��ڐG�����ꍇ�̂�isJump��false�ɂ���
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

        if (collision.gameObject.tag == "Death")
        {
            Finished = true;
        }
    }
}

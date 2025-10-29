using UnityEngine;

public class MoveController : MonoBehaviour
{
    /// <summary> 左右に移動するスピード </summary>
    [SerializeField] public float speed;
    private float moveX = 0f;

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
                moveX = -1f;
            }
            //Dか右矢印を押している
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

        if (collision.gameObject.tag == "Death")
        {
            Finished = true;
        }
    }
}

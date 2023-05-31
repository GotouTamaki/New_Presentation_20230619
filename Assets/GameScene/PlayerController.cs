using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // 左右移動する力
    [SerializeField] float m_movePower = 5f;
    // ジャンプする力
    [SerializeField] float m_jumpPower = 15f;
    // 入力に応じて左右を反転させるかどうかのフラグ
    [SerializeField] bool m_flipX = false;
    Rigidbody2D m_rb = default;
    SpriteRenderer m_sprite = default;

    // m_colors に使う添字
    int m_colorIndex;
    // 水平方向の入力値
    float m_h;
    float m_scaleX;
    // 最初に出現した座標
    Vector3 m_initialPosition;
    // 設置判定
    bool isGrounded = false;
    int Jumpcount = 0;
    // 縄を投げるの向き変更
    //bool lookingright = true;

    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_sprite = GetComponent<SpriteRenderer>();
        // 初期位置を覚えておく
        m_initialPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // 入力を受け取る
        m_h = Input.GetAxisRaw("Horizontal");
        m_sprite = GetComponent<SpriteRenderer>();

        // 各種入力を受け取る
        if (Input.GetButtonDown("Jump") && (isGrounded || Jumpcount < 2))
        {
            Jumpcount++;
            Debug.Log("ここにジャンプする処理を書く。");
            m_rb.AddForce(Vector2.up * m_jumpPower, ForceMode2D.Impulse);
        }

        // 下に行きすぎたら初期位置に戻す
        if (this.transform.position.y < -10f)
        {
            this.transform.position = m_initialPosition;
        }

        // 設定に応じて左右を反転させる
        if (m_flipX)
        {
            FlipX(m_h);

        }
    }

        private void FixedUpdate()
    {
        // 力を加えるのは FixedUpdate で行う
        m_rb.AddForce(Vector2.right * m_h * m_movePower, ForceMode2D.Force);
    }

    /// <summary>
    /// 左右を反転させる
    /// </summary>
    /// <param name="horizontal">水平方向の入力値</param>
    void FlipX(float horizontal)
    {
        /*
         * 左を入力されたらキャラクターを左に向ける。
         * 左右を反転させるには、Transform:Scale:X に -1 を掛ける。
         * Sprite Renderer の Flip:X を操作しても反転する。
         * */
        m_scaleX = this.transform.localScale.x;

        if (horizontal > 0)
        {
            this.transform.localScale = new Vector3(Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
            //lookingright = true;
        }
        else if (horizontal < 0)
        {
            this.transform.localScale = new Vector3(-1 * Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
            //lookingright = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("接地した");
        isGrounded = true;
        Jumpcount = 0; 
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("ジャンプした");
        isGrounded = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using static UnityEngine.GraphicsBuffer;

public class PlayerController : MonoBehaviour
{

    // 左右移動する力
    [SerializeField] float _movePower = 5f;
    // ジャンプする力
    [SerializeField] float _jumpPower = 15f;
    // 入力に応じて左右を反転させるかどうかのフラグ
    [SerializeField] bool _flipX = false;
    //ターゲットカーソル
    [SerializeField] GameObject _target;
    //引っ張られる強さ
    [SerializeField] float _springPower = 1f;
    [SerializeField] AudioClip _landing = default;
    [SerializeField] AudioClip _grap = default;
    [SerializeField] float _grapAudioScale = 1f;

    //各種初期化
    Rigidbody2D _rb = default;
    SpriteRenderer _sprite = default;
    // m_colors に使う添字
    //int m_colorIndex;
    // 水平方向の入力値
    float _h;
    float _scaleX;
    // 最初に出現した座標
    Vector3 _initialPosition;
    // 設置判定
    bool _isGrounded = false;
    int _jumpcount = 0;
    //this._target.transform.positionとthis.transform.positionの差
    Vector2 _diff;
    //ワイヤーアクションの可否
    public bool _CanHook = false;
    //今いるステージの情報を記録する
    string _stage = default;
    AudioSource _audioSource; 

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();
        // 初期位置を覚えておく
        _initialPosition = this.transform.position;
        _stage = SceneManager.GetActiveScene().name;
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // 入力を受け取る
        _h = Input.GetAxisRaw("Horizontal");
        //m_h = 0;
        _sprite = GetComponent<SpriteRenderer>();

        // 各種入力を受け取る
        if (Input.GetButtonDown("Jump") && (_isGrounded || _jumpcount < 2))
        {
            _jumpcount++;
            //Debug.Log("ここにジャンプする処理を書く。");
            _rb.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
        }

        if (Input.GetButtonDown("Fire1") && _CanHook)
        {
            _audioSource.PlayOneShot(_grap, _grapAudioScale);
        }
        if (Input.GetButton("Fire1") && _CanHook)
        {
            //Debug.Log("ワイヤーアクション！");
            _diff = this._target.transform.position - this.transform.position;     
        }       
        else
        {
            _diff = Vector2.zero;
        }

        // 下に行きすぎたら初期位置に戻す
        if (this.transform.position.y < -10f)
        {
            this.transform.position = _initialPosition;
        }

        // 設定に応じて左右を反転させる
        if (_flipX)
        {
            FlipX(_h);

        }
    }

        private void FixedUpdate()
    {
        // 横移動の力を加えるのは FixedUpdate で行う
        _rb.AddForce(Vector2.right * _h * _movePower, ForceMode2D.Force);
        //ワイヤーアクションの力を加える
        _rb.AddForce(_diff * _springPower, ForceMode2D.Force);
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
        _scaleX = this.transform.localScale.x;

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
        if (collision.gameObject.tag != "Target")
        {
            //Debug.Log("接地した");
            _isGrounded = true;
            _jumpcount = 0;
            _audioSource.PlayOneShot(_landing);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Target")
        {
            //Debug.Log("ジャンプした");
            _isGrounded = false;
        }
    }
}

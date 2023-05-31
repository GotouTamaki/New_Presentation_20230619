using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // ���E�ړ������
    [SerializeField] float m_movePower = 5f;
    // �W�����v�����
    [SerializeField] float m_jumpPower = 15f;
    // ���͂ɉ����č��E�𔽓]�����邩�ǂ����̃t���O
    [SerializeField] bool m_flipX = false;
    Rigidbody2D m_rb = default;
    SpriteRenderer m_sprite = default;

    // m_colors �Ɏg���Y��
    int m_colorIndex;
    // ���������̓��͒l
    float m_h;
    float m_scaleX;
    // �ŏ��ɏo���������W
    Vector3 m_initialPosition;
    // �ݒu����
    bool isGrounded = false;
    int Jumpcount = 0;
    // ��𓊂���̌����ύX
    //bool lookingright = true;

    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_sprite = GetComponent<SpriteRenderer>();
        // �����ʒu���o���Ă���
        m_initialPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // ���͂��󂯎��
        m_h = Input.GetAxisRaw("Horizontal");
        m_sprite = GetComponent<SpriteRenderer>();

        // �e����͂��󂯎��
        if (Input.GetButtonDown("Jump") && (isGrounded || Jumpcount < 2))
        {
            Jumpcount++;
            Debug.Log("�����ɃW�����v���鏈���������B");
            m_rb.AddForce(Vector2.up * m_jumpPower, ForceMode2D.Impulse);
        }

        // ���ɍs���������珉���ʒu�ɖ߂�
        if (this.transform.position.y < -10f)
        {
            this.transform.position = m_initialPosition;
        }

        // �ݒ�ɉ����č��E�𔽓]������
        if (m_flipX)
        {
            FlipX(m_h);

        }
    }

        private void FixedUpdate()
    {
        // �͂�������̂� FixedUpdate �ōs��
        m_rb.AddForce(Vector2.right * m_h * m_movePower, ForceMode2D.Force);
    }

    /// <summary>
    /// ���E�𔽓]������
    /// </summary>
    /// <param name="horizontal">���������̓��͒l</param>
    void FlipX(float horizontal)
    {
        /*
         * ������͂��ꂽ��L�����N�^�[�����Ɍ�����B
         * ���E�𔽓]������ɂ́ATransform:Scale:X �� -1 ���|����B
         * Sprite Renderer �� Flip:X �𑀍삵�Ă����]����B
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
        Debug.Log("�ڒn����");
        isGrounded = true;
        Jumpcount = 0; 
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("�W�����v����");
        isGrounded = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

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
    //�^�[�Q�b�g�J�[�\��
    [SerializeField]
    GameObject _target;
    //���������鋭��
    [SerializeField]
    float _springPower = 1f;

    // m_colors �Ɏg���Y��
    int m_colorIndex;
    // ���������̓��͒l
    float m_h;
    float m_scaleX;
    // �ŏ��ɏo���������W
    Vector3 m_initialPosition;
    // �ݒu����
    bool _isGrounded = false;
    int _jumpcount = 0;
    //this._target.transform.position��this.transform.position�̍�
    Vector3 _diff;
    //���C���[�A�N�V�����̉�
    public bool _CanHook = false;
    //
    //bool _roopA = false; 


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
        if (Input.GetButtonDown("Jump") && (_isGrounded || _jumpcount < 2))
        {
            _jumpcount++;
            Debug.Log("�����ɃW�����v���鏈���������B");
            m_rb.AddForce(Vector2.up * m_jumpPower, ForceMode2D.Impulse);
        }

        if (Input.GetButtonDown("Fire1") && _CanHook)
        {
            Debug.Log("���C���[�A�N�V�����I");
            _diff = this._target.transform.position - this.transform.position;
            //���C���[�A�N�V�����̗͂�������
            m_rb.AddForce(_diff * _springPower, ForceMode2D.Impulse);
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
        // ���ړ��̗͂�������̂� FixedUpdate �ōs��
        m_rb.AddForce(Vector2.right * m_h * m_movePower, ForceMode2D.Force);
        //���C���[�A�N�V�����̗͂�������
        //m_rb.AddForce(_diff * _springPower, ForceMode2D.Impulse);
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
        if (collision.gameObject.tag == "Ground")
        {
            Debug.Log("�ڒn����");
            _isGrounded = true;
            _jumpcount = 0;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Debug.Log("�W�����v����");
            _isGrounded = false;
        }
    }
}

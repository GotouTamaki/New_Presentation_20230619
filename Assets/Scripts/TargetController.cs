using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TargetController : MonoBehaviour
{
    //�v���C���[���擾
    [SerializeField]
    GameObject _prayer;

    LineRenderer _line;
    bool _canHook = false;

    // Start is called before the first frame update
    void Start()
    {
        //LineRenderere�֘A�̐ݒ�
        //�R���|�[�l���g���擾����
        this._line = GetComponent<LineRenderer>();
        //���̕������߂�
        this._line.startWidth = 0.1f;
        this._line.endWidth = 0.1f;
        //���_�̐������߂�
        this._line.positionCount = 2;
    }

    // Update is called once per frame
    void Update()
    {

        //�t�b�N���|�����邩�ǂ���
        _prayer.GetComponent<PlayerController>()._CanHook = _canHook;

        if (Input.GetButton("Fire1") && _canHook)
        {
            this.transform.position = this.transform.position;
        }
        else
        {
            TargetMove();
        }

        _line.SetPosition(0, this.transform.position);
        _line.SetPosition(1, this._prayer.transform.position);
    }

    private void TargetMove()
    {
        // Camera.main �Ń��C���J�����iMainCamera �^�O�̕t���� Camera�j���擾����
        // Camera.ScreenToWorldPoint �֐��ŁA�X�N���[�����W�����[���h���W�ɕϊ�����
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // �^�[�Q�b�g�������Ȃ��Ȃ��Ă��܂����߁AZ ���W�𒲐����Ă���
        mousePosition.z = -5;
        this.transform.position = mousePosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Anchor")
        {
            //Debug.Log("����������");
            SpriteRenderer Cr = GetComponent<SpriteRenderer>();
            Cr.color = Color.green;
            _canHook = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Anchor")
        {
            //Debug.Log("��ꂽ");
            SpriteRenderer Cr = GetComponent<SpriteRenderer>();
            Cr.color = Color.white;
            _canHook = false;
        } 
    }
}

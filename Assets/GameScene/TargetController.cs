using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TargetController : MonoBehaviour
{
    //�v���C���[
    [SerializeField]
    GameObject _prayer;

    bool _canHook = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Camera.main �Ń��C���J�����iMainCamera �^�O�̕t���� Camera�j���擾����
        // Camera.ScreenToWorldPoint �֐��ŁA�X�N���[�����W�����[���h���W�ɕϊ�����
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // �^�[�Q�b�g�������Ȃ��Ȃ��Ă��܂����߁AZ ���W�𒲐����Ă���
        mousePosition.z = -5;
        this.transform.position = mousePosition;

        _prayer.GetComponent<PlayerController>()._CanHook = _canHook;
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

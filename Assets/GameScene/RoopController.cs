using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using static UnityEngine.GraphicsBuffer;

public class RoopController : MonoBehaviour
{
    //[SerializeField]
    //GameObject _target;//�^�[�Q�b�g�J�[�\��
    //[SerializeField]
    //float _springPower = 1f;//���������鋭��

    //Rigidbody2D _rb = default;
    //public bool LookingRight = true;
    //// �ŏ��ɏo���������W
    ////Vector3 _initialPosition;
    //Vector3  _diff;//this._target.transform.position��this.transform.position�̍�
    ////int _speed = 5;



    // Start is called before the first frame update
    void Start()
    {
        //_rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //private void FixedUpdate()
    //{

    //    //if (Input.GetButton("Fire1"))
    //    //{
    //    //    _diff = this._target.transform.position - this.transform.position;
    //    //    _rb.AddForce(_diff * _springPower, ForceMode2D.Impulse);
    //    //}
        
    //}

    //void OnDrawGizmos()
    //{
    //    Gizmos.DrawLine(this._pos, this._targetPos);
    //}

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Anchor")
    //    {
    //        Debug.Log("����������");
    //        SpriteRenderer Cr = _target.GetComponent<SpriteRenderer>();
    //        Cr.color = Color.green;
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    SpriteRenderer Cr = _target.GetComponent<SpriteRenderer>();
    //    Cr.color = Color.white;
    //}
}



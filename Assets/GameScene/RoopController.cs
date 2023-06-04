using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using static UnityEngine.GraphicsBuffer;

public class RoopController : MonoBehaviour
{
    [SerializeField]
    GameObject _target;//カーソル
    [SerializeField]
    int _springPower = 1;
    //[SerializeField]
    //float _angularSpeed = 360f;//振り回す速さ
    //[SerializeField]
    //float _extendLength = 3;//伸びた縄の長さ
    //[SerializeField]
    //float _InitialLength = 0.5f;//元の長さに戻す

    Rigidbody2D _rb = default;
    public bool LookingRight = true;
    // 最初に出現した座標
    Vector3 _initialPosition;
    //
    Vector3 _targetPos;
    Vector3 _acc, _vel, _pos, _diff;
    int _speed = 5;



    // Start is called before the first frame update
    void Start()
    {
        //acc = vel = Vector3.zero;
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        

        //ターゲットの位置
        //this.transform.up = _crossehair.transform.position - transform.position;

        //if (Input.GetButton("Fire2"))
        //{
        //    //transform.localScale = new Vector3(1, 3, 1);
        //    //transform.rotation *= Quaternion.AngleAxis(_angularSpeed * Time.deltaTime, Vector3.forward); 
        //}

        //if (Input.GetButtonUp("Fire2"))
        //{
        //    //transform.localScale = new Vector3(1, _InitialLength, 1);

        //}

        
        //if (Input.GetButtonUp("Fire1"))
        //{
        //    transform.localScale = new Vector3(1, _InitialLength, 1);
        //}

        // 下に行きすぎたら初期位置に戻す
        //if (this.transform.position.y < -10f)
        //{
        //    this.transform.position = _initialPosition;
        //}
    }

    private void FixedUpdate()
    {
        //this.transform.up = _target.transform.position - transform.position;
        //_targetPos = new Vector3(_target.transform.position.x, _target.transform.position.y, 0);

        if (Input.GetButton("Fire1"))
        {
            //_targetPos = new Vector3(_target.transform.position.x, _target.transform.position.y, 0);
            Vector2 _diff = this._target.transform.position - this.transform.position;
            _rb.AddForce(_diff * _springPower, ForceMode2D.Impulse);
        }
        else
        {
            
        }
        //transform.position = this._pos;
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawLine(this._pos, this._targetPos);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Target")
        {
            Debug.Log("ターゲット！！");
        }
    }
}



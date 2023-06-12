using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] MoveMode _moveMode;
    [Tooltip("オブジェクトの移動速度")]
    [SerializeField] float _moveSpeed = 1f;
    [Tooltip("ターゲットに到達したと判断する距離（単位:メートル）")]
    [SerializeField] float _stoppingDistance = 0.05f;
    [SerializeField]
    protected float _vertSpeed = 1f;
    [SerializeField]
    protected float _horiSpeed = 1f;
    [SerializeField]
    float _originalX = 0;

    Vector3 m_initialPosition;
    Rigidbody2D m_rb = default;
    float _x = 0;
    float _time = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        m_initialPosition = this.transform.position;
        m_rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;
    }

    private void FixedUpdate()
    {

        if (_moveMode == MoveMode.MoveStope)
        {
            MoveStope();
        }
        else if (_moveMode == MoveMode.MovePoint0)
        {
            MovePoint0();
        }
        else if (_moveMode == MoveMode.Patrol)
        {
            Patrol();
        }
        else if (_moveMode == MoveMode.SinCurveMove)
        {
            SinCurveMove();
        }
        else if (_moveMode == MoveMode.CatchMove)
        {
            CatchMove();
        }
    }

    enum MoveMode
    {
        MoveStope,
        MovePoint0,
        Patrol,
        SinCurveMove,
        CatchMove,
    }

    void MoveStope()
    {
        //Debug.Log("敵停止");
    }

    void MovePoint0() 
    {
        // 自分自身とターゲットの距離を求める
        float distance = Vector2.Distance(this.transform.position, m_initialPosition);

        if (distance > _stoppingDistance)  // ターゲットに到達するまで処理する
        {
            Vector3 dir = (m_initialPosition - this.transform.position).normalized * _moveSpeed; // 移動方向のベクトルを求める
            m_rb.AddForce(dir * _moveSpeed, ForceMode2D.Force);
        }
    }

    void Patrol()
    {

    }

    void SinCurveMove()
    {
        //if (_Posidis >= _x)
        //{
            _x = Mathf.Sin(_time * _horiSpeed) * _originalX;
        //Debug.Log(_x);
            //transform.position = new Vector2(_x, transform.position.y);
        m_rb.velocity = new Vector2(_x, m_rb.velocity.y);
        //m_rb.AddForce(Vector2.right * _x, ForceMode2D.Force);
        //}
        //else if (_Negadis <= _x)
        //{
        //    _x = Mathf.Sin(_time * _horiSpeed) + _originalX;
        //    m_rb.AddForce(Vector2.left * _x, ForceMode2D.Force);
        //}
    }

    void CatchMove()
    {

    }
}

    
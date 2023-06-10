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

    Vector3 m_initialPosition;
    Rigidbody2D m_rb = default;

    // Start is called before the first frame update
    void Start()
    {
        m_initialPosition = this.transform.position;
        m_rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
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

    void CatchMove()
    {

    }
}

    
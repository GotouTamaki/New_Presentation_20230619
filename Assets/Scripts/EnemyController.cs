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
    //[SerializeField]
    //protected float _vertSpeed = 1f;
    //[SerializeField]
    //protected float _horiSpeed = 1f;
    [SerializeField]
    float _originalX = 1f;

    Vector3 _initialPosition;
    Rigidbody2D _rb = default;
    float _x = 0;
    float _time = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        _initialPosition = this.transform.position;
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (InsideCamera() == true)
        {
            _time += Time.deltaTime;
        }
        else if (InsideCamera() == false)
        {
            _rb.velocity = new Vector2(0, 0);
            //Debug.Log("止まる");
        }
    }

    private void FixedUpdate()
    {
        if (InsideCamera())
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
        float distance = Vector2.Distance(this.transform.position, _initialPosition);

        if (distance > _stoppingDistance)  // ターゲットに到達するまで処理する
        {
            Vector3 dir = (_initialPosition - this.transform.position).normalized * _moveSpeed; // 移動方向のベクトルを求める
            _rb.AddForce(dir * _moveSpeed, ForceMode2D.Force);
        }
    }

    void Patrol()
    {

    }

    void SinCurveMove()
    {
        _x = Mathf.Sin(_time * _moveSpeed) * _originalX;
        //Debug.Log(_x);
        _rb.velocity = new Vector2(_x, _rb.velocity.y);
    }

    void CatchMove()
    {

    }

    public bool InsideCamera()
    {
        float x = Camera.main.ViewportToWorldPoint(Vector2.one).x;
        float y = Camera.main.ViewportToWorldPoint(Vector2.one).y;
        if (x > transform.position.x && transform.position.x > Camera.main.ViewportToWorldPoint(Vector2.zero).x &&
            y > transform.position.y && transform.position.y > Camera.main.ViewportToWorldPoint(Vector2.zero).y)
        {
            return true;
        }
        return false;

    }
}

    
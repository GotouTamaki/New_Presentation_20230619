using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEngine.GraphicsBuffer;

public class TargetController : MonoBehaviour
{
    //プレイヤーを取得
    [SerializeField]
    GameObject _player;

    LineRenderer _line;
    bool _canHook = false;
    GameObject _target;

    // Start is called before the first frame update
    void Start()
    {
        //LineRenderere関連の設定
        //コンポーネントを取得する
        this._line = GetComponent<LineRenderer>();
        //線の幅を決める
        this._line.startWidth = 0.1f;
        this._line.endWidth = 0.1f;
        //頂点の数を決める
        this._line.positionCount = 2;
    }

    // Update is called once per frame
    void Update()
    {

        //フックを掛けられるかどうか
        _player.GetComponent<PlayerController>()._CanHook = _canHook;

        if (Input.GetButton("Fire1") && _canHook)
        {
            this.transform.position = this.transform.position;
        }
        else
        {
            TargetMove();
        }

        _line.SetPosition(0, this.transform.position);
        _line.SetPosition(1, this._player.transform.position);
    }

    private void TargetMove()
    {
        // Camera.main でメインカメラ（MainCamera タグの付いた Camera）を取得する
        // Camera.ScreenToWorldPoint 関数で、スクリーン座標をワールド座標に変換する
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // ターゲットが見えなくなってしまうため、Z 座標を調整している
        mousePosition.z = -5;
        this.transform.position = mousePosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_target && (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Anchor"))
        {
            _target = collision.gameObject;
            //Debug.Log($"Target: {_target.name}");
            SpriteRenderer Cr = GetComponent<SpriteRenderer>();
            Cr.color = Color.green;
            _canHook = true;
        }

        //if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Anchor")
        //{
        //    Debug.Log("引っかかる");
        //    SpriteRenderer Cr = GetComponent<SpriteRenderer>();
        //    Cr.color = Color.green;
        //    _canHook = true;
        //}
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_target)
        {
            _target = null;
            //Debug.Log($"Target: null");
            SpriteRenderer Cr = GetComponent<SpriteRenderer>();
            Cr.color = Color.white;
            _canHook = false;
        }
        //if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Anchor")
        //{
        //    Debug.Log("外れた");
        //    SpriteRenderer Cr = GetComponent<SpriteRenderer>();
        //    Cr.color = Color.white;
        //    _canHook = false;
        //} 
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!_target && (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Anchor"))
        {
            _target = collision.gameObject;
            //Debug.Log($"Target: {_target.name}");
            SpriteRenderer Cr = GetComponent<SpriteRenderer>();
            Cr.color = Color.green;
            _canHook = true;
        }
    }
}

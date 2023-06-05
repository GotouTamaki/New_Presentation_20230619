using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TargetController : MonoBehaviour
{
    //プレイヤーを取得
    [SerializeField]
    GameObject _prayer;

    LineRenderer _line;
    bool _canHook = false;

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
        // Camera.main でメインカメラ（MainCamera タグの付いた Camera）を取得する
        // Camera.ScreenToWorldPoint 関数で、スクリーン座標をワールド座標に変換する
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // ターゲットが見えなくなってしまうため、Z 座標を調整している
        mousePosition.z = -5;
        this.transform.position = mousePosition;

        _prayer.GetComponent<PlayerController>()._CanHook = _canHook;

        _line.SetPosition(0, this.transform.position);
        _line.SetPosition(1, this._prayer.transform.position);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Anchor")
        {
            //Debug.Log("引っかかる");
            SpriteRenderer Cr = GetComponent<SpriteRenderer>();
            Cr.color = Color.green;
            _canHook = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Anchor")
        {
            //Debug.Log("取れた");
            SpriteRenderer Cr = GetComponent<SpriteRenderer>();
            Cr.color = Color.white;
            _canHook = false;
        } 
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIManeger : MonoBehaviour
{
    // 経過時間を表示するオブジェクト
    [SerializeField]
    Text _timer = default;

    public static float _bestTime = 9999.99f;
    float _time = 0;
    float _clearTime = 9999.99f;
    public bool _gameClear = false;

    // Start is called before the first frame update
    void Start()
    {
        _time = 0.0f;
        _timer.text = "0.00"; 
    }

    // Update is called once per frame
    void Update()
    {
        // TimeText にプレイ時間を表示する
        _time += Time.deltaTime;
        _timer.text = _time.ToString("F2");

        if (_clearTime < _bestTime)
        {
            _bestTime = _clearTime;

        }
    }
}

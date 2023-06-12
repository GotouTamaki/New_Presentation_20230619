using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIManeger : MonoBehaviour
{
    // 経過時間を表示するオブジェクト
    [SerializeField]
    Text _timer = default;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // TimeText にプレイ時間を表示する
        _timer.text = Time.time.ToString("F2");
    }
}

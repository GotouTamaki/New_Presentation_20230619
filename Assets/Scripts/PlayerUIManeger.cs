using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIManeger : MonoBehaviour
{
    // �o�ߎ��Ԃ�\������I�u�W�F�N�g
    [SerializeField]
    Text _timer = default;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // TimeText �Ƀv���C���Ԃ�\������
        _timer.text = Time.time.ToString("F2");
    }
}

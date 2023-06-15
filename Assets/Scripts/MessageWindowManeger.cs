using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessegeWindow : MonoBehaviour
{
    [SerializeField]
    RectTransform canvasRect;

    [SerializeField]
    GameObject _messagwWindow;

    void OnEnable()
    {
        //_messagwWindow.targetTran = transform;
    }

    void OnDisable()
    {
        if (_messagwWindow == null) return;

        Destroy(_messagwWindow.gameObject);
    }
}

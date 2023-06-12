using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManeger : MonoBehaviour
{
    [SerializeField]
    GameObject _statusWindow;

    // Start is called before the first frame update
    void Start()
    {
        _statusWindow.SetActive(false);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //Time.timeScale = 1;

        if (Input.GetKeyDown("escape"))
        {
            _statusWindow.SetActive(!_statusWindow.activeSelf);

            if (!_statusWindow.activeSelf)
            {
                Time.timeScale = 1;
                Debug.Log("memu crose");
            }
            else
            {
                Time.timeScale = 0;
                Debug.Log("memu ");
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LassoController : MonoBehaviour
{
    [SerializeField]
    float _angularSpeed = 360f;
    [SerializeField]
    float _extendLength = 3;
    [SerializeField]
    float _InitialLength = 0.5f;

    public bool LookingRight = true;
    // 最初に出現した座標
    Vector3 m_initialPosition;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire2"))
        {
            transform.localScale = new Vector3(1, 3, 1);
            transform.rotation *= Quaternion.AngleAxis(_angularSpeed * Time.deltaTime, Vector3.forward); 
        }

        if (Input.GetButtonUp("Fire2"))
        {
            transform.localScale = new Vector3(1, _InitialLength, 1);

        }

        if (Input.GetButton("Fire1"))
        {
            //Debug.Log("ここに投げ縄を発射する処理を書く。");
            //lasso.GetComponent<LassoController>().LookingRight = lookingright;
            if (Input.GetButton("Fire1"))
            {
                transform.localScale = new Vector3(1, _extendLength, 1);;
            }
        }

        if (Input.GetButtonUp("Fire1"))
        {
            transform.localScale = new Vector3(1, _InitialLength, 1);
        }

        // 下に行きすぎたら初期位置に戻す
        if (this.transform.position.y < -10f)
        {
            this.transform.position = m_initialPosition;
        }
    }

}


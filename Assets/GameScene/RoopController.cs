using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RoopController : MonoBehaviour
{
    [SerializeField]
    GameObject _crossehair;//�J�[�\��
    //[SerializeField]
    //float _angularSpeed = 360f;//�U��񂷑���
    //[SerializeField]
    //float _extendLength = 3;//�L�т���̒���
    //[SerializeField]
    //float _InitialLength = 0.5f;//���̒����ɖ߂�

    public bool LookingRight = true;
    // �ŏ��ɏo���������W
    Vector3 m_initialPosition;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //�^�[�Q�b�g�̈ʒu
        //this.transform.up = _crossehair.transform.position - transform.position;

        if (Input.GetButton("Fire2"))
        {
            //transform.localScale = new Vector3(1, 3, 1);
            //transform.rotation *= Quaternion.AngleAxis(_angularSpeed * Time.deltaTime, Vector3.forward); 
        }

        if (Input.GetButtonUp("Fire2"))
        {
            //transform.localScale = new Vector3(1, _InitialLength, 1);

        }

        if (Input.GetButton("Fire1"))
        {
            //Debug.Log("�����ɓ�����𔭎˂��鏈���������B");
            //lasso.GetComponent<LassoController>().LookingRight = lookingright;
            if (Input.GetButton("Fire1"))
            {
                //transform.localScale = new Vector3(1, _extendLength, 1);;
            }
        }

        //if (Input.GetButtonUp("Fire1"))
        //{
        //    transform.localScale = new Vector3(1, _InitialLength, 1);
        //}

        // ���ɍs���������珉���ʒu�ɖ߂�
        if (this.transform.position.y < -10f)
        {
            this.transform.position = m_initialPosition;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] MoveMode _moveMode;
    [Tooltip("�I�u�W�F�N�g�̈ړ����x")]
    [SerializeField] float _moveSpeed = 1f;
    [Tooltip("�^�[�Q�b�g�ɓ��B�����Ɣ��f���鋗���i�P��:���[�g���j")]
    [SerializeField] float _stoppingDistance = 0.05f;

    Vector3 m_initialPosition;
    Rigidbody2D m_rb = default;

    // Start is called before the first frame update
    void Start()
    {
        m_initialPosition = this.transform.position;
        m_rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
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
        else if (_moveMode == MoveMode.CatchMove)
        {
            CatchMove();
        }

    }

    enum MoveMode
    {
        MoveStope,
        MovePoint0,
        Patrol,
        CatchMove,
    }

    void MoveStope()
    {
        //Debug.Log("�G��~");
    }

    void MovePoint0() 
    {
        // �������g�ƃ^�[�Q�b�g�̋��������߂�
        float distance = Vector2.Distance(this.transform.position, m_initialPosition);

        if (distance > _stoppingDistance)  // �^�[�Q�b�g�ɓ��B����܂ŏ�������
        {
            Vector3 dir = (m_initialPosition - this.transform.position).normalized * _moveSpeed; // �ړ������̃x�N�g�������߂�
            m_rb.AddForce(dir * _moveSpeed, ForceMode2D.Force);
        }
    }

    void Patrol()
    {

    }

    void CatchMove()
    {

    }
}

    
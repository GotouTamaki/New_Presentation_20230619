using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringManeger : MonoBehaviour
{
    [SerializeField]
    private float _jumpForce = 20.0f;    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // 当たった相手のRigidbodyコンポーネントを取得して、上向きの力を加える
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }
}

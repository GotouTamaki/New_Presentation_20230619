using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoopController : MonoBehaviour
{
    [SerializeField]
    GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        Debug.Log(target.transform.position);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        target = GameObject.Find("Enemy");

    }
}

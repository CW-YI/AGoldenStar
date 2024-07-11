using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrapStart : MonoBehaviour
{
    Rigidbody2D rigid;
    bool isStart = true;
    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (isStart) rigid.constraints = RigidbodyConstraints2D.None;
    }
    public void StartTrap()
    {
        //isStart = true;
        
    }

}

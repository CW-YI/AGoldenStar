using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerWayIn : MonoBehaviour
{
    public BoxCollider2D entrance;
    public Material lightMaterial;
    public SpriteRenderer player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            entrance.isTrigger = false;
            player.material = lightMaterial;
        }
    }
}

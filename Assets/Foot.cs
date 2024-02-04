using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foot : MonoBehaviour
{
    private bool isOnGround;

    // Start is called before the first frame update
    void Start()
    {
        isOnGround = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            gameObject.GetComponentInParent<Movement>().setJump();
        }
    }

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag != "Player")
    //    {
    //        gameObject.GetComponentInParent<Movement>().setJump();
    //    }
    //}

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            isOnGround = false;
        }
    }

    //public bool grounded()
    //{
    //    Debug.Log("isOnGround:" + isOnGround);
    //    return isOnGround;
    //}
}

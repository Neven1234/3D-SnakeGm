using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class body : MonoBehaviour
{
    // Start is called before the first frame update
    public bool hitBody = false;
    public static body Body;


    private void Awake()
    {
        Body = this;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "Head" )
        {
            hitBody = true;
            Debug.Log("game over hit body");
            
        }
    }


    }

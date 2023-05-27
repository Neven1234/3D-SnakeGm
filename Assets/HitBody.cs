using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBody : MonoBehaviour
{
    public GameObject GameOver;
    private void OnCollisionEnter(Collision collision)
    {
      if ( collision.collider.tag == "body")
      {
            Debug.Log("game over body hit by eays");
            GameOver.SetActive(true);
      }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

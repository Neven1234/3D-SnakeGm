using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followSnake : MonoBehaviour
{
    public Transform snake;
    public Vector3 gap;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        gameObject.transform.position = snake.position+gap;
    }
}

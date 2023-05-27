using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class snakeCountroler : MonoBehaviour
{
    public static snakeCountroler SnakeCountroler;
    // Settings
    public float MoveSpeed = 5;
    public float SteerSpeed = 180;
    public float BodySpeed = 5;
    public int Gap = 10;
    bool flag=false;
    public GameObject appleToSpwon;
    private GameObject appleRand;
    // References
    public GameObject BodyPrefab;
    public GameObject GameOver;
    float posx;
    float posz;
    // score
    public Text score;
    public int counter=0;
    // Lists
    private List<GameObject> BodyParts = new List<GameObject>();
    private List<Vector3> PositionsHistory = new List<Vector3>();
    private void Awake()
    {
        SnakeCountroler = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        spownApples();
        GrowSnake();
        ScourUpdate();

    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "walls" )
        {

            Debug.Log("game over");
            GameOver.SetActive(true);

        }
        if(collision.collider.tag=="apple")
        {
            Debug.Log("Aplle");
            eatedApple();
            spownApples();
            counter++;
            ScourUpdate();
        }

       
        
       
    }
    // Update is called once per frame
    void Update()
    {
       
        if(body.Body.hitBody==true && counter!=0)
        {
            Debug.Log("game over hit buy eays");
            GameOver.SetActive(true);
        }
        // Move forward
        transform.position += transform.forward * MoveSpeed * Time.deltaTime;

        // Steer
        float steerDirection = Input.GetAxis("Horizontal"); // Returns value -1, 0, or 1
        transform.Rotate(Vector3.up * steerDirection * SteerSpeed * Time.deltaTime);

        // Store position history
        PositionsHistory.Insert(0, transform.position);

        // Move body parts
        int index = 0;
        foreach (var body in BodyParts)
        {
            Vector3 point = PositionsHistory[Mathf.Clamp(index * Gap, 0, PositionsHistory.Count - 1)];

            // Move body towards the point along the snakes path
            Vector3 moveDirection = point - body.transform.position;
            body.transform.position += moveDirection * BodySpeed * Time.deltaTime;

            // Rotate body towards the point along the snakes path
            body.transform.LookAt(point);

            index++;
        }
    }

    private void GrowSnake()
    {
        if(counter!=0)
        {
            GameObject body = Instantiate(BodyPrefab, BodyParts[BodyParts.Count-1].transform.position, BodyParts[BodyParts.Count - 1].transform.rotation);
            BodyParts.Add(body);
        }
        else
        {
            GameObject body = Instantiate(BodyPrefab, transform.position, transform.rotation);
           BodyParts.Add(body);
        }
         
        
    }
    private void eatedApple()
    {
        GrowSnake();
        Destroy(appleRand);
    }
    private void spownApples()
    {
        posx = Random.Range( -4,  4);
        posz = Random.Range( -4,  4);
        Vector3 randompos = new Vector3(posx,2,posz);
        appleRand = Instantiate(appleToSpwon, randompos,gameObject.transform.rotation);
        Debug.Log("apple");
    }
    private void ScourUpdate()
    {
        score.text = counter.ToString();
        if(counter>PlayerPrefs.GetInt("High Score",0))
        {
            PlayerPrefs.SetInt("High Score", counter);
        }
    }
}

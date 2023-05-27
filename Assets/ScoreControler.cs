using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreControler : MonoBehaviour
{
    public Text HighScore;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        HighScore.text = PlayerPrefs.GetInt("High Score", 0).ToString();
    }
}

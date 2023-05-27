using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameplay;
    // Start is called before the first frame update
    void Start()
    {
        gameplay.SetActive(false);
    }

    // Update is called once per frame
    public void Restart()
    {
        SceneManager.LoadScene("GamePlay");
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}

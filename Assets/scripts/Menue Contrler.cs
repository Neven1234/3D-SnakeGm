using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenueContrler : MonoBehaviour
{
    public void starting()
    {
        SceneManager.LoadScene("GamePlay");
    }
    public void Exit()
    {
        Application.Quit();
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class objectiveLogic : MonoBehaviour
{
    public int pointsToSuccess;

    void Start()
    {
        pointsToSuccess = PlayerPrefs.GetInt("pointsToWin");
    }
    void OnTriggerEnter2D(Collider2D collision)
    {      
        if (pointsToSuccess == 2)
        {
            if (collision.tag == "Character")
            {
                SceneManager.LoadScene("Win");
            }
        }
        
    }
}

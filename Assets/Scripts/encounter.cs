using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class encounter : MonoBehaviour
{
    bool stopCombat;

    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Character")
        {
            switch (Random.Range(0, 7))
            {
                case 0:
                    PlayerPrefs.SetFloat("PlayerX", transform.position.x);
                    PlayerPrefs.SetFloat("PlayerY", transform.position.y);
                    PlayerPrefs.SetFloat("PlayerZ", transform.position.z);
                    SceneManager.LoadScene("Combat");
                    break;

                default:
                    
                    break;
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        
    }
}

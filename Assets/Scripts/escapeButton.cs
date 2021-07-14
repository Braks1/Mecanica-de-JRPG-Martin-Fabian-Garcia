using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class escapeButton : MonoBehaviour
{
    public Player player;
    public combatLogic combatLogic;
    
    public void escape()
    {

        SceneManager.LoadScene("SampleScene");

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class combatLogic : MonoBehaviour
{
    public Text hpET;
    public Text hpPT;
    public Text AtkET;
    public Text AtkPT;
    public Text defET;
    public Text defPT;
    public GameObject aPT;
    public GameObject aET;
    public GameObject aDE;
    public GameObject pDE;
    public GameObject PanelW1;
    public GameObject PanelW2;
    public GameObject eST;
    public GameObject victoryText;
    public GameObject loseText;
    public GameObject explosion;
    public GameObject explosion2;
    public int hpE;
    public int hpP;
    public int AtkE;
    public int AtkP;
    public int defE;
    public int defP;
    bool isDead = false;
    public objectiveLogic objectiveLogic;
    


    void Start()
    {
        
        // Stats enemigo //
        hpE = 120;
        defE = 30;
        AtkE = 60;
        // Stats prota //
        hpP = 210;
        defP = 20;
        AtkP = 80;

    }

    void Update()
    {
        // stats enemigo pantalla // 
        hpET.text = "" + hpE;
        defET.text = "" + defE;
        AtkET.text = "" + AtkE;
        // stats jugador pantalla //
        hpPT.text = "" + hpP;
        defPT.text = "" + defP;
        AtkPT.text = "" + AtkP;

        if (hpE <= 0)
        {
            hpE = 0;
        }
        if (defE <= 0)
        {
            defE = 0;
        }
        if (AtkE <= 0)
        {
            AtkE = 0;
        }
        if (hpP <= 0)
        {
            hpP = 0;
        }
        if (defP <= 0)
        {
            defP = 0;
        }
        if (AtkP <= 0)
        {
            AtkP = 0;
        }
        if (defP >= 65)
        {
            defP = 65;
        }
    }

    public void playerAttackAction()
    {




        hpE -= AtkP - defE;
        if (hpE <= 0)
        {
            explosion.SetActive(true);
            StartCoroutine(Win());
        }
        else
        {
            StartCoroutine(waitTimeAttackP());
        }

    }

    public void playerDefenseAction()
    {
        StartCoroutine(playerDefenseA());
    }

    public void enemyChoose()
    {
        switch (Random.Range(0, 3))
        {
            case 0:
                StartCoroutine(enemyAttackA());
                break;
            case 1:
                StartCoroutine(enemyDefenseA());
                break;
            case 2:
                StartCoroutine(enemyScare());
                break;

        }
    }

    public void enemyAttack()
    {
        hpP -= AtkE - defP;
        if (hpP <= 0)
        {
            isDead = true;
            explosion2.SetActive(true);
            StartCoroutine(Lose());
        }

    }


    public void enemyDefense()
    {
        defE += 30;
        if (defE >= 60)
        {
            defE = 60;
        }
    }

    public void playerDefense()
    {
        defP += 30;

    }

    IEnumerator waitTimeAttackP()
    {



        PanelW1.SetActive(true);
        PanelW2.SetActive(true);
        aPT.SetActive(true);
        yield return new WaitForSecondsRealtime(2);
        aPT.SetActive(false);
        enemyChoose();
    }

    IEnumerator enemyAttackA()
    {
        enemyAttack();
        if (isDead == false)
        {
            aET.SetActive(true);
            yield return new WaitForSecondsRealtime(2);
            aET.SetActive(false);
            PanelW1.SetActive(false);
            PanelW2.SetActive(false);
        }
    }

    IEnumerator enemyDefenseA()
    {
        enemyDefense();
        aDE.SetActive(true);
        yield return new WaitForSecondsRealtime(2);
        aDE.SetActive(false);
        PanelW1.SetActive(false);
        PanelW2.SetActive(false);

    }

    IEnumerator playerDefenseA()
    {
        PanelW1.SetActive(true);
        PanelW2.SetActive(true);
        playerDefense();
        pDE.SetActive(true);
        yield return new WaitForSecondsRealtime(2);
        pDE.SetActive(false);
        enemyChoose();
    }

    IEnumerator enemyScare()
    {
        eST.SetActive(true);
        yield return new WaitForSecondsRealtime(2);
        eST.SetActive(false);
        PanelW1.SetActive(false);
        PanelW2.SetActive(false);
    }

    IEnumerator Win()
    {
        PlayerPrefs.SetInt("pointsToWin", +1);
        if (PlayerPrefs.GetInt("pointsToWin", 1) == (PlayerPrefs.GetInt("pointsToWin", 1)))
        {
            PlayerPrefs.SetInt("pointsToWin", +2);
        }
        PanelW1.SetActive(true);
        PanelW2.SetActive(true);
        victoryText.SetActive(true);
        yield return new WaitForSecondsRealtime(2);
        SceneManager.LoadScene("SampleScene");


    }
    IEnumerator Lose()
    {
        PanelW1.SetActive(true);
        PanelW2.SetActive(true);
        loseText.SetActive(true);
        yield return new WaitForSecondsRealtime(2);
        SceneManager.LoadScene("Lose");

    }



    public static void AddInt(string key, int numberToAdd)
    {
        //Check if the key exist
        if (UnityEngine.PlayerPrefs.HasKey(key))
        {
            //Read old value
            int value = UnityEngine.PlayerPrefs.GetInt(key);

            //Increment
            value += numberToAdd;

            //Save it back
            UnityEngine.PlayerPrefs.SetInt(key, value);
        }

    }
}

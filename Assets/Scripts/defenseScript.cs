using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class defenseScript : MonoBehaviour
{
    public combatLogic combatLogic;


    public void playerDefense()
    {
        combatLogic.playerDefenseAction();
    }
}

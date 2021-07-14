using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackButton : MonoBehaviour
{
    public combatLogic combatLogic;
    bool wait;
    
    
    public void playerAttack()
    {
        combatLogic.playerAttackAction();
    }
}

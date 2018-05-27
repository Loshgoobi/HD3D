using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/KillAllAbility")]
public class KillAllAbility : Ability
{


    private KillAllTriggerable kill;

    public override void Initialize(GameObject obj)
    {
        kill = obj.GetComponent<KillAllTriggerable>();
    }

    public override void TriggerAbility()
    {

        kill.KillAll();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/MissileAbility")]
public class MissileAbility : Ability
{

    public Rigidbody missile;

    private MissileShootTriggerable launcher;

    public override void Initialize(GameObject obj)
    {
        launcher = obj.GetComponent<MissileShootTriggerable>();
        launcher.missile = missile;
    }

    public override void TriggerAbility()
    {
        launcher.Launch();
    }

}

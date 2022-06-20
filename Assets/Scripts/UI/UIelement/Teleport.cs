using System;
using UnityEngine;

public class Teleport : Ability
{
    public GameObject teleportationProjectile;
    public GameObject player;
    private void Update()
    {
        abilityPressed = inputManager.teleportPressed;
        CheckState();
        fillObject();
    }

    protected override void DoWhenAbilityIsTriggered()
    {
        GameObject projectile = Instantiate(teleportationProjectile, player.transform.position, Quaternion.Euler(player.transform.rotation.eulerAngles), null);
//        if (childProjectileToFireLocation)
//        {
//            projectile.transform.SetParent(fireLocationTransform);
//        }
        base.DoWhenAbilityIsTriggered();
    }

    protected override void DoWhenAbilityIsFinished()
    {
        base.DoWhenAbilityIsFinished();
    }
}
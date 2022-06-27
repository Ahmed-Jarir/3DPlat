using UnityEngine;

public class UnlockAbilityPickup : Pickup
{
    public Ability ability;
    public override void DoOnPickup(Collider collision)
    {
        if (collision.tag == "Player")
        {
            ability.unlockAbility();
        }
        base.DoOnPickup(collision);
    }

}

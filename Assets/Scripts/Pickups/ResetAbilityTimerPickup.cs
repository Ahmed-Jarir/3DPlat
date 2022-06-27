using UnityEngine;
public class ResetAbilityTimerPickup : Pickup
{
    public Ability ability;
    public override void DoOnPickup(Collider collision)
    {
        if (collision.tag == "Player")
        {
            ability.resetAbilityTimer();
        }
        base.DoOnPickup(collision);
    }
}

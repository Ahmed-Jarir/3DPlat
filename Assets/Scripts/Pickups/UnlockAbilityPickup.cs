using UnityEngine;

public class UnlockAbilityPickup : Pickup
{
    public int abilityInfoPageNum;
    public UIManager uiManager;
    public Ability ability;
    public override void DoOnPickup(Collider collision)
    {
        if (collision.tag == "Player")
        {
            ability.unlockAbility();
            if (uiManager != null)
            {
                uiManager.TriggerAbilityInformation(abilityInfoPageNum);
            }
        }
        base.DoOnPickup(collision);
    }

}

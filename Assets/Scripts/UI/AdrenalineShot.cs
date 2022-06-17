using UnityEngine;

public class AdrenalineShot : Ability
{
    public float timeChanger = 0.5f;
    

    void Update()
    {
        abilityPressed = inputManager.adrenalinePressed;

        fillObject();
    }

    protected override void DoWhenAbilityIsTriggered()
    {
        Time.timeScale = timeChanger;
        base.DoWhenAbilityIsTriggered();
    }

    protected override void DoWhenAbilityIsFinished()
    {
        Time.timeScale = 1;
    }


}
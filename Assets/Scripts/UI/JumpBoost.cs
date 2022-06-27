using System;
using UnityEngine;
public class JumpBoost : Ability
{
    public ThirdPersonCharacterController playerCont;
    public float newJumpStrength;
    private float originalJumpStrength;

    private void Awake()
    {
        originalJumpStrength = playerCont.jumpStrength;
    }

    void Update()
    {
        abilityPressed = inputManager.JumpBoostPressed;
        fillObject();
        CheckState();
    }
    
    protected override void DoWhenAbilityIsTriggered()
    {
        
        playerCont.jumpStrength = newJumpStrength;
        base.DoWhenAbilityIsTriggered();
    }
    
    protected override void DoWhenAbilityIsFinished()
    {
        playerCont.jumpStrength = originalJumpStrength;
        base.DoWhenAbilityIsFinished();
    }


}

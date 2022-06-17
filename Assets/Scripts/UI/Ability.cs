using System;
using UnityEngine;
using UnityEngine.UI;

public class Ability : MonoBehaviour
{
    public InputManager inputManager;
    
    public float TimeForAbilityToBeAvailable;
    public float timeForAbilityToStop;
    
    public Image ImageToFill;
    public GameObject abilityNotReadyEffect;
    public GameObject abilityTriggerEffect;
    

    protected bool abilityPressed;
    protected bool abilityTriggered = false;

    
    private float AbilityTimer;

    void Start()
    {
        AbilityTimer = Time.time;
    }

    void Update()
    {

        if (abilityPressed && !OnCooldown() && !abilityTriggered)
        {
            DoWhenAbilityIsTriggered();
            AbilityTimer = Time.time;
            abilityTriggered = true;
        }
        else if (abilityPressed)
        {
            if (abilityNotReadyEffect != null)
            {
                Instantiate(abilityNotReadyEffect, transform.position, Quaternion.identity, null);
            }
        }

        if (abilityTriggered && AbilityFinished())
        {
            DoWhenAbilityIsFinished();
            AbilityTimer = Time.time;
            abilityTriggered = false;
        }
    }

    private bool OnCooldown()
    {
        if (TimeForAbilityToBeAvailable >= Time.time - AbilityTimer && !abilityTriggered)
        {
            return false;
        }
        return true;
    }

    private bool AbilityFinished()
    {
        if (Time.time - AbilityTimer <= timeForAbilityToStop)
        {
            return true;
        }
        return false;
    }

    protected void fillObject()
    {
        if (ImageToFill != null && TimeForAbilityToBeAvailable <= Time.time - AbilityTimer && !abilityTriggered)
        {
            float percentage = (float) (Time.time - AbilityTimer) / (float) TimeForAbilityToBeAvailable;
            ImageToFill.fillAmount = percentage;
        }

        if (abilityTriggered)
        {
            float percentage = 1f - (float) (Time.time - AbilityTimer) / (float) timeForAbilityToStop;
            ImageToFill.fillAmount = percentage;
        }

    }

    protected virtual void DoWhenAbilityIsTriggered()
    {
        if (abilityTriggerEffect != null)
        {
            Instantiate(abilityTriggerEffect, transform.position, Quaternion.identity, null);
        }
    }

    protected virtual void DoWhenAbilityIsFinished(){}

}

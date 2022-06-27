using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ability : MonoBehaviour
{
    
    public float timeForAbilityToBeAvailable = 10f;
    public float timeForAbilityToStop = 10f;

    public GameObject abilityGameObject;
    public List<Image> ImagesToFill = null;
    public GameObject abilityTriggerEffect = null;
    public GameObject abilityFinishedEffect = null;


    protected InputManager inputManager;
    protected bool abilityPressed = false;
    

    
    private float AbilityTimer;
    private enum CurrentState{
      Locked,
      ReadyToActivate,
      Active,
      OnCooldown,
    }

    private CurrentState state;

    void  Start()
    {
        bool abilityUnlocked = PlayerPrefs.GetInt(abilityGameObject.name) == 1;
        abilityGameObject.SetActive(abilityUnlocked); 
        state = abilityUnlocked ? CurrentState.ReadyToActivate : CurrentState.Locked;
        inputManager = InputManager.instance;
    }

    public void unlockAbility()
    {
       abilityGameObject.SetActive(true);
       state = CurrentState.ReadyToActivate;
       PlayerPrefs.SetInt(abilityGameObject.name, 1);
    }

    public void resetAbilityTimer()
    {
        state = CurrentState.ReadyToActivate;
        AbilityTimer = 0;
    }

    protected void CheckState()
    {
        
        switch (state)
        {
            case  CurrentState.ReadyToActivate:
                if (abilityPressed)
                {
                    DoWhenAbilityIsTriggered();
                    AbilityTimer = timeForAbilityToStop;
                    state = CurrentState.Active;
                }
                break;
            case  CurrentState.OnCooldown:
                if (AbilityTimer > 0)
                {
                    AbilityTimer -= Time.deltaTime;
                }
                else
                {
                    state = CurrentState.ReadyToActivate;
                }
                break;
            //if the ability is running
            case CurrentState.Active:
                if (AbilityTimer > 0)
                {
                    AbilityTimer -= Time.deltaTime;
                }
                else
                {
                    DoWhenAbilityIsFinished();
                    AbilityTimer = timeForAbilityToBeAvailable;
                    state = CurrentState.OnCooldown;
                }
                break;
        }
        
        
    }

    protected void fillObject()
    {
            float percentage;
            switch (state)
            {
                case  CurrentState.OnCooldown:
                    percentage = (float) (AbilityTimer) / (float) timeForAbilityToBeAvailable;
                    foreach (var Image in ImagesToFill)
                    {
                        Image.fillAmount = percentage;
                    }

                    break;
                //if the ability is running
                case CurrentState.Active:
                    percentage = 1f - (float) (AbilityTimer) / (float) timeForAbilityToStop;
                    foreach (var Image in ImagesToFill)
                    {
                        Image.fillAmount = percentage;
                    }
                    break;
            }
    }

    protected virtual void DoWhenAbilityIsTriggered()
    {
        if (abilityTriggerEffect != null)
        {
            Instantiate(abilityTriggerEffect, transform.position, Quaternion.identity, null);
        }
    }

    protected virtual void DoWhenAbilityIsFinished(){        
        if (abilityFinishedEffect != null)
        {
            Instantiate(abilityFinishedEffect, transform.position, Quaternion.identity, null);
        }
        
    }

}

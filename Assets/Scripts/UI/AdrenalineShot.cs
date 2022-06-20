using UnityEditor;
using UnityEngine;

public class AdrenalineShot : Ability
{
    public float timeChanger = 0.3f;

    void Awake()
    {
        timeForAbilityToStop *= timeChanger;
    }
    void Update()
    {
        abilityPressed = inputManager.adrenalinePressed;
        fillObject();
        CheckState();
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
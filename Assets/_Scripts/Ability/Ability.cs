using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : ScriptableObject
{
    public new string name;
    public float cooldownTime;
    public float activeTime;
    //public AbilityState state = AbilityState.ready;
    public KeyCode abKey;
    public abstract void Activate(GameObject parent);
    public abstract void EndActivate(GameObject parent);


    public enum AbilityState
    {
        ready,
        active,
        cooldown
    }

    /*IEnumerator ActivateAbilityCoroutine(Ability ability)
    {
        yield return new WaitForSeconds(.1f);
    }*/
}

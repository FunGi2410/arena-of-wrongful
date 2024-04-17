using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityHolder : MonoBehaviour
{
    [SerializeField] private List<Ability> abilities;
    float[] cooldownTime = new float[3];
    float[] activeTime = new float[3];
    Ability.AbilityState[] states = new Ability.AbilityState[3];

    private void Start()
    {
        states[0] = Ability.AbilityState.ready;
        states[1] = Ability.AbilityState.ready;
        states[2] = Ability.AbilityState.ready;
    }

    private void Update()
    {
        // Skill 1
        ActivateAbility(abilities[0], ref activeTime[0], ref cooldownTime[0], ref states[0]);
        // Skill 2
        ActivateAbility(abilities[1], ref activeTime[1], ref cooldownTime[1], ref states[1]);
        // Skill 3
        ActivateAbility(abilities[2], ref activeTime[2], ref cooldownTime[2], ref states[2]);
    }

    void ActivateAbility(Ability ability, ref float activeTime, ref float cooldownTime, ref Ability.AbilityState state)
    {
        switch (state)
        {
            case Ability.AbilityState.ready:
                if (Input.GetKeyDown(ability.abKey))
                {
                    ability.Activate(gameObject);
                    state = Ability.AbilityState.active;
                    activeTime = ability.activeTime;
                }
                break;
            case Ability.AbilityState.active:
                if (activeTime > 0)
                {
                    activeTime -= Time.deltaTime;
                }
                else
                {
                    ability.EndActivate(gameObject);
                    state = Ability.AbilityState.cooldown;
                    cooldownTime = ability.cooldownTime;
                }
                break;
            case Ability.AbilityState.cooldown:
                if (cooldownTime > 0)
                {
                    cooldownTime -= Time.deltaTime;
                }
                else
                {
                    state = Ability.AbilityState.ready;
                }
                break;
        }
    }

    /*
     Tạo Ability theo MonoBehavior, sau đó tạo 1 script Ability theo ScriptableObject
     
     */

    /*IEnumerator ActivateAbilityCoroutine(Ability ability)
    {
        while (ability.state != Ability.AbilityState.ready)
        {

        }
        yield return new WaitForSeconds(this.coolDown);
    }*/
}

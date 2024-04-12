using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class XaTien : Ability
{
    [SerializeField] GameObject projectilePref;
    [SerializeField] Transform origin;
    public override void Activate(GameObject parent)
    {
        origin = parent.transform.GetChild(1);
        GameObject obj = Instantiate(this.projectilePref, origin.position, parent.transform.rotation);
    }

    public override void EndActivate(GameObject parent)
    {
        
    }
}

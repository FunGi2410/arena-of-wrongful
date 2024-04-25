using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BongLo_Ability : Ability
{
    [SerializeField] GameObject objPref;
    [SerializeField] Transform origin;
    GameObject objInstance;
    public override void Activate(GameObject parent)
    {
        origin = parent.transform.GetChild(1);
        objInstance = Instantiate(this.objPref, origin.position, parent.transform.rotation);
        objInstance.transform.parent = origin;
    }

    public override void EndActivate(GameObject parent)
    {
        Destroy(objInstance);
    }
}

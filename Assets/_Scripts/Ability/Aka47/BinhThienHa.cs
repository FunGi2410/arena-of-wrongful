using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BinhThienHa : Ability
{
    [SerializeField] GameObject multiAkGun;
    [SerializeField] Transform origin;

    GameObject objInstance;
    public override void Activate(GameObject parent)
    {
        origin = parent.transform.GetChild(2);
        objInstance = Instantiate(this.multiAkGun, origin.position, parent.transform.rotation);
        objInstance.transform.parent = origin;
    }

    public override void EndActivate(GameObject parent)
    {
        Destroy(objInstance);
    }
}

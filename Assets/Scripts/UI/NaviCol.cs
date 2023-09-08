using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaviCol : MonoBehaviour
{
    private void OnTriggerStay(Collider collision)
    {
        WorldVar.disRemain -= 1;
        if (WorldVar.disRemain <= 0) {
            WorldVar.disRemain = 0;
        }
        Destroy(gameObject);
    }

}

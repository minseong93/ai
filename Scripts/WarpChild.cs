using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpChild : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        transform.parent.GetComponent<WarpManager>().HandleChildTrigger(transform, other);
    }
    private void OnTriggerExit(Collider other)
    {
        transform.parent.GetComponent<WarpManager>().HandleChildExitTrigger();
    }
}

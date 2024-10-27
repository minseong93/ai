using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WarpManager : MonoBehaviour
{
    private Transform[] myChildren;
    private Vector3 TelePortPos;
    private Collider target;
    private void Start()
    {
        Event warpevent = GameObject.FindWithTag("Event").GetComponent<Event>();
        warpevent.OnWarp += On_WarpEvent;
        myChildren = this.GetComponentsInChildren<Transform>();
    }
    public void HandleChildTrigger(Transform transform, Collider collision)
    {
        foreach(Transform child in myChildren)
        {
            if (child != transform)
            {
                TelePortPos = child.position;
                target = collision;
            }
        }     
    }
    public void HandleChildExitTrigger()
    {
        TelePortPos = Vector3.zero;
        target = null;
    }
    private void On_WarpEvent(object sender, EventArgs e)
    {
        if (target != null)
        {
            target.transform.position = TelePortPos;
        }
    }
}

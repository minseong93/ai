using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    private Data data;

    [SerializeField] float speed;

    private Rigidbody rigidbody;
    private ActionManager actionManager;

    void Start()
    {
        actionManager = new ActionManager();

        Event playerevent = GameObject.FindWithTag("Event").GetComponent<Event>();

        if (playerevent == null)
            Debug.LogError("EventNull");
        else
        {
            playerevent.OnInputMove += On_WalkEvent;
        }


        rigidbody = GetComponent<Rigidbody>();
        if (rigidbody == null)
            Debug.LogError("RigidNull");

        if(speed != 0)
            data = new Data(rigidbody, transform, speed);
    }
    private void On_WalkEvent(object sender, Event.OnInputMoveEventArgs e)
    {
        actionManager.Move(data, e.velocityVec);
    }
    private void OnTriggerEnter(Collider other)
    {
        
    }
}

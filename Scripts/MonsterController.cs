using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;
public class MonsterController : MonoBehaviour
{
    private Transform target;
    private NavMeshAgent navAgent;
    private Event MonsterEvent;
    public event EventHandler OnWarp;
    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        navAgent = GetComponent<NavMeshAgent>();
        MonsterEvent = GameObject.FindWithTag("Event").GetComponent<Event>();
        Event.OnPlayerEvent += OnPlayerEventTriggered;
    }
    // Update is called once per frame
    private void Update()
    {
        if(Vector3.Distance(target.transform.position, transform.position) > 1f)
        transform.position = Vector3.MoveTowards(gameObject.transform.position, target.transform.position, 2f * Time.deltaTime);
    }

    private void PlayerMove(object sender, EventArgs e)
    {
        MonsterEvent.TriggerWarpEvent();
    }
    private void OnPlayerEventTriggered(string eventType)
    {
        if (eventType == "Warp")
        {
            OnWarp += PlayerMove;
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        OnWarp?.Invoke(this, EventArgs.Empty);
        OnWarp -= PlayerMove;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Event : MonoBehaviour
{
    public static event Action<string> OnPlayerEvent;
    public static void TriggerPlayerEvent(string eventType)
    {
        OnPlayerEvent?.Invoke(eventType);
    }

    public event EventHandler<OnInputMoveEventArgs> OnInputMove;
    public event EventHandler OnWarp;
    public class OnInputMoveEventArgs : EventArgs
    {
        public Vector3 velocityVec;
    }

    void Update()
    {
        //캐릭터 이동 이벤트
        float z = Input.GetAxisRaw("Vertical");
        float x = Input.GetAxisRaw("Horizontal");
        if (x != 0 || z != 0)
        {
            OnInputMove?.Invoke(this, new OnInputMoveEventArgs { velocityVec = new Vector3(x, 0, z) });
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            TriggerPlayerEvent("Warp");
            TriggerWarpEvent();
        }
    }
    public void TriggerWarpEvent()
    {
        OnWarp?.Invoke(this, EventArgs.Empty);
    }
}

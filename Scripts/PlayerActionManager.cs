using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionManager : MonoBehaviour
{
    private enum direction
    {
        Up,
        Down,
        Right,
        Left
    };
    public void Move(Data data, Vector3 velocityVec)
    {
        data.rigidbody.velocity = velocityVec.normalized * data.speed;
    }
}

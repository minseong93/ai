using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Data
{
    public Rigidbody rigidbody;
    public Transform transform;
    public float speed;
    public Data(Rigidbody rigidbody_, Transform transform_, float speed_)
    {
        this.rigidbody = rigidbody_;
        this.transform = transform_;
        this.speed = speed_;
    }
}

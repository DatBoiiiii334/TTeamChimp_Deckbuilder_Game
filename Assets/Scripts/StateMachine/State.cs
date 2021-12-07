using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    public FSM myFSM {get; set;}
    public virtual void Enter() { }
    public virtual void Exit() { }
    public virtual void OnUpdate() { }
    public void FixedUpdate() { }
}

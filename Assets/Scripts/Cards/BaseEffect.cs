using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEffect : ScriptableObject{
    public int order;
    public CardTemplate template{ get; set; }
    public abstract void ApplyEffect();
}

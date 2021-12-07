using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDoAction
{
    void doAction();
}

public interface IDamageCard
{
    void doDamage();
}

public interface IDoHealing<T>
{
    void doHealing(T healingDone);
}

public interface ITakeDamage<T>
{
    void takeDamage(T damageTaken);
}
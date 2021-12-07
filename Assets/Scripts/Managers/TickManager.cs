using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TickManager : MonoBehaviour
{
    public static TickManager _tickManager;
    public int forPlayerTicks;
    public int forEnemyTicks;

    public void ApplyTickToPlayer(int tickDmg){
         Player._player.Health -= tickDmg;
         forPlayerTicks -= 1;
         if(forPlayerTicks <= 0){
            forPlayerTicks = 0;
        }
    }

    public void ApplyTickToEnemy(int tickDmg){
        EnemyBody._instanceEnemyBody.Health -= tickDmg;
        forEnemyTicks -= 1;
        if(forEnemyTicks <= 0){
            forEnemyTicks = 0;
        }
    }

    private void Awake()
    {
        if (_tickManager != null)
        {
            Destroy(gameObject);
        }
        _tickManager = this;
    }
}

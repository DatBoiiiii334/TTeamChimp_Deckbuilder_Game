using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestManager : MonoBehaviour
{
    public static TestManager _instance;
    public int PlayerHP, PlayerManaAmount, EnemyHP, EnemyShield, EnemyLastDamageTaken; 

    public void Start() {
        
    }

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        _instance = this;
    }

    
}

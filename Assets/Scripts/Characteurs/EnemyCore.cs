using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[CreateAssetMenu(fileName = "new Enemy", menuName = "Create New Enemy", order = 2)]
public class EnemyCore : ScriptableObject
{
    [SerializeField]
    private string _name;
    [SerializeField]
    private int _maxHealth, _maxShield, _basicAttack, _specialAttack, _maxBuff;
    public GameObject enemyGameObject;
    public Vector3 EnemyPosition;

    //public Animator animController;
    public string Name { get { return _name; } }
    public int maxHealth { get { return _maxHealth; } }
    public int maxShield { get { return _maxShield; } }
    public int maxBuff { get { return _maxBuff; } }
    public int basicAttack { get { return _basicAttack; } }
    public int specialAttack { get { return _specialAttack; } }
}
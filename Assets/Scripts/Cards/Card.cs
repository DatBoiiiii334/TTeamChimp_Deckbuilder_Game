using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Card", menuName = "Create New Card", order = 1)]
public class Card : ScriptableObject
{
    [SerializeField]
    private int ID;
    [SerializeField]
    private string _name, _description;
    [SerializeField]
    public Sprite Image;
    [SerializeField]
    private int _mana, _attackDamage, _tickDamage, _health, _shield;

    public enum cardType { DAMAGE, HEALING, VAMPIRIC, DEFENSE }
    public string Name { get { return _name; } }
    public string Description { get { return _description; } }
    public int Mana { get { return _mana; } }
    public int AttackDamage { get { return _attackDamage; } }
    public int TickDamage { get { return _tickDamage; } }
    public int Health { get { return _health; } }
    public int Shield { get { return _shield; } }

    public List<BaseEffect> Effects = new List<BaseEffect>();
}

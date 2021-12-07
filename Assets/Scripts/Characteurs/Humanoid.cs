using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Humanoid : MonoBehaviour
{
    public int Health, Shield;
    public int maxHealth, maxShield;
    public string Name;
    public TextMeshProUGUI HealthField, ShieldField, NameField;
}

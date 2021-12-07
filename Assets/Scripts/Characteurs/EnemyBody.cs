using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyBody : MonoBehaviour
{
    public static EnemyBody _instanceEnemyBody;
    public EnemyCore _core;
    public TextMeshProUGUI nameField, shieldField, NextEnemyAttack, lastDamageDealtToField, hpField, _forEnemyTicks;
    public Slider hpSlider;
    public Animator myAnimator;
    public GameObject BleedIconEnemy;
    public int Health, Shield, lastDamageDealtTo, enemyState, myNextAttack, forEnemyTicks;

    private void Awake()
    {
        if (_instanceEnemyBody != null)
        {
            Destroy(gameObject);
        }
        _instanceEnemyBody = this;

        EnemyTurn();
        GameObject enemyArt;
        enemyArt = Instantiate(_core.enemyGameObject, transform.position, Quaternion.identity, gameObject.transform);
    }

    public void Start()
    {
        //nameField.text = _core.Name;
        Health = _core.maxHealth;
        Shield = _core.maxShield;
        //myAnimator = _core.animController;
        myAnimator = gameObject.GetComponent<Animator>();
        hpSlider.maxValue = _core.maxHealth;
        UpdateEnemyUI();
    }

    public void UpdateEnemyUI()
    {
        if(forEnemyTicks > 0){
            BleedIconEnemy.SetActive(true);
            _forEnemyTicks.text = forEnemyTicks.ToString();
        }
        if(forEnemyTicks <= 0){
            BleedIconEnemy.SetActive(false);
        }
        lastDamageDealtToField.text = lastDamageDealtTo.ToString();
        hpSlider.value = Health;
        hpField.text = Health.ToString() + "/"+ _core.maxHealth;
        shieldField.text = Shield.ToString();
    }

    public void EnemyTurn()
    {
        myNextAttack = Random.Range(0, 4);
        switch (myNextAttack)
        {
            case 0: //Basic attack
                ShowNextAttack("Basic Attack");
                break;

            case 1: //Heal self
                ShowNextAttack("Healing self");
                break;

            case 2: //Special attack
                ShowNextAttack("Special Attack");
                break;

            case 3: // Shield self
                ShowNextAttack("Shield self");
                break;

            case 4: // Shield self
                ShowNextAttack("Feared");
                break;

            default: //Something must went wrong
                Debug.Log("Something went wrong, no case selected");
                break;
        }
    }

    public void ShowNextAttack(string nameAttack)
    {
        NextEnemyAttack.text = nameAttack;
    }

    public void ResetEnemy(){
        Health = _core.maxHealth;
        Shield = _core.maxShield;
        EnemyTurn();
        UpdateEnemyUI();
    }
}
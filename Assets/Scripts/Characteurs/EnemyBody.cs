using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyBody : MonoBehaviour
{
    public static EnemyBody _instanceEnemyBody;
    public EnemyCore _core;
    public TextMeshProUGUI shieldField, NextEnemyAttack, lastDamageDealtToField, hpField, maxHpField, _forEnemyTicks;
    public Slider hpSlider;
    public Animator myAnimator;
    public GameObject BleedIconEnemy;
    public int Health, Shield, lastDamageDealtTo, enemyState, myNextAttack, forEnemyTicks;

    [Header("EnemyIntendSymbol")]
    public Image EnemyIntendImage;
    public GameObject EnemyIntendGameObject;
    public TextMeshProUGUI EnemyIntendAmount;
    public Sprite _enemyIntAttack, _enemyIntHeal, _enemyIntShield, _enemyIntSpecialAttack, _enemyFeared;

    [Header("Change tranform position of enemy")]
    public float enemyYPos;
    private Vector3 newEnemyPos;

    public void Start()
    {
        myAnimator = gameObject.GetComponent<Animator>();

    }

    public void UpdateEnemyValuesBasedOnCore()
    {
        Health = _core.maxHealth;
        hpField.text = Health.ToString();
        maxHpField.text = Health.ToString();
        Shield = _core.maxShield;
        hpSlider.maxValue = _core.maxHealth;
        UpdateEnemyUI();
    }

    public void SpawnEnemy()
    {
        if (transform.childCount > 0)
        {
            foreach (Transform enemy in transform)
            {
                Destroy(enemy.gameObject);
                // print("Enemy art wiped");
            }
        }
        EnemyTurn();
        GameObject enemyArt;
        enemyArt = Instantiate(_core.enemyGameObject, transform.position, Quaternion.identity, gameObject.transform);
        UpdateEnemyValuesBasedOnCore();

        if (_core.name == "Gnomes")
        {
            gameObject.transform.GetChild(0).transform.position = new Vector3(transform.GetChild(0).transform.position.x,1.5f,transform.GetChild(0).transform.position.z);
            print(gameObject.transform.GetChild(0).transform.position);
        }
    }


    public void UpdateEnemyUI()
    {
        if (forEnemyTicks > 0)
        {
            BleedIconEnemy.SetActive(true);
            _forEnemyTicks.text = forEnemyTicks.ToString();
        }
        if (forEnemyTicks <= 0)
        {
            BleedIconEnemy.SetActive(false);
        }
        lastDamageDealtToField.text = lastDamageDealtTo.ToString();
        hpSlider.value = Health;
        hpField.text = Health.ToString();
        // hpField.text = Health.ToString() + "/"+ _core.maxHealth;
        shieldField.text = Shield.ToString();
    }

    public void EnemyTurn()
    {
        EnemyIntendGameObject.SetActive(true);
        myNextAttack = Random.Range(0, 4);
        EnemyIntend(myNextAttack);
    }

    public void EnemyIntend(int _nextAttack)
    {
        switch (_nextAttack)
        {
            case 0: //Basic attack
                ShowNextAttack("Basic Attack");
                EnemyIntendImage.sprite = _enemyIntAttack;
                EnemyIntendAmount.text = _core.basicAttack.ToString();
                break;

            case 1: //Heal self
                ShowNextAttack("Healing self");
                EnemyIntendImage.sprite = _enemyIntHeal;
                EnemyIntendAmount.text = _core.maxBuff.ToString();
                break;

            case 2: //Special attack
                ShowNextAttack("Special Attack");
                EnemyIntendImage.sprite = _enemyIntSpecialAttack;
                EnemyIntendAmount.text = _core.specialAttack.ToString();
                break;

            case 3: // Shield self
                ShowNextAttack("Shield self");
                EnemyIntendImage.sprite = _enemyIntShield;
                EnemyIntendAmount.text = _core.maxBuff.ToString();
                break;

            case 4: // Shield self
                ShowNextAttack("Feared");
                //print("fear is shown");
                EnemyIntendImage.sprite = _enemyFeared;
                EnemyIntendAmount.text = "";
                UpdateEnemyUI();
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

    public void ResetEnemy()
    {
        Health = _core.maxHealth;
        Shield = _core.maxShield;
        forEnemyTicks = 0;
        EnemyTurn();
        UpdateEnemyUI();
    }

    private void Awake()
    {
        if (_instanceEnemyBody != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instanceEnemyBody = this;
        }

    }
}
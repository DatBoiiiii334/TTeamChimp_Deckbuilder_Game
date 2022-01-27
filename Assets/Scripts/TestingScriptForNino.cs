using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Feels Plugin Stuff
using MoreMountains.Feedbacks;
using MoreMountains.FeedbacksForThirdParty;
using MoreMountains.Tools;

namespace FMODUnity
{
    public class TestingScriptForNino : MonoBehaviour
    {
        // HASANS FEEL DING
        public MMFeedbacks myFeedback;

        //public Animator TransitionScreenAnim, ShopAnim;
        public GameObject MusicPanel;
        FSM myFSM;

        // [Header("Delay Amount for Volume")]
        // public float delayValue;

        [Header("Delay value for Buffs")]
        public float DelayAmountForBuffs;

        [Header("Delay value for Attacks")]
        public float DelayAmountForAttacks;

        [Header("Damage value ")]
        public float damageValue;

        [Header("Damage Dealt to player")]
        public float damageValueWhenPlayerGetsHit;

        private void Start()
        {
            myFeedback = GetComponent<MMFeedbacks>();
            myFSM = GetComponent<FSM>();
        }

        void Update()
        {
            // TRIGGERING BUFFS
            // if (Input.GetKeyDown(KeyCode.Alpha1))
            // {
            //     StartCoroutine(DelayWithParticle(AnimationController._instance.PowerUpAttackBelle, FMODUnity.AudioManager._instance.AttackSoundeffect));
            //     AnimationController._instance.PlayParticleList(AnimationController._instance.PowerUpAttackBelle);
            //     FMODUnity.AudioManager._instance.TriggerSoundEffect(FMODUnity.AudioManager._instance.AttackSoundeffect);
            // }
            // if (Input.GetKeyDown(KeyCode.Alpha2))
            // {
            //     StartCoroutine(DelayWithParticle(AnimationController._instance.ShieldParticleBelle, FMODUnity.AudioManager._instance.ShieldSoundeffect));
            //     AnimationController._instance.PlayParticleList(AnimationController._instance.ShieldParticleBelle);
            //     FMODUnity.AudioManager._instance.TriggerSoundEffect(FMODUnity.AudioManager._instance.ShieldSoundeffect);
            // }
            // if (Input.GetKeyDown(KeyCode.Alpha3))
            // {
            //     StartCoroutine(DelayWithParticle(AnimationController._instance.UtilityParticleBelle, FMODUnity.AudioManager._instance.UtilitySoundeffect));
            //     AnimationController._instance.PlayParticleList(AnimationController._instance.UtilityParticleBelle);
            //     FMODUnity.AudioManager._instance.TriggerSoundEffect(FMODUnity.AudioManager._instance.UtilitySoundeffect);
            // }

            // // TRIGGERING ATTACKS
            // if (Input.GetKeyDown(KeyCode.Alpha4))
            // {
            //     FMODUnity.RuntimeManager.StudioSystem.setParameterByName("DamageOutput", damageValue);
            //     StartCoroutine(Delay( FMODUnity.AudioManager._instance.SwipeAttack));
            //     Player._player.transform.GetChild(0).GetComponent<Animator>().SetTrigger("BasicAttack");
            // }
            // if (Input.GetKeyDown(KeyCode.Alpha5))
            // {
            //     FMODUnity.RuntimeManager.StudioSystem.setParameterByName("DamageOutput", damageValue);
            //     StartCoroutine(DelayWithParticle(AnimationController._instance.FireDamageBelle, FMODUnity.AudioManager._instance.BelleAttacks));
            //     Player._player.transform.GetChild(0).GetComponent<Animator>().SetTrigger("BasicAttack");
            // }
            // if (Input.GetKeyDown(KeyCode.Alpha6))
            // {
            //     // HASANS DING
            //     myFeedback.PlayFeedbacks();

            //     // CHRIS DING
            //     FMODUnity.RuntimeManager.StudioSystem.setParameterByName("DamageOutput", damageValue);
            //     StartCoroutine(Delay( FMODUnity.AudioManager._instance.BasicAttacks));
            //     EnemyBody._instanceEnemyBody.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Hit");
            //     Player._player.transform.GetChild(0).GetComponent<Animator>().SetTrigger("BasicAttack");
            // }

            // //TRIGGER PLAYER GETTING HIT 
            // if (Input.GetKeyDown(KeyCode.Alpha7))
            // {
            //     FMODUnity.RuntimeManager.StudioSystem.setParameterByName("DamageReveiced", damageValueWhenPlayerGetsHit);
            //     //StartCoroutine(Delay(AnimationController._instance.FireDamageBelle, FMODUnity.AudioManager._instance.BasicAttacks));
            //     EnemyBody._instanceEnemyBody.transform.GetChild(0).GetComponent<Animator>().SetTrigger("BasicAttack");
            // }


            // if (Input.GetKeyDown(KeyCode.N))
            // {
            //     GridMapState._instance.ChangeEnemy();
            //     //MainMenuState._instance.MainMenu.SetActive(false);
            //     print("Command go Directly to FightScene");
            // }

            // if (Input.GetKeyDown(KeyCode.M))
            // {
            //     //Show Music Panel
            //     MusicPanel.gameObject.SetActive(true);
            // }
        }

        public IEnumerator DelayWithParticle(List<ParticleSystem> myParticlelist, FMODUnity.EventReference SoundEffect)
        {
            AnimationController._instance.PlayParticleList(myParticlelist);
            yield return new WaitForSeconds(DelayAmountForBuffs);
            FMODUnity.AudioManager._instance.TriggerSoundEffect(SoundEffect);
        }

        public IEnumerator Delay(FMODUnity.EventReference SoundEffect)
        {
            yield return new WaitForSeconds(DelayAmountForAttacks);
            FMODUnity.AudioManager._instance.TriggerSoundEffect(SoundEffect);
        }

        public void ClosePanel()
        {
            MusicPanel.gameObject.SetActive(false);
        }
    }
}
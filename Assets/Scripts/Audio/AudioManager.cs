using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FMODUnity
{
    [AddComponentMenu("FMOD Studio/FMOD Studio Event Emitter")]
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager _instance;
        public EventReference[] BuffSounds;

        public EventReference[] BelleAttackSounds;

        public EventReference[] CardHoverSounds;

        public EventReference[] EndTurnSounds;

        public EventReference MainTheme;

        private FMOD.Studio.EventInstance FMOD_instance;
        [ParamRef]
        public string parameter;
        public float paramValue;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                //ChangeMainTheme(paramValue);
            }

            if (Input.GetKeyDown(KeyCode.Z) && Input.GetKeyDown(KeyCode.Alpha1))
            {
                TriggerBelleAttackSounds(0);
                print("Audio 1");
            }
            // if (Input.GetKeyDown(KeyCode.Z) && Input.GetKeyDown(KeyCode.Alpha2))
            // {
            //     TriggerBelleAttackSounds(1);
            //     print("Audio 2");
            // }
            // if (Input.GetKeyDown(KeyCode.Z) && Input.GetKeyDown(KeyCode.Alpha3))
            // {
            //     TriggerCardHoverSounds(0);
            //     print("Audio 3");
            // }
            // if (Input.GetKeyDown(KeyCode.Z) && Input.GetKeyDown(KeyCode.Alpha4))
            // {
            //     TriggerCardHoverSounds(1);
            //     print("Audio 4");
            // }
        }

        public void TriggerBelleAttackSounds(int num)
        {
            FMOD_instance = FMODUnity.RuntimeManager.CreateInstance(BelleAttackSounds[num]);
            FMOD_instance.start();
            FMOD_instance.release();
        }

        public void TriggerBuffSounds(int num)
        {
            FMOD_instance = FMODUnity.RuntimeManager.CreateInstance(BuffSounds[num]);
            FMOD_instance.start();
            FMOD_instance.release();
        }

        public void TriggerCardHoverSounds(int num)
        {
            FMOD_instance = FMODUnity.RuntimeManager.CreateInstance(CardHoverSounds[num]);
            FMOD_instance.start();
            FMOD_instance.release();
        }

        public void ChangeMainTheme(float param)
        {
            FMOD.Studio.EventInstance instance = FMODUnity.RuntimeManager.CreateInstance(MainTheme);

            //Hiermee kan je de sound koppelen aan een rigid body of iets anders
            //FMODUnity.RuntimeManager.AttachInstanceToGameObject(instance, GetComponent<Transform>(), GetComponent<Rigidbody>());

            RuntimeManager.StudioSystem.setParameterByName(parameter, param);
            instance.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
            instance.start();
            //instance.release();
        }

        private void Awake()
        {
            if (_instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                _instance = this;
            }
        }
    }
}
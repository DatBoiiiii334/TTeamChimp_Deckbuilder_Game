using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FMODUnity
{
    [AddComponentMenu("FMOD Studio/FMOD Studio Event Emitter")]
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager _instance;


        public EventReference MainTheme;

        private FMOD.Studio.EventInstance FMOD_instance;
        [ParamRef]
        public string parameter;
        public float paramValue;

        [Header("Sliders")]
        public Slider MusicVolumeSlider, SfxVolumeSlider, UiVolumeSlider, AmbienceVolumeSlider;
        private float MusicVolumeValue, SfxVolumeValue, UiVolumeValue, AmbienceVolumeValue;

        private void Start() {
            RuntimeManager.StudioSystem.setParameterByName("SfxVolume", 0.8f);
            RuntimeManager.StudioSystem.setParameterByName("MusicVolume", 0.8f);
            RuntimeManager.StudioSystem.setParameterByName("UiVolume", 0.8f);
            RuntimeManager.StudioSystem.setParameterByName("AmbienceVolume", 0.8f);
        }        

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                ChangeMainTheme(0);
            }

            if (Input.GetKeyDown(KeyCode.X))
            {
                RuntimeManager.StudioSystem.setParameterByName(parameter, 1);
            }

            if (Input.GetKeyDown(KeyCode.C))
            {
                RuntimeManager.StudioSystem.setParameterByName(parameter, 2);
            }

            ChangeAudioVolume();
        }

        public void ChangeAudioVolume(){
            MusicVolumeValue = MusicVolumeSlider.value;
            RuntimeManager.StudioSystem.setParameterByName("MusicVolume", MusicVolumeValue);

            SfxVolumeValue = SfxVolumeSlider.value;
            RuntimeManager.StudioSystem.setParameterByName("SfxVolume", SfxVolumeValue);

            UiVolumeValue = UiVolumeSlider.value;
            RuntimeManager.StudioSystem.setParameterByName("UiVolume", UiVolumeValue);

            AmbienceVolumeValue = AmbienceVolumeSlider.value;
            RuntimeManager.StudioSystem.setParameterByName("AmbienceVolume", AmbienceVolumeValue);
        }

        // public void TriggerBelleAttackSounds(int num)
        // {
        //     //FMOD_instance = FMODUnity.RuntimeManager.CreateInstance(BelleAttackSounds[num]);
        //     FMOD_instance.start();
        //     FMOD_instance.release();
        // }


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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FMODUnity
{
   // [AddComponentMenu("FMOD Studio/FMOD Studio Event Emitter")]
    public class AudioManager : MonoBehaviour
    {
        // void Load();
        // bool PreloadSamples;
        public static AudioManager _instance;

        [Header("SoundEffects Characteurs")]
        public EventReference BelleAttacks;
        public EventReference BasicAttacks;
        public EventReference Heal;
        //public EventReference PaperHitSound;
        public EventReference RedHoodAttack;
        public EventReference Shield;
        public EventReference SwipeAttack;

        [Header("SoundEffects for Cards")]
        public EventReference CardClick;
        public EventReference CardHover;
        public EventReference CardClickAndDrag;

        [Header("EndTurn Button")]
        public EventReference EndTurnClick;
        public EventReference EndTurnHover;

        [Header("GenerisUIClick")]
        public EventReference GenericUISound;

        [Header("Summon Button")]
        public EventReference SummonClick;
        public EventReference SummonHover;

        [Header("Buff SoundEffects")]
        public EventReference AttackSoundeffect;
        public EventReference HealSoundeffect;
        public EventReference ShieldSoundeffect;
        public EventReference UtilitySoundeffect;


        [Space]
        [Header("MusicVolume Main Theme")]
        public EventReference MainTheme;

        [Header("Paramater for Music Volume")]
        [ParamRef]
        public string parameter;
        public float paramValue;

        [Header("Sliders")]
        public Slider MusicVolumeSlider;
        public Slider SfxVolumeSlider, UiVolumeSlider, AmbienceVolumeSlider;
        private float MusicVolumeValue, SfxVolumeValue, UiVolumeValue, AmbienceVolumeValue;
        private FMOD.Studio.EventInstance FMOD_instance;

        [Header("SoundsMenu")]
        public GameObject SoundsMenu;

         [Header("Book Opening sound")]
         public EventReference BookOpening;

        public enum Themes {StartScreen, MapScreen, FightScreen, WinScreen, LoseScreen};

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
                //ChangeMainTheme(0);
                StartMainTheme();
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

        public void ChangeThemeSong(int paramValue){
            RuntimeManager.StudioSystem.setParameterByName(parameter, paramValue);
        }

        // public void ChangeThemeSong(){
        //     var Theme = Themes.FightScreen;
        //     switch(Theme){

        //         case Themes.StartScreen:
        //         RuntimeManager.StudioSystem.setParameterByName(parameter, paramValue);
        //         break;

        //         case Themes.MapScreen:
        //         RuntimeManager.StudioSystem.setParameterByName(parameter, paramValue);
        //         break;

        //         case Themes.FightScreen:
        //         RuntimeManager.StudioSystem.setParameterByName(parameter, paramValue);
        //         break;
        //     }
        // }

        public void ShowSoundOptionsMenu(){
            SoundsMenu.SetActive(true);
            //ChangeMainTheme(0);
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

        public void TriggerSoundEffect(EventReference Sound)
        {
            FMOD_instance = FMODUnity.RuntimeManager.CreateInstance(Sound);
            FMOD_instance.start();
            FMOD_instance.release();
        }


        public void StartMainTheme()
        {
            FMOD.Studio.EventInstance instance = FMODUnity.RuntimeManager.CreateInstance(MainTheme);

            //Hiermee kan je de sound koppelen aan een rigid body of iets anders
            //FMODUnity.RuntimeManager.AttachInstanceToGameObject(instance, GetComponent<Transform>(), GetComponent<Rigidbody>());

            RuntimeManager.StudioSystem.setParameterByName(parameter, paramValue);
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
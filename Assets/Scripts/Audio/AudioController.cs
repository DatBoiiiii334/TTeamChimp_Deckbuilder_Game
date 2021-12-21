using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FMODUnity
{
    [AddComponentMenu("FMOD Studio/FMOD Studio Event Emitter")]
    public class AudioController : MonoBehaviour
    {
        public static AudioController _instance;
        public EventReference EventReference;
        private FMOD.Studio.EventInstance FMOD_instance;

        public void TriggerAudioEffect()
        {
            FMOD_instance = FMODUnity.RuntimeManager.CreateInstance(EventReference);
            FMOD_instance.start();
            FMOD_instance.release();
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

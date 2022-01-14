using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FMODUnity
{
    [AddComponentMenu("FMOD Studio/FMOD Studio Event Emitter")]
    public class AudioManager : MonoBehaviour
    {
        public EventReference EventReference;
        private FMOD.Studio.EventInstance FMOD_instance;

        private void Update() {
            if(Input.GetKeyDown(KeyCode.Z)){
                TriggerAudioEffect();
            }
        }

        public void TriggerAudioEffect()
        {
            FMOD_instance = FMODUnity.RuntimeManager.CreateInstance(EventReference);
            FMOD_instance.start();
            FMOD_instance.release();
        }
    }
}
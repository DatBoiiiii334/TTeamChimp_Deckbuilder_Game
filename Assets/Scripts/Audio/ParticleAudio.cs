using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FMODUnity
{
    [AddComponentMenu("FMOD Studio/FMOD Studio Event Emitter")]
    public class ParticleAudio : MonoBehaviour
    {
        private bool CanPlayAudio = true;
        private ParticleSystem ParticleSystem;
        public EventReference EventReference;
        private FMOD.Studio.EventInstance instance;


        private void Awake()
        {
            ParticleSystem = GetComponent<ParticleSystem>();

        }

        private void Update()
        {
            if (ParticleSystem.isPlaying)
            {
                if (CanPlayAudio)
                {
                    CanPlayAudio = false;
                    instance = FMODUnity.RuntimeManager.CreateInstance(EventReference);
                    instance.start();
                    instance.release();

                }
            }
            else
            {
                CanPlayAudio = true;
                
            }
        }
    }
}
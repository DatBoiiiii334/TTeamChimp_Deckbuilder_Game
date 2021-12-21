using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FMODUnity
{
    public class AudioExample : MonoBehaviour
    {
        public EventReference EventReference;
        [ParamRef]
        public string parameter;
        public float paramValue;

 

        private FMOD.Studio.EventInstance instance;



        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {

                FMOD.Studio.EventInstance instance = FMODUnity.RuntimeManager.CreateInstance(EventReference);

                //Hiermee kan je de sound koppelen aan een rigid body of iets anders
                //FMODUnity.RuntimeManager.AttachInstanceToGameObject(instance, GetComponent<Transform>(), GetComponent<Rigidbody>());
                
                RuntimeManager.StudioSystem.setParameterByName(parameter, paramValue);
                instance.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
                instance.start();
                instance.release();
            }
        }
    }
}
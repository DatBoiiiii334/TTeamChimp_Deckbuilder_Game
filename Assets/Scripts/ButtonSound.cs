using UnityEngine;
using UnityEngine.EventSystems;

namespace FMODUnity
{
    public class ButtonSound : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
    {
        public EventReference onEnterSound, onClickSound;

        public void OnPointerEnter(PointerEventData eventData)
        {
            FMODUnity.AudioManager._instance.TriggerSoundEffect(onEnterSound);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            FMODUnity.AudioManager._instance.TriggerSoundEffect(onClickSound);
        }
    }
}

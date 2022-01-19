using UnityEngine;
using UnityEngine.EventSystems;

namespace FMODUnity
{
    public class TriggerButtonSound : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
    {
        [Header("Sound Effects")]
        public EventReference onHoverSound, onClickSound;

        public void OnPointerClick(PointerEventData eventData)
        {
            AudioManager._instance.TriggerSoundEffect(onClickSound);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            AudioManager._instance.TriggerSoundEffect(onHoverSound);
        }
    }
}

using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager _instanceUI;
    public GameObject UIBanner;
    public TextMeshProUGUI Title, undertitle;
    public Animator BannerAnimator;

    private void Awake()
    {
        if (_instanceUI != null)
        {
            Destroy(gameObject);
        }
        _instanceUI = this;
        //BannerAnimator = GetComponent<Animator>();
    }
}

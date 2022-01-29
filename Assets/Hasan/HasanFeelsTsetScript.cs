using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Feels Plugin Stuff
using MoreMountains.Feedbacks;
using MoreMountains.FeedbacksForThirdParty;
using MoreMountains.Tools;


public class HasanFeelsTsetScript : MonoBehaviour
{
    // HASANS FEEL DING
    public MMFeedbacks enemyFeedback;
    public MMFeedbacks heroFeedback;

    // Start is called before the first frame update
    void Start()
    {
        enemyFeedback = GetComponent<MMFeedbacks>();
        heroFeedback = GetComponent<MMFeedbacks>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            // HASANS DING
            enemyFeedback.PlayFeedbacks();
            heroFeedback.PlayFeedbacks();
        }
    }
}

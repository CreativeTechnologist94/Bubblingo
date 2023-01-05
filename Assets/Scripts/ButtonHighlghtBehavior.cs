using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.UI;
public class ButtonHighlghtBehavior : Button
{
    private MMFeedbacks _graphicScaleFeedbacks;
    protected override void Start()
    {
        _graphicScaleFeedbacks = GetComponent<MMFeedbacks>();
    }
    private void Update()
    {
        if (IsHighlighted() == true)
        {
            //Debug.Log("Selectable is Highlighted");
            _graphicScaleFeedbacks?.PlayFeedbacks();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using UnityEngine;

public class TitleAnimation : MonoBehaviour
{
    [SerializeField] private MMFeedbacks _titleAnimationFeedback;
    public float delay;
    
    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(animateTitle), delay);
    }

    private void animateTitle()
    {
       _titleAnimationFeedback?.PlayFeedbacks();
    }
}

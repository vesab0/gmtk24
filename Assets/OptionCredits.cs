using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionCredits : MonoBehaviour
{
   private Animator animator;

    public string animationStateName;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (IsAnimationFinished(animationStateName))
        {
            SceneManager.LoadScene(0);
        }
    }

    bool IsAnimationFinished(string stateName)
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        
        return stateInfo.IsName(stateName) && stateInfo.normalizedTime >= 1.0f && !animator.IsInTransition(0);
    }
}

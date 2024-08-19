using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCredits : MonoBehaviour
{
    private Animator animator;
    public GameObject DoYouWantToQuit;
    public string animationStateName;
    private bool hasToggled = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
       Checker();
    }

    bool IsAnimationFinished(string stateName)
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        
        return stateInfo.IsName(stateName) && stateInfo.normalizedTime >= 1.0f && !animator.IsInTransition(0);
    }

    public void QuitEnd(){
        Application.Quit();
    }

    public void Checker(){
         if (IsAnimationFinished(animationStateName) && !hasToggled )
        {
            bool isActive = DoYouWantToQuit.activeSelf;
            DoYouWantToQuit.SetActive(!isActive);
            hasToggled = true;
        }
    }
}

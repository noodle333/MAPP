using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTransition : MonoBehaviour
{
    public Animator transition;
    
    void Start()
    {
        //TransitionIn();
        transition.Play("Transition in");
    }

    private void Update()
    {
        
    }
    /*
    public IEnumerator TransitionIn()
    {
        transition.Play("Transition in");
        yield return new WaitForSeconds(1);
        transition.Play("Stationary");
    }

    public IEnumerator TransitionOut()
    {
        transition.Play("Transition out");
        return null;
    }
    */
}

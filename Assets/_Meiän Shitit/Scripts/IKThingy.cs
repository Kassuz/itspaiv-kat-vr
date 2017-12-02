using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKThingy : MonoBehaviour {

    Animator animator;

    public Vector3 ikPosition;
    public Vector3 ikLookPosition;
    public Transform pressanKasi;
    public bool kattely;
    float kattelyWeight;


    void Awake()
    {
        animator = GetComponent<Animator>();    
    }

    void OnEnable()
    {
        kattelyWeight = 0f;    
    }

    void OnAnimatorIK()
    {
        animator.SetIKPosition(AvatarIKGoal.RightHand, pressanKasi.position);

        if (kattely)
        {
            if (kattelyWeight < 1) kattelyWeight += Time.deltaTime / 2;
            Debug.Log(kattelyWeight);
            animator.SetIKPositionWeight(AvatarIKGoal.RightHand, kattelyWeight);
            animator.SetLookAtWeight(kattelyWeight);
            animator.SetLookAtPosition(pressanKasi.position);
        }
        
    }

    

}

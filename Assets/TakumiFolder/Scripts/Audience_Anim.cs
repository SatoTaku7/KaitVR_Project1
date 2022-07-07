using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audience_Anim : MonoBehaviour
{
    private Animator Audience_anim;
    public Degree_excite degree_Excite;
    private enum Animationnum
    {
        Idle = 10,
        Jump = 20,
        Lying=30
    }
    void Start()
    {
        Audience_anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        //Audience_anim.SetInteger("Animationnum", (int)Animationnum.Lying);
        //if (degree_Excite.excitement < 20)
        //    Audience_anim.SetInteger("Animationnum", (int)Animationnum.Lying);
       
        //else if (20<=degree_Excite.excitement&& degree_Excite.excitement < 60)
        //    Audience_anim.SetInteger("Animationnum", (int)Animationnum.Idle);
        
        //else Audience_anim.SetInteger("Animationnum", (int)Animationnum.Jump);

        if(Input.GetKeyDown(KeyCode.X)) Audience_anim.SetInteger("Animationnum", (int)Animationnum.Jump);

       // Debug.Log(degree_Excite.excitement);
    }
}

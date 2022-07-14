using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audience_Anim : MonoBehaviour
{
    private Animator Audience_anim;
    public Degree_excite degree_Excite;
    [SerializeField] GameObject Player;
    private enum Animationnum
    {
        Idle = 10,
        Jump = 20,
        Lying=30
    }
    void Start()
    {
        Audience_anim = gameObject.GetComponent<Animator>();
        transform.LookAt(Player.transform);
    }

    void Update()
    {
        Audience_anim.SetInteger("Animationnum", (int)Animationnum.Lying);
        if (degree_Excite.excitement < 30)
            Audience_anim.SetInteger("Animationnum", (int)Animationnum.Lying);

        if (30 <= degree_Excite.excitement && degree_Excite.excitement < 80)
            Audience_anim.SetInteger("Animationnum", (int)Animationnum.Idle);

        if (degree_Excite.excitement >= 80)
            Audience_anim.SetInteger("Animationnum", (int)Animationnum.Jump);
         
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audience_Anim : MonoBehaviour
{
    private Animator Audience_anim;
    public Degree_excite degree_Excite;
    [SerializeField] GameObject Player;
    private float rnd_time;
    private float jump_time;

    //一時的にやめた機能　時間あれば直して追加
    [SerializeField] GameObject [] Audience=new GameObject[10];
    [SerializeField] GameObject[] Audience_type = new GameObject[10];
    GameObject[] chara = new GameObject[100];
    private int Audience_num;
    private float rnd_jump;//盛り上がり度80超えの時にランダムな確率で観衆がジャンプする
    private Rigidbody rb;
    private BoxCollider boxCollider;
    private float Rnd_posX, Rnd_posZ;//観衆をランダムな位置に生成
    private int Rnd_char;//0～9のランダムなキャラクターを生成
    private enum Animationnum
    {
        Idle = 10,
        Jump = 20,
        Lying=30
    }
    void Start()
    {
        jump_time = 0;
        Audience_anim = gameObject.GetComponent<Animator>();
        gameObject.AddComponent<Rigidbody>();
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        gameObject.AddComponent<BoxCollider>();
        boxCollider = GetComponent<BoxCollider>();
        boxCollider.size = new Vector3(0.5f, 0.1f, 0.5f);
        transform.LookAt(Player.transform);
        Audience_num = 0;
        
        


    }

    void Update()
    {

        //while (Audience_num < 100)
        //{
        //    Rnd_posX = Random.Range(-13f, 10f);
        //    Rnd_posZ = Random.Range(-10f, 10f);
        //    Rnd_char = Random.Range(0, 9);
        //    chara[Audience_num] =Instantiate(Audience_type[Rnd_char], new Vector3(Rnd_posX, 0.5f, Rnd_posZ), Quaternion.identity);
        //    Debug.Log(Audience_num);
        //    chara[Audience_num].tag = "Audience";
        //    chara[Audience_num].transform.LookAt(Player.transform);
        //    chara[Audience_num].AddComponent<Rigidbody>();
        //    chara[Audience_num].AddComponent<BoxCollider>();
        //    boxCollider = chara[Audience_num].GetComponent<BoxCollider>();
        //    boxCollider.size = new Vector3(0.5f, 0.1f,0.5f);
        //    Audience_anim = chara[Audience_num].GetComponent<Animator>();
        //    Audience_num++;  
        //}
        jump_time += Time.deltaTime;


        if (degree_Excite.excitement < 30)
            Audience_anim.SetInteger("Animationnum", (int)Animationnum.Idle);

        if (30 <= degree_Excite.excitement && degree_Excite.excitement < 80)
        {
            rnd_time = Random.Range(0f, 2f);
            Invoke("Audience_Idle", rnd_time);
        }

        if (degree_Excite.excitement >= 80)
        {
            rnd_time = Random.Range(0f, 1f);
            Invoke("Audience_jump", rnd_time);
        }  
    }

    void Audience_Idle()
    {
        Audience_anim.SetInteger("Animationnum", (int)Animationnum.Idle);
        if (jump_time > 1)
        {
            //Debug.Log(jump_time);
            rb.AddForce(new Vector3(0, 2f, 0), ForceMode.Impulse);
            jump_time = 0;
        }
    }


    void Audience_jump()
    {
        Audience_anim.SetInteger("Animationnum", (int)Animationnum.Jump);
        //transform.LookAt(Player.transform);
        if (jump_time > 1)
        {
            //Debug.Log(jump_time);
            rb.AddForce(new Vector3(0, 3f, 0), ForceMode.Impulse);
            jump_time = 0;
        }
        
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PlaySceneManager : MonoBehaviour //チュートリアルでのA,Dを押させる指示・成功時の観客の歓声・VoliumeControlでのバーの調整を反映・
{
    [SerializeField] TextMeshProUGUI text_A;
    [SerializeField] TextMeshProUGUI text_D;
    [SerializeField] Slider volume_slider;
    [SerializeField] AudioSource DJ_music;//プレイヤーの操作する音楽
    [SerializeField] AudioSource AudienceCheers;//成功時の観客の歓声
    public bool finish_tutorial;
    public Degree_excite degree_Excite;//基準数値を呼び出す用
    private float count;
    public bool AorD;//チュートリアルでAを指しているかDを指しているかどうか
    void Start()
    {
        text_A.color = Color.red;//本当はカメラ・ライトの演出が入ってからテキストAが赤くなる　今回は最初からA
        finish_tutorial = false;
        count = 0;
        AorD = true;
    }

    void Update()
    {
        //Debug.Log(degree_Excite.clear_criteria);
        if (text_A.color == Color.red)
        {
            AorD = true;
            degree_Excite.clear_criteria = 0;
            if (volume_slider.value == 0)//スライダーが一番左まで来るかつAが赤→テキストAが白に戻り、テキストDが赤になる　　歓声も入れておく？
            {
                text_A.color = Color.white;
                text_D.color = Color.red;
                AudienceCheers.Play();
            }
        }
        if (text_D.color == Color.red)
        {
            AorD = false;
            degree_Excite.clear_criteria = 100;
            if ((volume_slider.value == 100))//スライダーが一番右まで来るかつDが赤→テキストDが白に戻り 歓声でスタート
            {
                text_D.color = Color.white;
                AudienceCheers.Play();
                GameStart();
                
            }
        }
        

    }
    void GameStart()//ゲーム開始時に呼び出される
    {
        Debug.Log("開始！");
        DJ_music.Play();
        finish_tutorial = true;
        
    }
}

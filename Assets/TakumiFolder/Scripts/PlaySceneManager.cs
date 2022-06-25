using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlaySceneManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text_A;
    [SerializeField] TextMeshProUGUI text_D;
    [SerializeField] Slider volume_slider;
    void Start()
    {
        text_A.color = Color.red;//本当はカメラ・ライトの演出が入ってからテキストAが赤くなる　今回は最初からA
    }

    void Update()
    {
        if ((volume_slider.value == 0) && (text_A.color == Color.red))//スライダーが一番左まで来るかつAが赤→テキストAが白に戻り、テキストDが赤になる　　歓声も入れておく？
        {
            text_A.color = Color.white;
            text_D.color = Color.red;
        }
        if ((volume_slider.value == 100) && (text_D.color == Color.red))//スライダーが一番右まで来るかつDが赤→テキストDが白に戻り 歓声でスタート
        {
            text_D.color = Color.white;
            GameStart();
        }
        

    }
    void GameStart()
    {
        Debug.Log("開始！");
    }
}

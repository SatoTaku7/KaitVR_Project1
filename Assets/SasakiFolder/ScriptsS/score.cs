using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    private GameObject ScoreMaster;
    private scoreData Sd;
    public Text tx;
    int Score;

    // Start is called before the first frame update
    void Start()
    {
        ScoreMaster = GameObject.Find("ScoreData");  //ScoreData（ゲームオブジェクト）を見つける
        Sd = ScoreMaster.GetComponent<scoreData>();  //スクリプトのscoreDateをGetComponentする

        Score = Sd.GetScore();  //ScoreDataの中のGetScore関数を呼び出す
        //アタッチしたオブジェクトに反映したいテキストを紐づける。
        tx.text = string.Format("スコア {0}", Score);
    }

}

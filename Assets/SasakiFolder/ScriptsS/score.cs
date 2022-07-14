using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    private GameObject ScoreMaster;
    private ScoreData Sd;
    public Text tx;
    int Score;

    // Start is called before the first frame update
    void Start()
    {
        ScoreMaster = GameObject.Find("ScoreData");  //ScoreDataを見つける
        Sd = ScoreMaster.GetComponent<ScoreData>();

        Score = Sd.GetScore();  //ScoreDataの中のGetScore関数を呼び出す
        //アタッチしたオブジェクトに反映したいテキストを紐づける。
        tx.text = string.Format("Score  {0}", Score);
    }

}

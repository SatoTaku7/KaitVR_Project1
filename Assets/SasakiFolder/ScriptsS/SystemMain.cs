using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SystemMain : MonoBehaviour
{
    public int Score;
    public Text ScoreText;
    public scoreData Sd;

    void Start()
    {
        Score = 0;
        //ScoreDataを見つける。(前シーンでDontDestroyOnLoadの記述をしたため、GameMainでも保持していられる)
        Sd = GameObject.Find("ScoreData").GetComponent<scoreData>();
    }

    // Update is called once per frame
    void Update()
    {
        Sd.Score = Score;  //ScoreDataの中のScore
        ScoreText.text = string.Format("スコア：{0}", Score);  //GameMainシーンでのスコア表示
        Score += 1;
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SystemMain : MonoBehaviour
{
    public int Score;
    public Text ScoreText;
    public ScoreData Sd;

    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
        //ScoreDataを見つける。(前シーンでDontDestroyOnLoadの記述をしたため、GameMainでも保持していられる)
        Sd = GameObject.Find("ScoreData").GetComponent<ScoreData>();
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = string.Format("{0}", Score);  //GameMainシーンでのスコア表示
        Sd.Score = Score;  //ScoreDataの中のScore
    }
}

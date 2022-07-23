using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreData : MonoBehaviour
{
    public int Score;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);  //DontDestroyOnLoadでシーン遷移後も保存出来る
        Score = 0;  //ゲームスタート時のスコア
    }

    public int GetScore()
    {
        return Score;  //スコア変数をResultスクリプトへ返す
    }
}

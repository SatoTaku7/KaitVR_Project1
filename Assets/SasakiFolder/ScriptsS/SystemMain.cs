using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SystemMain : MonoBehaviour
{
    public int Score;
    public Text ScoreText;
    public ScoreData Sd;

    void Start()
    {
        Score = 1;
        //ScoreData��������B(�O�V�[����DontDestroyOnLoad�̋L�q���������߁AGameMain�ł��ێ����Ă�����)
        Sd = GameObject.Find("ScoreData").GetComponent<ScoreData>();
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = string.Format("{0}", Score);  //GameMain�V�[���ł̃X�R�A�\��
        Sd.Score = Score;  //ScoreData�̒���Score
    }
}

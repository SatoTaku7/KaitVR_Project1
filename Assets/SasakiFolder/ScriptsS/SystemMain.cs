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
        //ScoreData��������B(�O�V�[����DontDestroyOnLoad�̋L�q���������߁AGameMain�ł��ێ����Ă�����)
        Sd = GameObject.Find("ScoreData").GetComponent<scoreData>();
    }

    // Update is called once per frame
    void Update()
    {
        Sd.Score = Score;  //ScoreData�̒���Score
        ScoreText.text = string.Format("�X�R�A�F{0}", Score);  //GameMain�V�[���ł̃X�R�A�\��
        Score += 1;
        
    }
}

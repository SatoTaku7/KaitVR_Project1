using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreData : MonoBehaviour
{
    public int Score;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);  //DontDestroyOnLoad�ŃV�[���J�ڌ���ۑ��o����
        Score = 0;  //�Q�[���X�^�[�g���̃X�R�A
    }

    public int GetScore()
    {
        return Score;  //�X�R�A�ϐ���Result�X�N���v�g�֕Ԃ�
    }
}
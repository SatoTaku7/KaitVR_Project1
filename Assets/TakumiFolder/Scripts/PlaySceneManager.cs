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
        text_A.color = Color.red;//�{���̓J�����E���C�g�̉��o�������Ă���e�L�X�gA���Ԃ��Ȃ�@����͍ŏ�����A
    }

    void Update()
    {
        if ((volume_slider.value == 0) && (text_A.color == Color.red))//�X���C�_�[����ԍ��܂ŗ��邩��A���ԁ��e�L�X�gA�����ɖ߂�A�e�L�X�gD���ԂɂȂ�@�@����������Ă����H
        {
            text_A.color = Color.white;
            text_D.color = Color.red;
        }
        if ((volume_slider.value == 100) && (text_D.color == Color.red))//�X���C�_�[����ԉE�܂ŗ��邩��D���ԁ��e�L�X�gD�����ɖ߂� �����ŃX�^�[�g
        {
            text_D.color = Color.white;
            GameStart();
        }
        

    }
    void GameStart()
    {
        Debug.Log("�J�n�I");
    }
}

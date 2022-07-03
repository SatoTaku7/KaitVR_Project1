using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PlaySceneManager : MonoBehaviour //�`���[�g���A���ł�A,D����������w���E�������̊ϋq�̊����EVoliumeControl�ł̃o�[�̒����𔽉f�E
{
    [SerializeField] TextMeshProUGUI text_A;
    [SerializeField] TextMeshProUGUI text_D;
    [SerializeField] Slider volume_slider;
    [SerializeField] AudioSource DJ_music;//�v���C���[�̑��삷�鉹�y
    [SerializeField] AudioSource AudienceCheers;//�������̊ϋq�̊���
    public bool finish_tutorial;
    public Degree_excite degree_Excite;//����l���Ăяo���p
    private float count;
    public bool AorD;//�`���[�g���A����A���w���Ă��邩D���w���Ă��邩�ǂ���
    void Start()
    {
        text_A.color = Color.red;//�{���̓J�����E���C�g�̉��o�������Ă���e�L�X�gA���Ԃ��Ȃ�@����͍ŏ�����A
        finish_tutorial = false;
        count = 0;
        AorD = true;
    }

    void Update()
    {
        //Debug.Log(degree_Excite.clear_criteria);
        if (text_A.color == Color.red)
        {
            AorD = true;
            degree_Excite.clear_criteria = 0;
            if (volume_slider.value == 0)//�X���C�_�[����ԍ��܂ŗ��邩��A���ԁ��e�L�X�gA�����ɖ߂�A�e�L�X�gD���ԂɂȂ�@�@����������Ă����H
            {
                text_A.color = Color.white;
                text_D.color = Color.red;
                AudienceCheers.Play();
            }
        }
        if (text_D.color == Color.red)
        {
            AorD = false;
            degree_Excite.clear_criteria = 100;
            if ((volume_slider.value == 100))//�X���C�_�[����ԉE�܂ŗ��邩��D���ԁ��e�L�X�gD�����ɖ߂� �����ŃX�^�[�g
            {
                text_D.color = Color.white;
                AudienceCheers.Play();
                GameStart();
                
            }
        }
        

    }
    void GameStart()//�Q�[���J�n���ɌĂяo�����
    {
        Debug.Log("�J�n�I");
        DJ_music.Play();
        finish_tutorial = true;
        
    }
}

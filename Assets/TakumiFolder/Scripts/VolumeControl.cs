using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour  //AD�ŉ��̉��ʃo�[�𒲐߂����A���ʂɔ��f�����܂�
{
    private Animator Player_anim;
    Slider volume_slider;
    [SerializeField] GameObject Player_DJ;
    [SerializeField]  AudioSource DJ_music;//Music�I�u�W�F�N�g��AudioSource�R���|�[�l���g�擾
    [SerializeField] float slider_speed = 40f;//�X���C�_�[�̈ړ��X�s�[�h
    
    private enum Animationnum
    {
        Idle=0,
        Adjust=1
    }

    void Start()
    {
        volume_slider = GetComponent<Slider>();
        volume_slider.maxValue = 100;//volume_slider�̍ő�
        volume_slider.minValue = 0;//volume_slider�̍ŏ��l
        volume_slider.value = 50;//�����l
        Player_anim = Player_DJ.GetComponent<Animator>();
    }

    
    void Update()
    {

        //DJ_music.volume = volume_slider.value / 100;//���ʂ�0�`1�Ȃ̂�volume_slider�̒l100����1�ɑΉ�������
        if (Input.GetKey(KeyCode.A))//A�������Ă���Ԃ̓{�����[����������
        {
            volume_slider.value -= slider_speed * Time.deltaTime;
            Player_anim.SetInteger("Animationnum", (int)Animationnum.Adjust);
        }
        if(Input.GetKeyUp(KeyCode.A))
        {
            Player_anim.SetInteger("Animationnum", (int)Animationnum.Idle);
        }

        if (Input.GetKey(KeyCode.D))//D�������Ă���Ԃ̓{�����[�����オ��
        {
            volume_slider.value += slider_speed * Time.deltaTime;
            Player_anim.SetInteger("Animationnum", (int)Animationnum.Adjust);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            Player_anim.SetInteger("Animationnum", (int)Animationnum.Idle);
        }

    }
}

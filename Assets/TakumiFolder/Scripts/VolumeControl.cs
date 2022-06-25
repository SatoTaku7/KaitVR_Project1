using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    Slider volume_slider;
    [SerializeField]  AudioSource DJ_music;//Music�I�u�W�F�N�g��AudioSource�R���|�[�l���g�擾
    [SerializeField] float slider_speed = 40f;//�X���C�_�[�̈ړ��X�s�[�h
    

    void Start()
    {
        volume_slider = GetComponent<Slider>();
        volume_slider.maxValue = 100;//volume_slider�̍ő�
        volume_slider.minValue = 0;//volume_slider�̍ŏ��l
        volume_slider.value = 50;//�����l
    }

    
    void Update()
    {
        
        DJ_music.volume = volume_slider.value / 100;//���ʂ�0�`1�Ȃ̂�volume_slider�̒l100����1�ɑΉ�������
        if (Input.GetKey(KeyCode.A))//A�������Ă���Ԃ̓{�����[����������
            volume_slider.value -= slider_speed*Time.deltaTime;
        if (Input.GetKey(KeyCode.D))//D�������Ă���Ԃ̓{�����[�����オ��
            volume_slider.value += slider_speed*Time.deltaTime;
    }
}

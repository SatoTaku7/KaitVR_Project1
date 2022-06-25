using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    Slider volume_slider;
    [SerializeField] float slider_speed = 20;//�X���C�_�[�̈ړ��X�s�[�h

    void Start()
    {
        volume_slider = GetComponent<Slider>();
        volume_slider.maxValue = 100;//volume_slider�̍ő�
        volume_slider.minValue = 0;//volume_slider�̍ŏ��l
    }

    
    void Update()
    {
        if (Input.GetKey(KeyCode.A))//A�������Ă���Ԃ̓{�����[����������
            volume_slider.value -= slider_speed*Time.deltaTime;
        if (Input.GetKey(KeyCode.D))//D�������Ă���Ԃ̓{�����[�����オ��
            volume_slider.value += slider_speed*Time.deltaTime;
    }
}

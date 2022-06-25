using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    Slider volume_slider;
    [SerializeField] float slider_speed = 20;//スライダーの移動スピード

    void Start()
    {
        volume_slider = GetComponent<Slider>();
        volume_slider.maxValue = 100;//volume_sliderの最大
        volume_slider.minValue = 0;//volume_sliderの最小値
    }

    
    void Update()
    {
        if (Input.GetKey(KeyCode.A))//Aを押している間はボリュームが落ちる
            volume_slider.value -= slider_speed*Time.deltaTime;
        if (Input.GetKey(KeyCode.D))//Dを押している間はボリュームが上がる
            volume_slider.value += slider_speed*Time.deltaTime;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_color : MonoBehaviour
{
    public Light light; //light�R���|�[�l���g�擾
    public float light_intensity;�@//light�̋��x�̒l
    //public Degree_excite_oikawa degree_Excite;  //����オ��x
    public int moriagari_daida;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //float hz = degree_Excite.excitement / 100 + 1;    //����オ��ɂ�閾�ł̎����ݒ�
        float hz = moriagari_daida / 10 + 1;
        float sin = Mathf.Sin(Time.time * hz);�@          //���ł��J��Ԃ����߂̎O�p�֐�
        light_intensity = sin + 1;                        //���x�ɎO�p�֐����g�����߂̐錾
        light.intensity = light_intensity;                //���
    }
}

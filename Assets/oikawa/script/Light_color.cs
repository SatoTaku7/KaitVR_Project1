using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_color : MonoBehaviour
{
    public new Light light;                        //light�R���|�[�l���g�擾
    public float light_intensity;�@            //light�̋��x�̒l
    public Degree_excite degree_Excite;        //����オ��x
    public float Devied;                       //����オ��x������
    //public int Sin_cnt;
    public float hz = 0;�@�@�@�@�@�@�@�@�@�@�@ //���C�g�̓_�ł̑�����ς���
    private float T;                           //����
    private float Time_daida;�@�@�@�@�@�@�@�@�@//Time.deltatime���ǂ�ǂ񑫂��Ă����ATime.time�Ƃقړ���
    public float moriagari_daida = 10;         //�v�C���A��֗p
    public float H;                            //���C�g�̐F�A�F����ς���
    public float S = 0.5f;�@�@�@�@�@�@�@�@�@   //���C�g�̐F�A�ʓx��ς���
    public float V = 1;                        //���C�g�̐F�A�������ǂꂾ�������邩�����߂鐔�l�A��{�I�ɏ�L�O�Ń��C�g�̐F�𐧌䂷��A�]����RGB�Ƃ͈Ⴄ



    // Start is called before the first frame update
    void Start()
    {
        hz = moriagari_daida / Devied + 1f;    //����オ��ɂ�閾�ł̎����ݒ�
        T = 2 * Mathf.PI / hz;
    }

    // Update is called once per frame
    void Update()
    {

        Time_daida += Time.deltaTime;
        //float hz = moriagari_daida / 10 + 1;
        float value = Mathf.Sin(Time_daida * hz);�@          //���ł��J��Ԃ����߂̎O�p�֐�
        light_intensity = value + 1.5f;                      //���x�ɎO�p�֐����g�����߂̐錾
        light.intensity = light_intensity;                   //���
        if(T < Time_daida)                       �@�@�@�@�@  //�X�V���
        {
            Time_daida = 0;�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@    //�������Z�b�g
            hz = moriagari_daida / Devied + 1;               //����オ��ɂ�閾�ł̎����ݒ�
            T = 2 * Mathf.PI / hz;                           //�����̏I����ݒ�
            //Debug.Log(T);
        }
        light.color = Color.HSVToRGB(H, S, V);
        H = Time_daida * 1;
        //Debug.Log(Time_daida);
    }
}

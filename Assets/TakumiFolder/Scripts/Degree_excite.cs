using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Degree_excite : MonoBehaviour  //����オ��x���p�����[�^�[�ɔ��f������E����オ��x�̌v�Z����
{
    public float clear_criteria;//�Ԉ���Ēǉ������@�\���������A���̃X�N���v�g�ɂ��֘A�����Ă��܂������߁A���Ԃ�����ΏC������
    public int excitement;//����オ��x�@���̐��l�������قǍ���̃M�A���オ��
    public PlaySceneManager playerSceneManager;//PlaySceneManager��finish_tutorial��true�ɂȂ�����`���[�g���A���p�̋@�\�I���A����オ��x�����p�����
    private float criteria_span;//clear_criteria�̕ς�郉���_���Ȏ���
    private float count;//�Q�[���J�n�ォ�玞�Ԍv��
    private float finish_count;//78�b�ŏI��������
    [SerializeField] AudioSource DJ_music;
    [SerializeField] Slider volume_slider;
    void Start()
    {
        criteria_span = Random.Range(2.5f, 6f);
        count = 0;
        finish_count = 0;
        Debug.Log(criteria_span);
    }

    void Update()
    {
        excitement =(int)(101- Mathf.Abs(DJ_music.volume * 100 - volume_slider.value));//����オ��x
        if (playerSceneManager.finish_tutorial) //�`���[�g���A����
        {
           // Debug.Log("�`���[�g���A���I��");
            After_Tutorial();
            finish_count += Time.deltaTime;
            if (finish_count > 78)//���y�I����
            {
                SceneManager.LoadScene("Alter_Start");
            }
        }
        else�@
        {
            //  Debug.Log("�`���[�g���A����");
            if (playerSceneManager.AorD)
                DJ_music.volume = 0;
            else
                DJ_music.volume = 100;
        }



        transform.rotation = Quaternion.Euler(0, 0, excitement);

    }

    void Tutorial()
    {

    }

    void After_Tutorial()
    {
        count += Time.deltaTime;
        if ((count >= criteria_span)&&(count!=0))
        {
            criteria_span = Random.Range(2.5f, 6f);//2.5�`6�b�̃X�p�������߂�
            DJ_music.volume= Random.Range(0f, 100f)/100;//�����_����0�`1�̊�ƂȂ鐔�l�����߂�@���������܂őΉ����Ă邩�킩��񂩂�������100����1���������m���
            count = 0;
        }
        Debug.Log(excitement);//Mathf.Abs(clear_criteria - volume_slider.value)*1.2f
    }


}

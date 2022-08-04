using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;

public class Degree_excite : MonoBehaviour  //����オ��x���p�����[�^�[�ɔ��f������E����オ��x�̌v�Z����
{
    public float clear_criteria;//�Ԉ���Ēǉ������@�\���������A���̃X�N���v�g�ɂ��֘A�����Ă��܂������߁A���Ԃ�����ΏC������
    public float excitement;//����オ��x�@���̐��l�������قǍ���̃M�A���オ��
    public PlaySceneManager playerSceneManager;//PlaySceneManager��finish_tutorial��true�ɂȂ�����`���[�g���A���p�̋@�\�I���A����オ��x�����p�����
    private float criteria_span;//clear_criteria�̕ς�郉���_���Ȏ���
    private float count;//�Q�[���J�n�ォ�玞�Ԍv��
    private float finish_count;//78�b�ŏI��������
    private float score_Time;//1�b�Ԋu�ŃX�R�A�����
    private float score;
    [SerializeField] AudioSource DJ_music;
    [SerializeField] Slider volume_slider;
    [SerializeField] GameObject Oikawa_PostPro;
    [SerializeField] float rotate_speed;//�j�̈ړ��X�s�[�h
    scoreData scoreData;
    [SerializeField] Text scoreText;
    [SerializeField] GameObject Para;//�p�����[�^�[�̉摜
    Image para_image;
    private PostProcessVolume postProcessVolume;

    void Start()
    {
        criteria_span = Random.Range(2.5f, 6f);
        count = 0;
        finish_count = 0;
        score_Time = 0;
        score = 0;

        if (SceneManager.GetActiveScene().name == "PlayScene")
        {
            scoreData = GameObject.Find("ScoreData").GetComponent<scoreData>();
            para_image = Para.GetComponent<Image>();
        }
            

        //Debug.Log(criteria_span);
        postProcessVolume = Oikawa_PostPro.GetComponent<PostProcessVolume>();
       

    }

    void Update()
    {
        excitement =101- Mathf.Abs(DJ_music.volume * 100 - volume_slider.value);//����オ��x
        if (SceneManager.GetActiveScene().name == "PlayScene")
        {
            para_image.color = new Color32(255, (byte)(255 - (excitement * 2)), 125, 255);
        }
        
        if (SceneManager.GetActiveScene().name == "PlayScene")
            scoreText.text = scoreData.Score.ToString();
        
        if (playerSceneManager.finish_tutorial) //�`���[�g���A����
        {
           // Debug.Log("�`���[�g���A���I��");
            After_Tutorial();
            finish_count += Time.deltaTime;
            score_Time += Time.deltaTime;
            if (finish_count > 78)//���y�I���� (78)
            {
                SceneManager.LoadScene("ResultScene");
            }
            if (score_Time > 1)
            {
                if (SceneManager.GetActiveScene().name == "PlayScene")
                    scoreData.Score += (int)excitement / 10;
                score_Time = 0;
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
        transform.rotation =Quaternion.Lerp(transform.rotation,Quaternion.Euler(0, 0, excitement*2.1f),rotate_speed*Time.deltaTime);
    }

    void After_Tutorial()
    {
        count += Time.deltaTime;
        if ((count >= criteria_span) && (count != 0))
        {
            if(finish_count < 20)
            {
                criteria_span = Random.Range(3.5f, 6.0f);//2.5�`6�b�̃X�p�������߂�
            }
            else if (20 <= finish_count && finish_count < 50)
            {
                criteria_span = Random.Range(2.5f, 4.0f);//2.5�`6�b�̃X�p�������߂�
            }
            else
            {
                criteria_span = Random.Range(0.75f, 2.5f);//2.5�`6�b�̃X�p�������߂�
            }
            DJ_music.volume= Random.Range(0f, 100f)/100;//�����_����0�`1�̊�ƂȂ鐔�l�����߂�@
            count = 0;
        }
        Debug.Log(excitement);

    }


}

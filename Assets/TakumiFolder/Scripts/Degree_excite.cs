using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Degree_excite : MonoBehaviour  //����オ��x���p�����[�^�[�ɔ��f������E����オ��x�̌v�Z����
{
    public float clear_criteria;//���̐��l�Ɖ��ʂ��߂��قǐ���オ��x�������Ȃ�@�����_���Ȏ��Ԃ��ƂɁ������_���Ȑ��l�ɂȂ�
    private int excitement;//����オ��x�@���̐��l�������قǍ���̃M�A���オ��
    public PlaySceneManager playerSceneManager;//PlaySceneManager��finish_tutorial��true�ɂȂ�����`���[�g���A���p�̋@�\�I���A����オ��x�����p�����
    private float criteria_span;//clear_criteria�̕ς�郉���_���Ȏ���
    private float count;//�Q�[���J�n�ォ�玞�Ԍv��
    private float finish_count;//78�b�ŏI��������
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
        
        if (playerSceneManager.finish_tutorial) //�`���[�g���A����
        {
           // Debug.Log("�`���[�g���A���I��");
            After_Tutorial();
            finish_count += Time.deltaTime;
            Debug.Log(finish_count);
            if (finish_count > 78)//���y�I����
            {
                SceneManager.LoadScene("Alter_Start");
            }
        }
        else�@
        {
            //  Debug.Log("�`���[�g���A����");
            //if (clear_criteria - volume_slider.value < 1) 
        }


        if (Input.GetKey(KeyCode.Q)&&transform.rotation.z>-0.894f)
            transform.Rotate(new Vector3(0, 0, 1));
        if (Input.GetKey(KeyCode.E) && transform.rotation.z <0.283f)
            transform.Rotate(new Vector3(0, 0, -1));
        transform.rotation = Quaternion.Euler(0, 0, 120 - Mathf.Abs(Mathf.Pow(clear_criteria - volume_slider.value, 2) * 0.05f));
        //transform.rotation = Quaternion.Euler(0, 0, Mathf.Clamp(transform.rotation.z, -36f, 130f));
         Debug.Log(this.gameObject.transform.rotation.z);

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
            clear_criteria = Random.Range(0f, 100f);//�����_����0�`100�̊�ƂȂ鐔�l�����߂�
            Debug.Log("�ύX���s���܂��Bcriteria_span=" + criteria_span + ",clear_criteria=" + clear_criteria);
            count = 0;
        }
        //���ʂ�clear_criteria�̒l�̍���0�̎��Ɉ�ԏ�@�@����ϐ��ɂ��Ă��̕ϐ���rotation��Ή�������
        //0.288   -0.896
        //transform.rotation = Quaternion.Euler(0, 0, (120-Mathf.Abs(Mathf.Pow(clear_criteria - volume_slider.value,2)*0.05f)));
        Debug.Log(Mathf.Abs(clear_criteria - volume_slider.value));//Mathf.Abs(clear_criteria - volume_slider.value)*1.2f
    }


}

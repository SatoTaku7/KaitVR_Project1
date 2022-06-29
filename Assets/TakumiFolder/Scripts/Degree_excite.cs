using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Degree_excite : MonoBehaviour  //盛り上がり度をパラメーターに反映させる・盛り上がり度の計算をお
{
    public float clear_criteria;//この数値と音量が近いほど盛り上がり度が高くなる　ランダムな時間ごとに★ランダムな数値になる
    private int excitement;//盛り上がり度　この数値が高いほど左上のギアが上がる
    public PlaySceneManager playerSceneManager;//PlaySceneManagerのfinish_tutorialがtrueになったらチュートリアル用の機能終了、盛り上がり度が活用される
    private float criteria_span;//clear_criteriaの変わるランダムな時間
    private float count;//ゲーム開始後から時間計測
    private float finish_count;//78秒で終了させる
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
        
        if (playerSceneManager.finish_tutorial) //チュートリアル後
        {
           // Debug.Log("チュートリアル終了");
            After_Tutorial();
            finish_count += Time.deltaTime;
            Debug.Log(finish_count);
            if (finish_count > 78)//音楽終了後
            {
                SceneManager.LoadScene("Alter_Start");
            }
        }
        else　
        {
            //  Debug.Log("チュートリアル中");
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
            criteria_span = Random.Range(2.5f, 6f);//2.5～6秒のスパンを決める
            clear_criteria = Random.Range(0f, 100f);//ランダムで0～100の基準となる数値を決める
            Debug.Log("変更が行われます。criteria_span=" + criteria_span + ",clear_criteria=" + clear_criteria);
            count = 0;
        }
        //音量とclear_criteriaの値の差が0の時に一番上　　差を変数にしてその変数とrotationを対応させる
        //0.288   -0.896
        //transform.rotation = Quaternion.Euler(0, 0, (120-Mathf.Abs(Mathf.Pow(clear_criteria - volume_slider.value,2)*0.05f)));
        Debug.Log(Mathf.Abs(clear_criteria - volume_slider.value));//Mathf.Abs(clear_criteria - volume_slider.value)*1.2f
    }


}

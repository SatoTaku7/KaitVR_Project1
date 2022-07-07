using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Degree_excite : MonoBehaviour  //盛り上がり度をパラメーターに反映させる・盛り上がり度の計算をお
{
    public float clear_criteria;//間違って追加した機能だったが、他のスクリプトにも関連させてしまったため、時間があれば修正する
    public int excitement;//盛り上がり度　この数値が高いほど左上のギアが上がる
    public PlaySceneManager playerSceneManager;//PlaySceneManagerのfinish_tutorialがtrueになったらチュートリアル用の機能終了、盛り上がり度が活用される
    private float criteria_span;//clear_criteriaの変わるランダムな時間
    private float count;//ゲーム開始後から時間計測
    private float finish_count;//78秒で終了させる
    private float score_Time;//1秒間隔でスコアを取る
    private int score;
    [SerializeField] AudioSource DJ_music;
    [SerializeField] Slider volume_slider;
    void Start()
    {
        criteria_span = Random.Range(2.5f, 6f);
        count = 0;
        finish_count = 0;
        score_Time = 0;
        score = 0;
        Debug.Log(criteria_span);
    }

    void Update()
    {
        excitement =(int)(101- Mathf.Abs(DJ_music.volume * 100 - volume_slider.value));//盛り上がり度
        if (playerSceneManager.finish_tutorial) //チュートリアル後
        {
           // Debug.Log("チュートリアル終了");
            After_Tutorial();
            finish_count += Time.deltaTime;
            score_Time += Time.deltaTime;
            if (finish_count > 78)//音楽終了後
            {
                SceneManager.LoadScene("Alter_Start");
            }
            if (score_Time > 1)
            {
                score+= excitement / 10;
                score_Time = 0;
            }
        }
        else　
        {
            //  Debug.Log("チュートリアル中");
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
            criteria_span = Random.Range(2.5f, 6f);//2.5～6秒のスパンを決める
            DJ_music.volume= Random.Range(0f, 100f)/100;//ランダムで0～1の基準となる数値を決める　
            count = 0;
        }
        Debug.Log(score);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;

public class Degree_excite : MonoBehaviour  //盛り上がり度をパラメーターに反映させる・盛り上がり度の計算をお
{
    public float clear_criteria;//間違って追加した機能だったが、他のスクリプトにも関連させてしまったため、時間があれば修正する
    public float excitement;//盛り上がり度　この数値が高いほど左上のギアが上がる
    public PlaySceneManager playerSceneManager;//PlaySceneManagerのfinish_tutorialがtrueになったらチュートリアル用の機能終了、盛り上がり度が活用される
    private float criteria_span;//clear_criteriaの変わるランダムな時間
    private float count;//ゲーム開始後から時間計測
    private float finish_count;//78秒で終了させる
    private float score_Time;//1秒間隔でスコアを取る
    private float score;
    [SerializeField] AudioSource DJ_music;
    [SerializeField] Slider volume_slider;
    [SerializeField] GameObject Oikawa_PostPro;
    [SerializeField] float rotate_speed;//針の移動スピード
    scoreData scoreData;
    [SerializeField] Text scoreText;
    [SerializeField] GameObject Para;//パラメーターの画像
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
        excitement =101- Mathf.Abs(DJ_music.volume * 100 - volume_slider.value);//盛り上がり度
        if (SceneManager.GetActiveScene().name == "PlayScene")
        {
            para_image.color = new Color32(255, (byte)(255 - (excitement * 2)), 125, 255);
        }
        
        if (SceneManager.GetActiveScene().name == "PlayScene")
            scoreText.text = scoreData.Score.ToString();
        
        if (playerSceneManager.finish_tutorial) //チュートリアル後
        {
           // Debug.Log("チュートリアル終了");
            After_Tutorial();
            finish_count += Time.deltaTime;
            score_Time += Time.deltaTime;
            if (finish_count > 78)//音楽終了後 (78)
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
        else　
        {
            //  Debug.Log("チュートリアル中");
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
                criteria_span = Random.Range(3.5f, 6.0f);//2.5～6秒のスパンを決める
            }
            else if (20 <= finish_count && finish_count < 50)
            {
                criteria_span = Random.Range(2.5f, 4.0f);//2.5～6秒のスパンを決める
            }
            else
            {
                criteria_span = Random.Range(0.75f, 2.5f);//2.5～6秒のスパンを決める
            }
            DJ_music.volume= Random.Range(0f, 100f)/100;//ランダムで0～1の基準となる数値を決める　
            count = 0;
        }
        Debug.Log(excitement);

    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_color : MonoBehaviour
{
    public new Light light;                        //lightコンポーネント取得
    public float light_intensity;　            //lightの強度の値
    public Degree_excite degree_Excite;        //盛り上がり度
    public float Devied;                       //盛り上がり度割合い
    //public int Sin_cnt;
    public float hz = 0;　　　　　　　　　　　 //ライトの点滅の速さを変える
    private float T;                           //周期
    private float Time_daida;　　　　　　　　　//Time.deltatimeをどんどん足していく、Time.timeとほぼ同じ
    public float moriagari_daida = 10;         //要修正、代替用
    public float H;                            //ライトの色、色相を変える
    public float S = 0.5f;　　　　　　　　　   //ライトの色、彩度を変える
    public float V = 1;                        //ライトの色、白黒をどれだけ混ぜるかを決める数値、基本的に上記三つでライトの色を制御する、従来のRGBとは違う



    // Start is called before the first frame update
    void Start()
    {
        hz = moriagari_daida / Devied + 1f;    //盛り上がりによる明滅の周期設定
        T = 2 * Mathf.PI / hz;
    }

    // Update is called once per frame
    void Update()
    {

        Time_daida += Time.deltaTime;
        //float hz = moriagari_daida / 10 + 1;
        float value = Mathf.Sin(Time_daida * hz);　          //明滅を繰り返すための三角関数
        light_intensity = value + 1.5f;                      //強度に三角関数を使うための宣言
        light.intensity = light_intensity;                   //代入
        if(T < Time_daida)                       　　　　　  //更新作業
        {
            Time_daida = 0;　　　　　　　　　　　　　　　    //周期リセット
            hz = moriagari_daida / Devied + 1;               //盛り上がりによる明滅の周期設定
            T = 2 * Mathf.PI / hz;                           //周期の終了を設定
            //Debug.Log(T);
        }
        light.color = Color.HSVToRGB(H, S, V);
        H = Time_daida * 1;
        //Debug.Log(Time_daida);
    }
}

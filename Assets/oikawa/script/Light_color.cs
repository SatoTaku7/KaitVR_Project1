using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_color : MonoBehaviour
{
    public Light light; //lightコンポーネント取得
    public float light_intensity;　//lightの強度の値
    //public Degree_excite_oikawa degree_Excite;  //盛り上がり度
    public int moriagari_daida;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //float hz = degree_Excite.excitement / 100 + 1;    //盛り上がりによる明滅の周期設定
        float hz = moriagari_daida / 10 + 1;
        float sin = Mathf.Sin(Time.time * hz);　          //明滅を繰り返すための三角関数
        light_intensity = sin + 1;                        //強度に三角関数を使うための宣言
        light.intensity = light_intensity;                //代入
    }
}

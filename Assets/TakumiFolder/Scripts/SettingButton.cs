using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingButton : MonoBehaviour
{
    AudioSource DJ_music;//プレイヤーの操作する音楽
    AudioSource AudienceCheers;//成功時の観客の歓声
    AudioSource Start_BGM;
    bool Button_Clicked;
    PlaySceneManager playScene;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        Button_Clicked = false;
        if (SceneManager.GetActiveScene().name == "StartScene")
        {
            Start_BGM = GameObject.Find("BGM").GetComponent<AudioSource>();
        }
        if (SceneManager.GetActiveScene().name == "PlayScene")
        {
            DJ_music = GameObject.Find("Music").GetComponent<AudioSource>();
            AudienceCheers = GameObject.Find("SceneManager").GetComponent<AudioSource>();
            playScene = GameObject.Find("AudienceCheers").GetComponent<PlaySceneManager>();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClicked_Settings()
    {
        if (SceneManager.GetActiveScene().name == "StartScene")
        {
            if (Button_Clicked)
            {
                Start_BGM.Play();
                Button_Clicked = false;
            }
                
            else
            {
                Start_BGM.Stop();
                Button_Clicked = true;
            }
                
        }
        if (SceneManager.GetActiveScene().name == "PlayScene")
        {
           
            if (Button_Clicked)
            {
                if (playScene.finish_tutorial)
                {
                    DJ_music.Play();
                }
                
                AudienceCheers.Play();
                Button_Clicked = false;
            }
            else
            {
                if (playScene.finish_tutorial)
                {
                    DJ_music.Stop();
                }
                AudienceCheers.Stop();
                Button_Clicked = true;
            }
        }
    }
}

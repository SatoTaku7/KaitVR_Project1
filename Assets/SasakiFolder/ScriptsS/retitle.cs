using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class retitle : MonoBehaviour
{
    public void ButtonClicked()
    {
        SceneManager.LoadScene("StartScene");
        Destroy(GameObject.Find("ScoreData"));
    }
}

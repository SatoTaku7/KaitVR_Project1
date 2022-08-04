using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goKariPlayscene2 : MonoBehaviour
{
    // Start is called before the first frame update
    public void ButtonClicked()
    {
        SceneManager.LoadScene("PlayScene");
        Destroy(GameObject.Find("ScoreData"));
    }
}
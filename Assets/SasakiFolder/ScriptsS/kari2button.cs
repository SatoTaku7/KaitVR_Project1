using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class kari2button : MonoBehaviour
{
    // Start is called before the first frame update
    public void ButtonClicked()
    {
        SceneManager.LoadScene("ResultScene");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelChange : MonoBehaviour
{
    public GameObject MainPanel;

    public GameObject TutorialPanel;

    void Start()
    {
        MainPanel.SetActive(true);
        TutorialPanel.SetActive(false);
    }

    public void MainView()
    {
        MainPanel.SetActive(true);
        TutorialPanel.SetActive(false);
    }

    public void TutorialView()
    {
        MainPanel.SetActive(false);
        TutorialPanel.SetActive(true);
    }
}

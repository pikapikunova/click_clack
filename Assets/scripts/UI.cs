using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    [SerializeField] private GameObject recordsPanel;
    [SerializeField] private GameObject titlesPanel;


    public void newGame()
    {
        SceneManager.LoadScene(1);
    }

    public void viewRecords()
    {
        recordsPanel.SetActive(true);
    }

    public void titles()
    {
        titlesPanel.SetActive(true);
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void back()
    {
        if (recordsPanel.activeSelf)
            recordsPanel.SetActive(false);
        
        if (titlesPanel.activeSelf)
            titlesPanel.SetActive(false);
    }
}

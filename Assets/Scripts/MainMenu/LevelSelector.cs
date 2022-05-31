using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;
using System.IO;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{

    public int m_indexSceneLevel1 = 1;
    public int m_levelToLoad;


    private string m_relativePath = @"ShoppingDaySettings\playerDetails.txt";
    private string m_absolutePath;

    private void Start() {

        SetButtonInteractibility();
    }
    private void SetButtonInteractibility() {

        m_absolutePath = Path.GetFullPath(m_relativePath);
        string lastLevelUnlocked = File.ReadAllLines(m_absolutePath)[0];

        if (m_levelToLoad > Int32.Parse(lastLevelUnlocked))
            GetComponent<Button>().interactable = false;
        else
            GetComponent<Button>().interactable = true;
            
    }
    public void LoadLevel() {

        SceneManager.LoadScene(m_levelToLoad + m_indexSceneLevel1 - 1);
    }
}

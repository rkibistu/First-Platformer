using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour {
    
    public Canvas m_gameMenu;
    public int m_indexMainMenu;

    private bool m_enable = false;

    private void Update() {

        if (InputManager.Instance.escButtonPressed) {

            InputManager.Instance.escButtonPressed = false;
            m_gameMenu.enabled = !m_gameMenu.enabled;
        }
    }

    public void GoToMainMenu() {

        SceneManager.LoadScene(m_indexMainMenu);
    }
    public void BackToGame() {


        m_gameMenu.enabled = false;
    }
}

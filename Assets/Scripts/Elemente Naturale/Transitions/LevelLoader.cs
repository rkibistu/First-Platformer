using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1f;

    public static LevelLoader Instance { get; private set; }

    private void Awake() {

        Instance = this;
    }
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.F))
        //    LoadNextLevel();
    }

    public void LoadNextLevel() {

        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int indexLevel) {

        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(indexLevel);
    }
}

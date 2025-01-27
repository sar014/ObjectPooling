using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    SceneManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void ContinueGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(3);
    }

    public void ShowRules()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameModeScript : MonoBehaviour
{
    public int currentGameMode;
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    public void OnEasyPressed()
    {
        currentGameMode = 1;
        SceneManager.LoadScene("Match-3");
    }
    public void OnMediumPressed()
    {
        currentGameMode = 2;
        SceneManager.LoadScene("Match-3");
    }
    public void OnHardPressed()
    {
        currentGameMode = 3;
        SceneManager.LoadScene("Match-3");
    }
}

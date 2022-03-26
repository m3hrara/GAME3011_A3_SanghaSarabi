using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void OnMiniGameClick()
    {
        SceneManager.LoadScene("Match-3");
    }

    public void OnMenuClicked()
    {
        SceneManager.LoadScene("StartScene");
    }
}

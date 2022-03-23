using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameButton : MonoBehaviour
{
    private MinigameManager minigameManager;
    public int row, column;

    // Start is called before the first frame update
    void Start()
    {
        minigameManager = FindObjectOfType<MinigameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

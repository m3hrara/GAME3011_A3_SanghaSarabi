using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameManager : MonoBehaviour
{
    [SerializeField]
    private GameButton gameButton;
    [SerializeField]
    private GameButton[,] buttonArray;
    [SerializeField]
    private Canvas canvas;
    [SerializeField]
    private Transform startTransform;
    private int gridSize = 6;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 tempPos = startTransform.position;
        buttonArray = new GameButton[gridSize, gridSize];
        for (int row = 0; row < gridSize; row++)
        {
            for (int column = 0; column < gridSize; column++)
            {
                buttonArray[row, column] = Instantiate(gameButton, tempPos, transform.rotation);
                buttonArray[row, column].gameObject.transform.SetParent(canvas.transform);
                buttonArray[row, column].row = row;
                buttonArray[row, column].column = column;
                tempPos.x += 105;
            }
            tempPos.x = startTransform.position.x;
            tempPos.y += 106;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

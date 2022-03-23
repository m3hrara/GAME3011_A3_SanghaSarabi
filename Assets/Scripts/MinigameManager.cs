using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameManager : MonoBehaviour
{
    [SerializeField]
    private GameButton gameButton;
    [SerializeField]
    private GameButton[,] buttonArray;
    private int tempSpriteNumber;
    private GameButton tempButton;
    [SerializeField]
    private Canvas canvas;
    [SerializeField]
    private Transform startTransform;
    private int gridSize = 6;

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

    public void MoveUp(int row, int column)
    {
        if (row < 5)
        {
            Debug.Log("moving up");

            tempSpriteNumber = buttonArray[row + 1, column].randomNumber;
            buttonArray[row + 1, column].randomNumber = buttonArray[row, column].randomNumber;
            buttonArray[row, column].randomNumber = tempSpriteNumber;
        }
        else
            return;
    }
    public void MoveLeft(int row, int column)
    {
        if (column > 0)
        {
            Debug.Log("moving left");

            tempSpriteNumber = buttonArray[row, column - 1].randomNumber;
            buttonArray[row, column - 1].randomNumber = buttonArray[row, column].randomNumber;
            buttonArray[row, column].randomNumber = tempSpriteNumber;
        }
        else
            return;
    }
    public void MoveDown(int row, int column)
    {
        if (row > 0)
        {
            Debug.Log("moving down");

            tempSpriteNumber = buttonArray[row - 1, column].randomNumber;
            buttonArray[row - 1, column].randomNumber = buttonArray[row, column].randomNumber;
            buttonArray[row, column].randomNumber = tempSpriteNumber;
        }
        else
            return;
    }
    public void MoveRight(int row, int column)
    {
        if (column < 5)
        {
            Debug.Log("moving right");

            tempSpriteNumber = buttonArray[row, column + 1].randomNumber;
            buttonArray[row, column + 1].randomNumber = buttonArray[row, column].randomNumber;
            buttonArray[row, column].randomNumber = tempSpriteNumber;
        }
        else
            return;
    }
}

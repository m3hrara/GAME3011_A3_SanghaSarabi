using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameManager : MonoBehaviour
{
    [SerializeField]
    private GameButton gameButton;
    private int tempSpriteNumber;
    private GameButton tempButton;
    [SerializeField]
    private Canvas canvas;
    [SerializeField]
    private Transform startTransform;
    private int gridSize = 6;
    [SerializeField]
    private List<GameButton> buttonList;

    public int gameMode;
    public int boneCount = 0;
    public int obstacleCount = 0;
    void Start()
    {
        buttonList = new List<GameButton>();
        Vector3 tempPos = startTransform.position;
        for (int row = 0; row < gridSize; row++)
        {
            for (int column = 0; column < gridSize; column++)
            {
                buttonList.Add(Instantiate(gameButton, tempPos, transform.rotation));
                buttonList[buttonList.Count - 1].gameObject.transform.SetParent(canvas.transform);
                buttonList[buttonList.Count - 1].row = row;
                buttonList[buttonList.Count - 1].column = column;
                tempPos.x += 105;

            }
            tempPos.x = startTransform.position.x;
            tempPos.y += 106;
        }
        //CheckForMatches();

    }

    public void MoveUp(int row, int column)
    {
        if (row < 5)
        {
           

            int index = (row * 5 + row) + column;
            if (buttonList[index + 6].randomNumber != 7)
            {
                boneCount = 0;
                obstacleCount = 0;
                tempSpriteNumber = buttonList[index + 6].randomNumber;
                buttonList[index + 6].randomNumber = buttonList[index].randomNumber;
                buttonList[index].randomNumber = tempSpriteNumber;

                buttonList[index + 6].SetButtonSprite();
                buttonList[index].SetButtonSprite();

                CheckForMatches();
                Debug.Log("moving up");
            }
            

        }
        else
            return;
    }
    public void MoveLeft(int row, int column)
    {
        if (column > 0)
        {

            int index = (row * 5 + row) + column;
            if (buttonList[index - 1].randomNumber != 7)
            {
                boneCount = 0;
                obstacleCount = 0;

                tempSpriteNumber = buttonList[index - 1].randomNumber;
                buttonList[index - 1].randomNumber = buttonList[index].randomNumber;
                buttonList[index].randomNumber = tempSpriteNumber;

                buttonList[index - 1].SetButtonSprite();
                buttonList[index].SetButtonSprite();

                CheckForMatches();
                Debug.Log("moving left");

            }


        }
        else
            return;
    }
    public void MoveDown(int row, int column)
    {
        if (row > 0)
        {

            int index = (row * 5 + row) + column;
            if (buttonList[index - 6].randomNumber != 7)
            {
                boneCount = 0;
                obstacleCount = 0;

                tempSpriteNumber = buttonList[index - 6].randomNumber;
                buttonList[index - 6].randomNumber = buttonList[index].randomNumber;
                buttonList[index].randomNumber = tempSpriteNumber;

                buttonList[index - 6].SetButtonSprite();
                buttonList[index].SetButtonSprite();

                CheckForMatches();
                Debug.Log("moving down");

            }

        }
        else
            return;
    }
    public void MoveRight(int row, int column)
    {
        if (column < 5)
        {

            int index = (row * 5 + row) + column;
            if (buttonList[index + 1].randomNumber != 7)
            {
                boneCount = 0;
                obstacleCount = 0;

                tempSpriteNumber = buttonList[index + 1].randomNumber;
                buttonList[index + 1].randomNumber = buttonList[index].randomNumber;
                buttonList[index].randomNumber = tempSpriteNumber;

                buttonList[index + 1].SetButtonSprite();
                buttonList[index].SetButtonSprite();

                CheckForMatches();
                Debug.Log("moving right");
            }

        }
        else
            return;
    }
    private void Update()
    {

    }
    private void CheckForMatches()
    {
        //    for (int row = 0; row < gridSize; row++)
        //    {
        //        for (int column = 0; column < gridSize; column++)
        //        {
        //            // check 2 to the left, self
        //            if(column-2 >=0)
        //            {
        //                if(buttonArray[row, column - 2] != null && buttonArray[row, column - 1] != null)
        //                {
        //                    if ((buttonArray[row, column - 2].randomNumber == buttonArray[row, column - 1].randomNumber) && (buttonArray[row, column - 1].randomNumber == buttonArray[row, column].randomNumber))
        //                    {
        //                        // a match of 3
        //                        if (buttonArray[row, column - 2].gameObject != null)
        //                            Destroy(buttonArray[row, column - 2].gameObject);
        //                        if (buttonArray[row, column - 1].gameObject != null)
        //                            Destroy(buttonArray[row, column - 1].gameObject);
        //                        if (buttonArray[row, column].gameObject != null)
        //                            Destroy(buttonArray[row, column].gameObject);
        //                        //buttonArray[row, column - 2].gameObject.SetActive(false);
        //                        //buttonArray[row, column - 1].gameObject.SetActive(false);
        //                        //buttonArray[row, column].gameObject.SetActive(false);
        //                    }
        //                }

        //            }

        //            // check one left, self, one to right
        //            if(column-1 >=0 && column+1<=5)
        //            {
        //                if (buttonArray[row, column - 1] != null && buttonArray[row, column + 1] != null)
        //                {
        //                    if ((buttonArray[row, column - 1].randomNumber == buttonArray[row, column + 1].randomNumber) && (buttonArray[row, column + 1].randomNumber == buttonArray[row, column].randomNumber))
        //                    {
        //                        // a match of 3
        //                        if (buttonArray[row, column - 1].gameObject != null)
        //                            Destroy(buttonArray[row, column - 1].gameObject);
        //                        if (buttonArray[row, column + 1].gameObject != null)
        //                            Destroy(buttonArray[row, column + 1].gameObject);
        //                        if (buttonArray[row, column].gameObject != null)
        //                            Destroy(buttonArray[row, column].gameObject);

        //                        //buttonArray[row, column - 1].gameObject.SetActive(false);
        //                        //buttonArray[row, column + 1].gameObject.SetActive(false);
        //                        //buttonArray[row, column].gameObject.SetActive(false);

        //                    }
        //                }

        //            }
        //            // check 2 to the right, self
        //            if (column + 2 <= 5)
        //            {
        //                if (buttonArray[row, column +2] != null && buttonArray[row, column + 1] != null)
        //                {
        //                    if ((buttonArray[row, column + 2].randomNumber == buttonArray[row, column + 1].randomNumber) && (buttonArray[row, column + 1].randomNumber == buttonArray[row, column].randomNumber))
        //                    {
        //                        // a match of 3
        //                        if (buttonArray[row, column + 2].GetComponent<GameButton>() != null)
        //                            Destroy(buttonArray[row, column + 2].gameObject);
        //                        if (buttonArray[row, column + 1].GetComponent<GameButton>() != null)
        //                            Destroy(buttonArray[row, column + 1].gameObject);
        //                        if (buttonArray[row, column].GetComponent<GameButton>() != null)
        //                            Destroy(buttonArray[row, column].gameObject);

        //                        //buttonArray[row, column + 2].gameObject.SetActive(false);
        //                        //buttonArray[row, column + 1].gameObject.SetActive(false);
        //                        //buttonArray[row, column].gameObject.SetActive(false);

        //                    }
        //                }

        //            }

        //            // check 2 up, self
        //            if (row + 2 <= 5)
        //            {
        //                if (buttonArray[row +2, column] != null && buttonArray[row + 1, column] != null)
        //                {
        //                    if ((buttonArray[row + 2, column].randomNumber == buttonArray[row + 1, column].randomNumber) && (buttonArray[row + 1, column].randomNumber == buttonArray[row, column].randomNumber))
        //                    {
        //                        // a match of 3

        //                        if (buttonArray[row + 2, column].GetComponent<GameButton>() != null)
        //                            Destroy(buttonArray[row + 2, column].gameObject);
        //                        if (buttonArray[row + 1, column].GetComponent<GameButton>() != null)
        //                            Destroy(buttonArray[row + 1, column].gameObject);
        //                        if (buttonArray[row, column].GetComponent<GameButton>() != null)
        //                            Destroy(buttonArray[row, column].gameObject);

        //                        //buttonArray[row + 2, column].gameObject.SetActive(false);
        //                        //buttonArray[row + 1, column].gameObject.SetActive(false);
        //                        //buttonArray[row, column].gameObject.SetActive(false);
        //                    }
        //                }

        //            }
        //            // check one up, self, one down
        //            if (row + 1 <= 5 && row - 1 >= 0)
        //            {
        //                if (buttonArray[row + 1, column] != null && buttonArray[row - 1, column] != null)
        //                {
        //                    if ((buttonArray[row + 1, column].randomNumber == buttonArray[row - 1, column].randomNumber) && (buttonArray[row - 1, column].randomNumber == buttonArray[row, column].randomNumber))
        //                    {
        //                        // a match of 3
        //                        if (buttonArray[row + 1, column].GetComponent<GameButton>() != null)
        //                            Destroy(buttonArray[row + 1, column].gameObject);
        //                        if (buttonArray[row - 1, column].GetComponent<GameButton>() != null)
        //                            Destroy(buttonArray[row - 1, column].gameObject);
        //                        if (buttonArray[row, column].GetComponent<GameButton>() != null)
        //                            Destroy(buttonArray[row, column].gameObject);


        //                        //buttonArray[row + 1, column].gameObject.SetActive(false);
        //                        //buttonArray[row - 1, column].gameObject.SetActive(false);
        //                        //buttonArray[row, column].gameObject.SetActive(false);
        //                    }
        //                }

        //            }

        //            // check 2 down, self
        //            if (row - 2 >= 0)
        //            {
        //                if (buttonArray[row - 2, column] != null && buttonArray[row - 1, column] != null)
        //                {
        //                    if ((buttonArray[row - 2, column].randomNumber == buttonArray[row - 1, column].randomNumber) && (buttonArray[row - 1, column].randomNumber == buttonArray[row, column].randomNumber))
        //                    {
        //                        // a match of 3
        //                        if (buttonArray[row - 2, column].GetComponent<GameButton>() != null)
        //                            Destroy(buttonArray[row - 2, column].gameObject);
        //                        if (buttonArray[row - 1, column].GetComponent<GameButton>() != null)
        //                            Destroy(buttonArray[row - 1, column].gameObject);
        //                        if (buttonArray[row, column].GetComponent<GameButton>() != null)
        //                            Destroy(buttonArray[row, column].gameObject);


        //                        //buttonArray[row - 2, column].gameObject.SetActive(false);
        //                        //buttonArray[row - 1, column].gameObject.SetActive(false);
        //                        //buttonArray[row, column].gameObject.SetActive(false);
        //                    }
        //                }


        //            }
        //            // 4 and 5 matches

        //        }

        //    }
        //}

    }
}

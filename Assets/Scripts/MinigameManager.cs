using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MinigameManager : MonoBehaviour
{
    [SerializeField]
    private GameButton gameButton;
    private int tempSpriteNumber;
    public GameButton tempButton;
    [SerializeField]
    private Canvas canvas;
    [SerializeField]
    private Transform startTransform;
    private int gridSize = 6;
    [SerializeField]
    private List<GameButton> buttonList;

    public int gameMode=1;
    public int boneCount = 0;
    public int obstacleCount = 0;
    public TMP_Text scoreText;
    public TMP_Text timerText;

    private int Score=0;
    private float timeLeft =60;
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

    }

    public void MoveUp(int row, int column)
    {
        int index = (row * 5 + row) + column;
        if (buttonList[index].topBtn !=null)
        {
            if (buttonList[index].topBtn.randomNumber != 7)
            {
                boneCount = 0;
                obstacleCount = 0;

                tempSpriteNumber = buttonList[index].topBtn.randomNumber;
                buttonList[index].topBtn.randomNumber = buttonList[index].randomNumber;
                buttonList[index].randomNumber = tempSpriteNumber;

                buttonList[index].topBtn.SetButtonSprite();
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
        int index = (row * 5 + row) + column;
        if (buttonList[index].leftBtn != null)
        {
            if (buttonList[index].leftBtn.randomNumber != 7)
            {
                boneCount = 0;
                obstacleCount = 0;

                tempSpriteNumber = buttonList[index].leftBtn.randomNumber;
                buttonList[index].leftBtn.randomNumber = buttonList[index].randomNumber;
                buttonList[index].randomNumber = tempSpriteNumber;

                buttonList[index].leftBtn.SetButtonSprite();
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
            int index = (row * 5 + row) + column;
        if (buttonList[index].bottomBtn != null)
        {

            if (buttonList[index].bottomBtn.randomNumber != 7)
            {
                boneCount = 0;
                obstacleCount = 0;


                tempSpriteNumber = buttonList[index].bottomBtn.randomNumber;
                buttonList[index].bottomBtn.randomNumber = buttonList[index].randomNumber;
                buttonList[index].randomNumber = tempSpriteNumber;

                buttonList[index].bottomBtn.SetButtonSprite();
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
            int index = (row * 5 + row) + column;
        if (buttonList[index].rightBtn != null)
        {

            if (buttonList[index].rightBtn.randomNumber != 7)
            {
                boneCount = 0;
                obstacleCount = 0;

                tempSpriteNumber = buttonList[index].rightBtn.randomNumber;
                buttonList[index].rightBtn.randomNumber = buttonList[index].randomNumber;
                buttonList[index].randomNumber = tempSpriteNumber;

                buttonList[index].rightBtn.SetButtonSprite();
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
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
        }
        scoreText.text = ("Score: " + Score);
        timerText.text = ("Time Remaining: " + timeLeft.ToString("F0"));
    }
    private void CheckForMatches()
    {
        for (int index = 0; index < buttonList.Count; index++)
        {
            // check 2 to the left 2 to the right 
            if ((buttonList[index].column - 2 >= 0) && (buttonList[index].column + 2 <= 5) && (buttonList[index - 2] != null && buttonList[index - 1] != null && buttonList[index] != null && buttonList[index + 1] != null && buttonList[index + 2] != null) && (buttonList[index - 2].randomNumber == buttonList[index - 1].randomNumber && buttonList[index - 1].randomNumber == buttonList[index].randomNumber && buttonList[index].randomNumber == buttonList[index + 1].randomNumber && buttonList[index + 1].randomNumber == buttonList[index + 2].randomNumber))
            {
                if (!buttonList[index - 2].isMatched && !buttonList[index - 1].isMatched && !buttonList[index].isMatched && !buttonList[index + 1].isMatched && !buttonList[index + 2].isMatched)
                {
                    buttonList[index - 2].isMatched = true;
                    buttonList[index - 1].isMatched = true;
                    buttonList[index].isMatched = true;
                    buttonList[index + 1].isMatched = true;
                    buttonList[index + 2].isMatched = true;


                    buttonList[index - 2].Reset();
                    buttonList[index - 1].Reset();
                    buttonList[index].Reset();
                    buttonList[index + 1].Reset();
                    buttonList[index + 2].Reset();

                    Debug.Log("match of 5");
                }

            }
            // check 2 to the left 1 to the right
            else if ((buttonList[index].column - 2 >= 0 && buttonList[index].column + 1 <= 5) && (buttonList[index - 2] != null && buttonList[index - 1] != null && buttonList[index] != null && buttonList[index + 1] != null) && (buttonList[index - 2].randomNumber == buttonList[index - 1].randomNumber && buttonList[index - 1].randomNumber == buttonList[index].randomNumber && buttonList[index].randomNumber == buttonList[index + 1].randomNumber))
            {
                if (!buttonList[index - 2].isMatched && !buttonList[index - 1].isMatched && !buttonList[index].isMatched && !buttonList[index + 1].isMatched)
                {
                    buttonList[index - 2].isMatched = true;
                    buttonList[index - 1].isMatched = true;
                    buttonList[index].isMatched = true;
                    buttonList[index + 1].isMatched = true;

                    buttonList[index - 2].Reset();
                    buttonList[index - 1].Reset();
                    buttonList[index].Reset();
                    buttonList[index + 1].Reset();

                    Debug.Log("match of 4");
                }

            }
            // check 2 to the right 1 to the left
            else if ((buttonList[index].column + 2 <= 5 && buttonList[index].column -1 >= 0) && (buttonList[index + 2] != null && buttonList[index + 1] != null && buttonList[index] != null && buttonList[index - 1] != null) && (buttonList[index + 2].randomNumber == buttonList[index + 1].randomNumber && buttonList[index + 1].randomNumber == buttonList[index].randomNumber && buttonList[index].randomNumber == buttonList[index - 1].randomNumber))
            {
                if (!buttonList[index + 2].isMatched && !buttonList[index + 1].isMatched && !buttonList[index].isMatched && !buttonList[index - 1].isMatched)
                {
                    buttonList[index + 2].isMatched = true;
                    buttonList[index + 1].isMatched = true;
                    buttonList[index].isMatched = true;
                    buttonList[index - 1].isMatched = true;

                    buttonList[index + 2].Reset();
                    buttonList[index + 1].Reset();
                    buttonList[index].Reset();
                    buttonList[index - 1].Reset();

                    Debug.Log("match of 4");
                }

            }


            // check 2 to the left
            else if ((buttonList[index].column - 2 >= 0) && (buttonList[index] != null && buttonList[index - 1] != null && buttonList[index - 2] != null) && (buttonList[index].randomNumber == buttonList[index - 1].randomNumber && buttonList[index - 1].randomNumber == buttonList[index - 2].randomNumber))
            {
                if (!buttonList[index - 2].isMatched && !buttonList[index - 1].isMatched && !buttonList[index].isMatched)
                {
                    buttonList[index - 2].isMatched = true;
                    buttonList[index - 1].isMatched = true;
                    buttonList[index].isMatched = true;

                    buttonList[index - 2].Reset();
                    buttonList[index - 1].Reset();
                    buttonList[index].Reset();

                    Debug.Log("match of 3");
                }

            }
            // check 2 to the right
            else if ((buttonList[index].column + 2 <=5) && (buttonList[index] != null && buttonList[index + 1] != null && buttonList[index + 2] != null) && (buttonList[index].randomNumber == buttonList[index + 1].randomNumber && buttonList[index + 1].randomNumber == buttonList[index + 2].randomNumber))
            {
                if (!buttonList[index + 2].isMatched && !buttonList[index + 1].isMatched && !buttonList[index].isMatched)
                {
                    buttonList[index + 2].isMatched = true;
                    buttonList[index + 1].isMatched = true;
                    buttonList[index].isMatched = true;

                    buttonList[index + 2].Reset();
                    buttonList[index + 1].Reset();
                    buttonList[index].Reset();

                    Debug.Log("match of 3");
                }

            }

            // check 1 to the right 1 to the left
            else if ((buttonList[index].column + 1 <= 5 && buttonList[index].column - 1 >= 0) && (buttonList[index + 1] != null && buttonList[index] != null && buttonList[index - 1] != null) && (buttonList[index + 1].randomNumber == buttonList[index].randomNumber && buttonList[index].randomNumber == buttonList[index - 1].randomNumber))
            {
                if (!buttonList[index + 1].isMatched && !buttonList[index].isMatched && !buttonList[index - 1].isMatched)
                {
                    buttonList[index + 1].isMatched = true;
                    buttonList[index].isMatched = true;
                    buttonList[index - 1].isMatched = true;

                    buttonList[index + 1].Reset();
                    buttonList[index].Reset();
                    buttonList[index - 1].Reset();

                    Debug.Log("match of 3");
                }

            }

            // check 2 up 2 down
            if ((buttonList[index].row + 2 <= 5) && (buttonList[index].row - 2 >= 0) && (buttonList[index - 12] != null && buttonList[index - 6] != null && buttonList[index] != null && buttonList[index + 6] != null && buttonList[index + 12] != null) && (buttonList[index - 12].randomNumber == buttonList[index - 6].randomNumber && buttonList[index - 6].randomNumber == buttonList[index].randomNumber && buttonList[index].randomNumber == buttonList[index + 6].randomNumber && buttonList[index + 6].randomNumber == buttonList[index + 12].randomNumber))
            {
                if (!buttonList[index - 12].isMatched && !buttonList[index - 6].isMatched && !buttonList[index].isMatched && !buttonList[index + 6].isMatched && !buttonList[index + 12].isMatched)
                {
                    buttonList[index - 12].isMatched = true;
                    buttonList[index - 6].isMatched = true;
                    buttonList[index].isMatched = true;
                    buttonList[index + 6].isMatched = true;
                    buttonList[index + 12].isMatched = true;


                    buttonList[index - 12].Reset();
                    buttonList[index - 6].Reset();
                    buttonList[index].Reset();
                    buttonList[index + 6].Reset();
                    buttonList[index + 12].Reset();

                    Debug.Log("match of 5");
                }

            }
            // check 2 up 1 down
            if ((buttonList[index].row + 2 <= 5) && (buttonList[index].row - 1 >= 0) && (buttonList[index - 6] != null && buttonList[index] != null && buttonList[index + 6] != null && buttonList[index + 12] != null) && (buttonList[index - 6].randomNumber == buttonList[index].randomNumber && buttonList[index].randomNumber == buttonList[index + 6].randomNumber && buttonList[index + 6].randomNumber == buttonList[index + 12].randomNumber))
            {
                if (!buttonList[index - 6].isMatched && !buttonList[index].isMatched && !buttonList[index + 6].isMatched && !buttonList[index + 12].isMatched)
                {
                    buttonList[index - 6].isMatched = true;
                    buttonList[index].isMatched = true;
                    buttonList[index + 6].isMatched = true;
                    buttonList[index + 12].isMatched = true;


                    buttonList[index - 6].Reset();
                    buttonList[index].Reset();
                    buttonList[index + 6].Reset();
                    buttonList[index + 12].Reset();

                    Debug.Log("match of 4");
                }

            }

            // check 2 down 1 up
            if ((buttonList[index].row + 1 <= 5) && (buttonList[index].row - 2 >= 0) && (buttonList[index - 12] != null && buttonList[index - 6] != null && buttonList[index] != null && buttonList[index + 6] != null) && (buttonList[index - 12].randomNumber == buttonList[index - 6].randomNumber && buttonList[index - 6].randomNumber == buttonList[index].randomNumber && buttonList[index].randomNumber == buttonList[index + 6].randomNumber))
            {
                if (!buttonList[index - 12].isMatched && !buttonList[index - 6].isMatched && !buttonList[index].isMatched && !buttonList[index + 6].isMatched)
                {
                    buttonList[index - 12].isMatched = true;
                    buttonList[index - 6].isMatched = true;
                    buttonList[index].isMatched = true;
                    buttonList[index + 6].isMatched = true;


                    buttonList[index - 12].Reset();
                    buttonList[index - 6].Reset();
                    buttonList[index].Reset();
                    buttonList[index + 6].Reset();

                    Debug.Log("match of 4");
                }

            }

            // check 2 up
            if ((buttonList[index].row + 2 <= 5) && (buttonList[index] != null && buttonList[index + 6] != null && buttonList[index + 12] != null) && (buttonList[index].randomNumber == buttonList[index + 6].randomNumber && buttonList[index + 6].randomNumber == buttonList[index + 12].randomNumber))
            {
                if (!buttonList[index].isMatched && !buttonList[index + 6].isMatched && !buttonList[index + 12].isMatched)
                {
                    buttonList[index].isMatched = true;
                    buttonList[index + 6].isMatched = true;
                    buttonList[index + 12].isMatched = true;


                    buttonList[index].Reset();
                    buttonList[index + 6].Reset();
                    buttonList[index + 12].Reset();

                    Debug.Log("match of 3");
                }

            }

            // check 2 down
            if ((buttonList[index].row - 2 >= 0) && (buttonList[index - 12] != null && buttonList[index - 6] != null && buttonList[index] != null) && (buttonList[index - 12].randomNumber == buttonList[index - 6].randomNumber && buttonList[index - 6].randomNumber == buttonList[index].randomNumber))
            {
                if (!buttonList[index - 12].isMatched && !buttonList[index - 6].isMatched && !buttonList[index].isMatched && !buttonList[index + 6].isMatched)
                {
                    buttonList[index - 12].isMatched = true;
                    buttonList[index - 6].isMatched = true;
                    buttonList[index].isMatched = true;


                    buttonList[index - 12].Reset();
                    buttonList[index - 6].Reset();
                    buttonList[index].Reset();

                    Debug.Log("match of 3");
                }

            }

            // check 1 up 1 down
            if ((buttonList[index].row + 1 <= 5) && (buttonList[index].row - 1 >= 0) && (buttonList[index - 6] != null && buttonList[index] != null && buttonList[index + 6] != null) && (buttonList[index - 6].randomNumber == buttonList[index].randomNumber && buttonList[index].randomNumber == buttonList[index + 6].randomNumber))
            {
                if (!buttonList[index - 6].isMatched && !buttonList[index].isMatched && !buttonList[index + 6].isMatched)
                {
                    buttonList[index - 6].isMatched = true;
                    buttonList[index].isMatched = true;
                    buttonList[index + 6].isMatched = true;


                    buttonList[index - 6].Reset();
                    buttonList[index].Reset();
                    buttonList[index + 6].Reset();

                    Debug.Log("match of 3");
                }

            }
        }
    }

    public void OnEasyPressed()
    {
        gameMode = 1;
    }
    public void OnMediumPressed()
    {
        gameMode = 2;
    }
    public void OnHardPressed()
    {
        gameMode = 3;
    }
}

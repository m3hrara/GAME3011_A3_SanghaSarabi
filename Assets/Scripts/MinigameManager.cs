using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MinigameManager : MonoBehaviour
{
    [SerializeField]
    private GameButton gameButton;
    private int tempSpriteNumber;
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
    public TMP_Text scoreText;
    public TMP_Text timerText;
    public TMP_Text endText;
    public Slider scoreSlider;
    public GameObject endScreen;
    public GameObject minigameScreen;
    public GameObject curGameMode;

    private int Score=0;
    private int maxScore = 500;
    private float timeLeft =60;
    private AudioSource audioSource;
    void Start()
    {
        Time.timeScale = 1;
        audioSource = GetComponent<AudioSource>();
        buttonList = new List<GameButton>();
        curGameMode = GameObject.FindGameObjectWithTag("GameMode");
        Vector3 tempPos = startTransform.position;
        for (int row = 0; row < gridSize; row++)
        {
            for (int column = 0; column < gridSize; column++)
            {
                buttonList.Add(Instantiate(gameButton, tempPos, transform.rotation));
                buttonList[buttonList.Count - 1].gameObject.transform.SetParent(minigameScreen.transform);
                buttonList[buttonList.Count - 1].row = row;
                buttonList[buttonList.Count - 1].column = column;
                tempPos.x += 105;

            }
            tempPos.x = startTransform.position.x;
            tempPos.y += 106;
        }

        if(curGameMode.GetComponent<GameModeScript>().currentGameMode == 1)
        {
            timeLeft = 45;
            maxScore = 1000;
        }
        else if (curGameMode.GetComponent<GameModeScript>().currentGameMode == 2)
        {
            timeLeft = 60;
            maxScore = 1000;
        }
        else if (curGameMode.GetComponent<GameModeScript>().currentGameMode == 3)
        {
            timeLeft = 80;
            maxScore = 750;
        }
        scoreSlider.maxValue = maxScore;
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

                Debug.Log("moving up");
                CheckForMatches();
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

                Debug.Log("moving left");
                CheckForMatches();

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

                Debug.Log("moving down");
                CheckForMatches();

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

                Debug.Log("moving right");
                CheckForMatches();
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
        else
        {
            Time.timeScale = 0;
            curGameMode.GetComponent<GameModeScript>().currentGameMode = 1;
            endScreen.SetActive(true);
            minigameScreen.SetActive(false);
            endText.text = ("You Lose! End Score: " + Score);
        }
        scoreText.text = ("Score: " + Score);
        timerText.text = ("Time Remaining: " + timeLeft.ToString("F0"));
        scoreSlider.value = Score;

        gameMode = curGameMode.GetComponent<GameModeScript>().currentGameMode;

        if(Score >= maxScore)
        {
            Time.timeScale = 0;
            curGameMode.GetComponent<GameModeScript>().currentGameMode = 1;
            endScreen.SetActive(true);
            minigameScreen.SetActive(false);
            endText.text = ("You Win! End Score: " + Score);
        }
    }
    private void CheckForMatches()
    {
        for (int index = 0; index < buttonList.Count; index++)
        {
            // check 2 to the left 2 to the right 
            //if ((buttonList[index].leftBtn.GetLeft() != null && buttonList[index].leftBtn != null && buttonList[index] != null && buttonList[index].rightBtn != null && buttonList[index].rightBtn.GetRight() != null) && (buttonList[index].leftBtn.GetLeft().randomNumber == buttonList[index].leftBtn.randomNumber && buttonList[index].leftBtn.randomNumber == buttonList[index].randomNumber && buttonList[index].randomNumber == buttonList[index].rightBtn.randomNumber && buttonList[index].rightBtn.randomNumber == buttonList[index].rightBtn.GetRight().randomNumber))
            //{
            //    if (!buttonList[index].leftBtn.GetLeft().isMatched && !buttonList[index].leftBtn.isMatched && !buttonList[index].isMatched && !buttonList[index].rightBtn.isMatched && !buttonList[index].rightBtn.GetRight().isMatched)
            //    {
            //        buttonList[index].leftBtn.GetLeft().isMatched = true;
            //        buttonList[index].leftBtn.isMatched = true;
            //        buttonList[index].isMatched = true;
            //        buttonList[index].rightBtn.isMatched = true;
            //        buttonList[index].rightBtn.GetRight().isMatched = true;

            //        buttonList[index].leftBtn.GetLeft().Reset();
            //        buttonList[index].leftBtn.Reset();
            //        buttonList[index].Reset();
            //        buttonList[index].rightBtn.Reset();
            //        buttonList[index].rightBtn.GetRight().Reset();

            //        Debug.Log("match of 5");
            //    }

            //}
            // check 2 to the left 1 to the right
            //else if ((buttonList[index].leftBtn.leftBtn != null && buttonList[index].leftBtn != null && buttonList[index] != null && buttonList[index].rightBtn != null) && (buttonList[index].leftBtn.leftBtn.randomNumber == buttonList[index].leftBtn.randomNumber && buttonList[index].leftBtn.randomNumber == buttonList[index].randomNumber && buttonList[index].randomNumber == buttonList[index].rightBtn.randomNumber))
            //{
            //    if (!buttonList[index].leftBtn.leftBtn.isMatched && !buttonList[index].leftBtn.isMatched && !buttonList[index].isMatched && !buttonList[index].rightBtn.isMatched)
            //    {

            //        buttonList[index].leftBtn.leftBtn.isMatched = true;
            //        buttonList[index].leftBtn.isMatched = true;
            //        buttonList[index].isMatched = true;
            //        buttonList[index].rightBtn.isMatched = true;

            //        buttonList[index].leftBtn.leftBtn.Reset();
            //        buttonList[index].leftBtn.Reset();
            //        buttonList[index].Reset();
            //        buttonList[index].rightBtn.Reset();

            //        Debug.Log("match of 4");
            //    }

            //}
            // check 2 to the right 1 to the left
            //else if ((buttonList[index].rightBtn.rightBtn != null && buttonList[index].rightBtn != null && buttonList[index] != null && buttonList[index].leftBtn != null) && (buttonList[index].rightBtn.rightBtn.randomNumber == buttonList[index].rightBtn.randomNumber && buttonList[index].rightBtn.randomNumber == buttonList[index].randomNumber && buttonList[index].randomNumber == buttonList[index].leftBtn.randomNumber))
            //{
            //    if (!buttonList[index].rightBtn.rightBtn.isMatched && !buttonList[index].rightBtn.isMatched && !buttonList[index].isMatched && !buttonList[index].leftBtn.isMatched)
            //    {
            //        buttonList[index].leftBtn.isMatched = true;
            //        buttonList[index].isMatched = true;
            //        buttonList[index].rightBtn.isMatched = true;
            //        buttonList[index].rightBtn.rightBtn.isMatched = true;

            //        buttonList[index].leftBtn.Reset();
            //        buttonList[index].Reset();
            //        buttonList[index].rightBtn.Reset();
            //        buttonList[index].rightBtn.rightBtn.Reset();

            //        Debug.Log("match of 4");
            //    }

            //}


            // check 2 to the left
            //else if ((buttonList[index] != null && buttonList[index].leftBtn != null && buttonList[index].leftBtn.leftBtn != null) && (buttonList[index].randomNumber == buttonList[index].leftBtn.randomNumber && buttonList[index].leftBtn.randomNumber == buttonList[index].leftBtn.leftBtn.randomNumber))
            //{
            //    if (!buttonList[index].leftBtn.leftBtn.isMatched && !buttonList[index].leftBtn.isMatched && !buttonList[index].isMatched)
            //    {
            //        buttonList[index].leftBtn.leftBtn.isMatched = true;
            //        buttonList[index].leftBtn.isMatched = true;
            //        buttonList[index].isMatched = true;

            //        buttonList[index].leftBtn.leftBtn.Reset();
            //        buttonList[index].leftBtn.Reset();
            //        buttonList[index].Reset();

            //        Debug.Log("match of 3");
            //    }

            //}
            // check 2 to the right
            //else if ((buttonList[index] != null && buttonList[index].rightBtn != null && buttonList[index].rightBtn.rightBtn != null) && (buttonList[index].randomNumber == buttonList[index].rightBtn.randomNumber && buttonList[index].rightBtn.randomNumber == buttonList[index].rightBtn.rightBtn.randomNumber))
            //{
            //    if (!buttonList[index].rightBtn.rightBtn.isMatched && !buttonList[index].rightBtn.isMatched && !buttonList[index].isMatched)
            //    {
            //        buttonList[index].isMatched = true;
            //        buttonList[index].rightBtn.isMatched = true;
            //        buttonList[index].rightBtn.rightBtn.isMatched = true;

            //        buttonList[index].Reset();
            //        buttonList[index].rightBtn.Reset();
            //        buttonList[index].rightBtn.rightBtn.Reset();

            //        Debug.Log("match of 3");
            //    }

            //}

            // check 1 to the right 1 to the left
            if ((buttonList[index].rightBtn != null && buttonList[index] != null && buttonList[index].leftBtn != null) && (buttonList[index].rightBtn.randomNumber == buttonList[index].randomNumber && buttonList[index].randomNumber == buttonList[index].leftBtn.randomNumber))
            {
                if (!buttonList[index].rightBtn.isMatched && !buttonList[index].isMatched && !buttonList[index].leftBtn.isMatched)
                {
                    buttonList[index].leftBtn.isMatched = true;
                    buttonList[index].isMatched = true;
                    buttonList[index].rightBtn.isMatched = true;

                    buttonList[index].leftBtn.Reset();
                    buttonList[index].Reset();
                    buttonList[index].rightBtn.Reset();

                    Debug.Log("match of 3");
                    audioSource.Play();
                    Score = Score + 50;
                }

            }

            // check 2 up 2 down
            //else if ((buttonList[index].bottomBtn.bottomBtn != null && buttonList[index].bottomBtn != null && buttonList[index] != null && buttonList[index].topBtn != null && buttonList[index].topBtn.topBtn != null) && (buttonList[index].bottomBtn.bottomBtn.randomNumber == buttonList[index].bottomBtn.randomNumber && buttonList[index].bottomBtn.randomNumber == buttonList[index].randomNumber && buttonList[index].randomNumber == buttonList[index].topBtn.randomNumber && buttonList[index].topBtn.randomNumber == buttonList[index].topBtn.topBtn.randomNumber))
            //{
            //    if (!buttonList[index].bottomBtn.bottomBtn.isMatched && !buttonList[index].bottomBtn.isMatched && !buttonList[index].isMatched && !buttonList[index].topBtn.isMatched && !buttonList[index].topBtn.topBtn.isMatched)
            //    {
            //        buttonList[index].bottomBtn.bottomBtn.isMatched = true;
            //        buttonList[index].bottomBtn.isMatched = true;
            //        buttonList[index].isMatched = true;
            //        buttonList[index].topBtn.isMatched = true;
            //        buttonList[index].topBtn.topBtn.isMatched = true;

            //        buttonList[index].bottomBtn.bottomBtn.Reset();
            //        buttonList[index].bottomBtn.Reset();
            //        buttonList[index].Reset();
            //        buttonList[index].topBtn.Reset();
            //        buttonList[index].topBtn.topBtn.Reset();

            //        Debug.Log("match of 5");
            //    }

            //}
            //// check 2 up 1 down
            //else if ((buttonList[index].bottomBtn != null && buttonList[index] != null && buttonList[index].topBtn != null && buttonList[index].topBtn.topBtn != null) && (buttonList[index].bottomBtn.randomNumber == buttonList[index].randomNumber && buttonList[index].randomNumber == buttonList[index].topBtn.randomNumber && buttonList[index].topBtn.randomNumber == buttonList[index].topBtn.topBtn.randomNumber))
            //{
            //    if (!buttonList[index].bottomBtn.isMatched && !buttonList[index].isMatched && !buttonList[index].topBtn.isMatched && !buttonList[index].topBtn.topBtn.isMatched)
            //    {
            //        buttonList[index].bottomBtn.isMatched = true;
            //        buttonList[index].isMatched = true;
            //        buttonList[index].topBtn.isMatched = true;
            //        buttonList[index].topBtn.topBtn.isMatched = true;

            //        buttonList[index].bottomBtn.Reset();
            //        buttonList[index].Reset();
            //        buttonList[index].topBtn.Reset();
            //        buttonList[index].topBtn.topBtn.Reset();

            //        Debug.Log("match of 4");
            //    }

            //}

            //// check 2 down 1 up
            //else if ((buttonList[index].bottomBtn.bottomBtn != null && buttonList[index].bottomBtn != null && buttonList[index] != null && buttonList[index].topBtn != null) && (buttonList[index].bottomBtn.bottomBtn.randomNumber == buttonList[index].bottomBtn.randomNumber && buttonList[index].bottomBtn.randomNumber == buttonList[index].randomNumber && buttonList[index].randomNumber == buttonList[index].topBtn.randomNumber))
            //{
            //    if (!buttonList[index].bottomBtn.bottomBtn.isMatched && !buttonList[index].bottomBtn.isMatched && !buttonList[index].isMatched && !buttonList[index].topBtn.isMatched)
            //    {
            //        buttonList[index].bottomBtn.bottomBtn.isMatched = true;
            //        buttonList[index].bottomBtn.isMatched = true;
            //        buttonList[index].isMatched = true;
            //        buttonList[index].topBtn.isMatched = true;

            //        buttonList[index].bottomBtn.bottomBtn.Reset();
            //        buttonList[index].bottomBtn.Reset();
            //        buttonList[index].Reset();
            //        buttonList[index].topBtn.Reset();

            //        Debug.Log("match of 4");
            //    }

            //}

            //// check 2 up
            //else if ((buttonList[index] != null && buttonList[index].topBtn != null && buttonList[index].topBtn.topBtn != null) && (buttonList[index].randomNumber == buttonList[index].topBtn.randomNumber && buttonList[index].topBtn.randomNumber == buttonList[index].topBtn.topBtn.randomNumber))
            //{
            //    if (!buttonList[index].isMatched && !buttonList[index].topBtn.isMatched && !buttonList[index].topBtn.topBtn.isMatched)
            //    {
            //        buttonList[index].isMatched = true;
            //        buttonList[index].topBtn.isMatched = true;
            //        buttonList[index].topBtn.topBtn.isMatched = true;

            //        buttonList[index].Reset();
            //        buttonList[index].topBtn.Reset();
            //        buttonList[index].topBtn.topBtn.Reset();

            //        Debug.Log("match of 3");
            //    }

            //}

            //// check 2 down
            //else if ((buttonList[index].bottomBtn.bottomBtn != null && buttonList[index].bottomBtn != null && buttonList[index] != null) && (buttonList[index].bottomBtn.bottomBtn.randomNumber == buttonList[index].bottomBtn.randomNumber && buttonList[index].bottomBtn.randomNumber == buttonList[index].randomNumber))
            //{
            //    if (!buttonList[index].bottomBtn.bottomBtn.isMatched && !buttonList[index].bottomBtn.isMatched && !buttonList[index].isMatched)
            //    {
            //        buttonList[index].bottomBtn.bottomBtn.isMatched = true;
            //        buttonList[index].bottomBtn.isMatched = true;
            //        buttonList[index].isMatched = true;

            //        buttonList[index].bottomBtn.bottomBtn.Reset();
            //        buttonList[index].bottomBtn.Reset();
            //        buttonList[index].Reset();

            //        Debug.Log("match of 3");
            //    }

            //}

            // check 1 up 1 down
            else if ( (buttonList[index].bottomBtn != null && buttonList[index] != null && buttonList[index].topBtn != null) && (buttonList[index].bottomBtn.randomNumber == buttonList[index].randomNumber && buttonList[index].randomNumber == buttonList[index].topBtn.randomNumber))
            {
                if (!buttonList[index].bottomBtn.isMatched && !buttonList[index].isMatched && !buttonList[index].topBtn.isMatched)
                {
                    buttonList[index].bottomBtn.isMatched = true;
                    buttonList[index].isMatched = true;
                    buttonList[index].topBtn.isMatched = true;

                    buttonList[index].bottomBtn.Reset();
                    buttonList[index].Reset();
                    buttonList[index].topBtn.Reset();

                    Debug.Log("match of 3");
                    audioSource.Play();
                    Score = Score + 50;
                }

            }
            //else
            //    return;
        }
    }

    public void OnEasyPressed()
    {
        curGameMode.GetComponent<GameModeScript>().OnEasyPressed();
    }
    public void OnMediumPressed()
    {
        curGameMode.GetComponent<GameModeScript>().OnMediumPressed();
    }
    public void OnHardPressed()
    {
        curGameMode.GetComponent<GameModeScript>().OnHardPressed();
    }

}

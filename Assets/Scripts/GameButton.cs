using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class GameButton : MonoBehaviour
     , IPointerUpHandler
    , IPointerDownHandler
{
    private MinigameManager minigameManager;
    public int row, column;
    public int numOfTypes = 3;
    public int randomNumber;
    public Sprite sprite1, sprite2, sprite3;
    public Sprite pickedSprite;
    private Vector3 mouseStart, mouseEnd;
    private float movementAngle;
    private bool clicked;
    public bool isMatched;
    // Start is called before the first frame update
    void Start()
    {
        minigameManager = FindObjectOfType<MinigameManager>();
        randomNumber = Random.Range(1, numOfTypes + 1);
        SetButtonSprite();
    }

    // Update is called once per frame
    void Update()
    {
        //SetButtonSprite();
        if(isMatched)
        {
            GetComponent<Image>().color = new Color(0f, 0f, 0f, 0.2f);
        }

        //MatchDetection();
    }
    public void SetButtonSprite()
    {
        switch(randomNumber)
        {
            case 1:
                GetComponent<Image>().sprite = sprite1;
                pickedSprite = sprite1;
                this.gameObject.tag = "Doge1";
                break;
            case 2:
                GetComponent<Image>().sprite = sprite2;
                pickedSprite = sprite2;
                this.gameObject.tag = "Doge2";
                break;
            case 3:
                GetComponent<Image>().sprite = sprite3;
                pickedSprite = sprite3;
                this.gameObject.tag = "Doge3";
                break;
        }
    }

    private void CalculateAngleDifference()
    {
        float yDiff = mouseEnd.y - mouseStart.y;
        float xDiff = mouseEnd.x - mouseStart.x;
        movementAngle = Mathf.Atan2(yDiff, xDiff) * Mathf.Rad2Deg;
        Debug.Log("Angle is: " + movementAngle);
        Debug.Log("yDiff: " + yDiff);
        Debug.Log("xDiff: " + xDiff);


        if(Mathf.Abs(movementAngle)>0.2f)
        SwapItems();
    }
    private void SwapItems()
    {
        Debug.Log("Row: " + row + " Column: " + column);
        if(movementAngle>45 && movementAngle<135)
        {
            minigameManager.MoveUp( row,  column);
            //MatchDetection();
            minigameManager.DestroyMatches();
        }
        else if (movementAngle > 135 || movementAngle < -135)
        {
            minigameManager.MoveLeft( row,  column);
            //MatchDetection();
            minigameManager.DestroyMatches();

        }
        else if (movementAngle > -135 && movementAngle < -45)
        {
            minigameManager.MoveDown( row,  column);
            // MatchDetection();
            minigameManager.DestroyMatches();

        }
        else
        {
            minigameManager.MoveRight( row,  column);
            //MatchDetection();
            minigameManager.DestroyMatches();

        }
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        mouseEnd = eventData.position;
        Debug.Log("end pos: " + eventData.position);

        CalculateAngleDifference();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        mouseStart = eventData.position;
        Debug.Log("start Pos" + eventData.position);
    }

    public void MatchDetection()
    {
        if(column > 0 && column <= 4)
        {
            GameButton leftDot = minigameManager.buttonArray[column - 1, row];
            GameButton rightDot = minigameManager.buttonArray[column + 1, row];
            if(leftDot.tag == this.gameObject.tag && rightDot.tag == this.gameObject.tag)
            {
                isMatched = true;
                leftDot.GetComponent<GameButton>().isMatched = true;
                rightDot.GetComponent<GameButton>().isMatched = true;
            }

        }

        if (row > 0 && row <= 4)
        {
            GameButton upDot = minigameManager.buttonArray[column, row +1];
            GameButton downDot = minigameManager.buttonArray[column, row -1];
            if (upDot.tag == this.gameObject.tag && downDot.tag == this.gameObject.tag)
            {
                isMatched = true;
                upDot.GetComponent<GameButton>().isMatched = true;
                downDot.GetComponent<GameButton>().isMatched = true;
            }

        }
    }
}

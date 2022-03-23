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
        SetButtonSprite();

    }
    void SetButtonSprite()
    {
        switch(randomNumber)
        {
            case 1:
                GetComponent<Image>().sprite = sprite1;
                pickedSprite = sprite1;
                break;
            case 2:
                GetComponent<Image>().sprite = sprite2;
                pickedSprite = sprite2;
                break;
            case 3:
                GetComponent<Image>().sprite = sprite3;
                pickedSprite = sprite3;
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
        }
        else if (movementAngle > 135 || movementAngle < -135)
        {
            minigameManager.MoveLeft( row,  column);
        }
        else if (movementAngle > -135 && movementAngle < -45)
        {
            minigameManager.MoveDown( row,  column);
        }
        else
        {
            minigameManager.MoveRight( row,  column);
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
}

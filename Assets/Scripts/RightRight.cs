using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightRight : MonoBehaviour
{
    public GameButton parentButton;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Left")
        {
            if (collision.GetComponent<Left>())
            {
                collision.GetComponent<Left>().parentButton.leftLeftBtn = parentButton;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Left")
        {
            if (collision.GetComponent<Left>())
            {
                collision.GetComponent<Left>().parentButton.leftLeftBtn = null;
            }
        }
    }
}

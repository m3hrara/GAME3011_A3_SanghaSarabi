using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Left : MonoBehaviour
{
    public GameButton parentButton;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Right")
        {
            if (collision.GetComponent<Right>())
            {
                collision.GetComponent<Right>().parentButton.rightBtn = parentButton;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Right")
        {
            if (collision.GetComponent<Right>())
            {
                collision.GetComponent<Right>().parentButton.rightBtn = null;
            }
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Right : MonoBehaviour
{
    public GameButton parentButton;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Left")
        {
            if (collision.GetComponent<Left>())
            {
                collision.GetComponent<Left>().parentButton.leftBtn = parentButton;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Left")
        {
            if (collision.GetComponent<Left>())
            {
                collision.GetComponent<Left>().parentButton.leftBtn = null;
            }
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Top : MonoBehaviour
{
    public GameButton parentButton;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bottom")
        {
            if (collision.GetComponent<Bottom>())
            {
                collision.GetComponent<Bottom>().parentButton.bottomBtn = parentButton;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bottom")
        {
            if (collision.GetComponent<Bottom>())
            {
                collision.GetComponent<Bottom>().parentButton.bottomBtn = null;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottom : MonoBehaviour
{
    public GameButton parentButton;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Top")
        {
            if (collision.GetComponent<Top>())
            {
                collision.GetComponent<Top>().parentButton.topBtn = parentButton;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Top")
        {
            if (collision.GetComponent<Top>())
            {
                collision.GetComponent<Top>().parentButton.topBtn = null;
            }
        }
    }
}

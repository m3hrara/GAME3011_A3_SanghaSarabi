using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopTop : MonoBehaviour
{
    public GameButton parentButton;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bottom")
        {
            if (collision.GetComponent<Bottom>())
            {
                collision.GetComponent<Bottom>().parentButton.bottomBottomBtn = parentButton;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bottom")
        {
            if (collision.GetComponent<Bottom>())
            {
                collision.GetComponent<Bottom>().parentButton.bottomBottomBtn = null;
            }
        }
    }
}

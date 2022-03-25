using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Top : MonoBehaviour
{
    public GameButton parentButton;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
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

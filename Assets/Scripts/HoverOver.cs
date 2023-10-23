using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverOver : MonoBehaviour
{
    public HoverMenu hoverMenu;
    private bool mouseOff = false;
    private float hideMenuMaxTime = 4.0f;
    private float timeSinceExiting = 0f;

    // Start is called before the first frame update
    void Start()
    {
        hoverMenu.Hide();
    }

    void Update()
    {
        if (mouseOff)
        {
            timeSinceExiting += Time.deltaTime;
            if (timeSinceExiting > hideMenuMaxTime)
            {

                hoverMenu.Hide();
            }
        }
    }

    public void OnMouseEnter()
    { 
        if (!GameLogic.isPaused && !hoverMenu.isActiveAndEnabled)
        {
            mouseOff = false;
            hoverMenu.Show();
        }
    }

    public void OnMouseExit()
    {
        mouseOff = true;
        timeSinceExiting = 0f;
    }
}

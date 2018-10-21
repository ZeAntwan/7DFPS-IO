using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkGameplay : MonoBehaviour {

    public GameObject[] toHide;
    public GameObject[] toShow;
    public GameObject[] toShow2;

    public GameObject[] leftView;
    public GameObject[] rightView;
    public GameObject[] bothView;

    // Use this for initialization
    void Start () {
        leftView = GameObject.FindGameObjectsWithTag("Left");
        rightView = GameObject.FindGameObjectsWithTag("Right");
        bothView = GameObject.FindGameObjectsWithTag("Both");
    }
	
	// Update is called once per frame
	void Update () {

        ViewInput(Input.GetButton("Fire1"), Input.GetButton("Fire2"));

        if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2") || Input.GetButtonUp("Fire1"), Input.GetButtonUp("Fire2")) 
        {
            DoBlink();
        }
    }

    public void ViewInput(bool left, bool right)
    {
        if (left || right)
        {
            if (left && !right)
            {
                // LEFT
                toHide = leftView;
                toShow = rightView;
                toShow2 = bothView;
            }
            else if (!left && right)
            {
                // Right
                toShow = leftView;
                toHide = rightView;
                toShow2 = bothView;
            }
            else if (left && right)
            {
                // Both
                toShow = leftView;
                toShow2 = rightView;
                toHide = bothView;
            }

            ChangeView(toHide, false);
            ChangeView(toShow, true);
            ChangeView(toShow2, true);
        }
        else
        {
            ChangeView(toHide, true);
        }
    }

    public void ChangeView(GameObject[] toChange, bool state)
    {
        foreach (GameObject go in toChange)
        {
            go.SetActive(state);
        }
    }

    public void DoBlink()
    {
        CameraFade.StartAlphaFade(Color.black, false, .05f);
    }
}

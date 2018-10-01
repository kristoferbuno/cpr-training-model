using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoulderTapCheck : MonoBehaviour {
    public bool leftCol = false, rightCol = false;
    public static bool tapped = false;

    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        if (leftCol && rightCol)
        {
            tapped = true;
            GameObject.Find("call911Page").transform.Find("GUIArrows911").gameObject.active = true;
            GameObject.Find("call911Page").transform.Find("call911Dialogue").gameObject.active = true;
            GameObject.Find("attentionPage").gameObject.active = false;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name.Contains("left"))
        {
            leftCol = true;
            Debug.Log("Left is inside");
        }

        if (col.gameObject.name.Contains("right"))
        {
            rightCol = true;
            Debug.Log("Right is inside");
        }
    }

    void OnTriggerLeave(Collider col)
    {
        if (col.gameObject.name.Contains("left"))
        {
            leftCol = false;
            Debug.Log("Left leaves");
        }

        if (col.gameObject.name.Contains("right"))
        {
            rightCol = false;
            Debug.Log("Right leaves");
        }
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoulderTapCheck : MonoBehaviour {
    public int tapTimes = 0;

    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        if (tapTimes > 2)
        {
            tapTimes = 0;
            GameObject.Find("call911Page").transform.Find("GUIArrows911").gameObject.active = true;
            GameObject.Find("call911Page").transform.Find("call911Dialogue").gameObject.active = true;
            GameObject.Find("attentionPage").gameObject.active = false;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name.Contains("Controller"))
        {
            tapTimes++;
            Debug.Log("Shoulder has been tapped!");
        }

        SteamVR_Controller.Input((int)col.gameObject.GetComponent<SteamVR_TrackedController>().controllerIndex).TriggerHapticPulse(500);
    }

}
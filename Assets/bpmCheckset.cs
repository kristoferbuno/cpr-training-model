using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bpmCheckset : MonoBehaviour {
    Text bpm;

	// Use this for initialization
	void Start () {
        bpm = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        bpm.text = (compressionCheck.bpm) == 0 ? "-" : ((int)compressionCheck.bpm).ToString();
    }
}

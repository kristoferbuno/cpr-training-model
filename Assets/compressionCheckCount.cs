using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class compressionCheckCount : MonoBehaviour {
    Text bpm;

	// Use this for initialization
	void Start () {
        bpm = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        bpm.text = compressionCheck.comptimes.Count <= 10 ? "" + compressionCheck.comptimes.Count : "" + 10;

		if (compressionCheck.comptimes.Count >= 10)
		{
		compressionCheck.comptimes.Clear();
		compressionCheck.collisions.Clear();
		compressionCheck.bpm = 0;
		GameObject.Find("cprSetup").transform.Find("compressionCompletion").gameObject.SetActive(true);
		GameObject.Find("cprSetup").transform.Find("heartCanvas").gameObject.SetActive(false);
		GameObject.Find("cprSetup").transform.Find("bottomPlate").gameObject.SetActive(false);
		GameObject.Find("cprSetup").transform.Find("topPlate").gameObject.SetActive(false);
        gameObject.SetActive(false);
		}
    }
}

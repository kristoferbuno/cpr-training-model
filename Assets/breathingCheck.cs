using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breathingCheck : MonoBehaviour {

    // Use this for initialization
    void Start() {
    }

    void Update(){
        
    }
    // Update is called once per frame

    void OnTriggerEnter(Collider col){
                Debug.Log("balrbejlanlpno");
    if (col.gameObject.name.Contains("Camera")){
        Debug.Log("Head made contact with sphere on body");
        GameObject.Find("breathingDialogue").transform.Find("breathingundertext").gameObject.SetActive(false);
        GameObject.Find("breathingDialogue").transform.Find("buttons").gameObject.SetActive(true);
        gameObject.SetActive(false);
        }
    }
}
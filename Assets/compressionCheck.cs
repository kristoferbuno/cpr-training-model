using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class compressionCheck : MonoBehaviour {

    //instantiating collision list and compression imes, last collision time, average beats per minute
    public static ArrayList collisions = new ArrayList();
    public static ArrayList comptimes = new ArrayList();
    public static float lastCollisionTime = 0;
    public static float bpm = 0;


    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        //check to see if collisions list should be cleared and the last collision time should be reset to 0
        if (lastCollisionTime != 0 && Time.time - lastCollisionTime > .2 && collisions.Count > 0)
        {
            Debug.Log("collisions length=" + collisions.Count + " cleared, lastCollisionTime=" + lastCollisionTime + " reset to 0. t=" + Time.time);
            collisions.Clear();
            lastCollisionTime = 0;
        }

        /* if (comptimes.Count > 0 && Time.time - (float)comptimes[comptimes.Count-1] > 6)
        {
            Debug.Log("comptimes length=" + comptimes.Count + " cleared, bpm=" + bpm + " reset to 0. t=" + Time.time);
            comptimes.Clear();
            bpm = 0;
        } */
    }

    void OnTriggerEnter(Collider col)
    {
        string[] tempdata = new string[3];
        tempdata[0] = (gameObject.name);
        tempdata[1] = (col.gameObject.name);
        tempdata[2] = (Time.time.ToString());

        //Debug.Log("before addition, collisions.Count=" + collisions.Count);
        collisions.Add(tempdata);
        //Debug.Log("after addition, collisions.Count=" + collisions.Count);
        lastCollisionTime = Time.time;

        //Debug.Log(gameObject.name + " just got touched by " + col.gameObject.name + "! Time: +" + lastCollisionTime);

        //printComp(collisions);

        //Debug.Log(collisions[collisions.Count-1].ToString());

        if (collisions.Count >= 4)
        {
            if (isValidCompression(collisions))
            {
                comptimes.Add(lastCollisionTime);
                collisions.Clear();
                Debug.Log("New compression added at t=" + lastCollisionTime + ", avgBPM="+(int)averageBPM(comptimes)+", comptimes.Count="+comptimes.Count);
                bpm = averageBPM(comptimes);
                lastCollisionTime = 0;
                SteamVR_Controller.Input((int)col.gameObject.GetComponent<SteamVR_TrackedController>().controllerIndex).TriggerHapticPulse(2000);
                SteamVR_Controller.Input((int)col.gameObject.GetComponent<SteamVR_TrackedController>().controllerIndex - 1).TriggerHapticPulse(2000);
                SteamVR_Controller.Input((int)col.gameObject.GetComponent<SteamVR_TrackedController>().controllerIndex + 1).TriggerHapticPulse(2000);
            }
            //Debug.Log(isValidCompression(collisions));
        }
    }

    //checks if parameter ArrayList has the most recent four collisions being two left and two right
    bool isValidCompression(ArrayList coml)
    {
        ArrayList rayl = (ArrayList)coml.Clone();

        rayl.RemoveRange(0, coml.Count - 4);

        int[] zeroIsLeftOneIsRight = new int[2];

        string topcheck = "";

        foreach (var counter in rayl)
        {
            string[] temp = (string[])counter;

            if ((temp[1].Contains("left")))
            {
                zeroIsLeftOneIsRight[0]++;
                //Debug.Log("one iteration: " + temp[1]);
            }
            else if ((temp[1].Contains("right")))
            {
                zeroIsLeftOneIsRight[1]++;
            }

            if((temp[0]).Contains("top"))
            {
                topcheck+="t";
            }
            
            else if((temp[0]).Contains("bottom"))
            {
                topcheck+="b";
            }
        }

        //Debug.Log("(left) collision count: " + zeroIsLeftOneIsRight[0] + ", (right) collision count: " + zeroIsLeftOneIsRight[1]);

       /* if (zeroIsLeftOneIsRight[0] != zeroIsLeftOneIsRight[1] && zeroIsLeftOneIsRight[0] != 2)
        {
            for (int i = 0; i < 3; i++)
            {
                foreach (var strang in coml)
                {
                    string[] temp = (string[])strang;
                    Debug.Log(temp[i] + ", step +" + i);
                }

            }
        } */

        if (zeroIsLeftOneIsRight[0] == zeroIsLeftOneIsRight[1] && zeroIsLeftOneIsRight[0] == 2 && topcheck.Substring(0,1).Equals("t"))
        {
            return true;
        }
        return false;
    }

    void printComp(ArrayList collisions)
    {
        foreach (var data in collisions)
        {
            for (int i = 0; i < 3; i++)
            {
                Debug.Log((1+i)+" of 3: "+((string[])data)[i]);
            }
        }
    }

    float averageBPM(ArrayList timelist)
    {
        if (timelist.Count < 2)
        {
            return 0;
        }

        return timelist.Count * 60 / ((float)timelist[timelist.Count-1] - (float)timelist[0]);
    }
}
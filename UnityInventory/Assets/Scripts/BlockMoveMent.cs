using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMoveMent : MonoBehaviour
{
    //Variables
    public Transform movingBlock;
    public Transform position1;
    public Transform position2;
    private Vector3 newPosition;
    public float smooth;
    public float resetTime;
    public string currentState;

	// Use this for initialization
	void Start ()
    {
        //Calls Change Target on start
        ChangeTarget();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        //Lerps the block between both the positions and takes in the speed of its movement
        movingBlock.position = Vector3.Lerp(movingBlock.position, newPosition, smooth * Time.deltaTime);
	}

    void ChangeTarget()
    {
        if (currentState == "Moving To Position 1")
        {
            //Moves it to position 2
            currentState = "Moving To Position 2";
            newPosition = position2.position;
        }
        else if (currentState == "Moving To Position 2")
        {
            //Moves it to position 1
            currentState = "Moving To Position 1";
            newPosition = position1.position;
        }

        //Allows me to schedule method calls to occure at a lter time
        Invoke("ChangeTarget", resetTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variables
    public LayerMask movementMask;
    public Interactable focus;

    Camera cam;                     //Create a camera variable
    PlayerMotor motor;              //Creates a motor variable

	// Use this for initialization
	void Start ()
    {
        cam = Camera.main;                      //Casts the main camera in the scene to our camera variable
        motor = GetComponent<PlayerMotor>();    //Gets all the components inside of PlayerMotor
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Checks our event system if we are hovering over the UI with our mouse
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))     //Left click is down
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);    //Shoots out a ray from a point on the screen (This case our mouse position)
            RaycastHit hit;         //Creates a hit variable

            if (Physics.Raycast(ray, out hit, 100, movementMask))  //Casts out a ray and stores the information in the hit variable,
                                                                   //Has a range of 100 and adds in a layer mask
            {
                //Move our player to what we hit
                motor.MoveToPoint(hit.point);   //Casts the point to the hit variable

                //Stop focusing any objects
                RemoveFocus();
            }
        }

        if (Input.GetMouseButtonDown(1))     //Left click is down
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);    //Shoots out a ray from a point on the screen (This case our mouse position)
            RaycastHit hit;         //Creates a hit variable

            if (Physics.Raycast(ray, out hit, 100))  
            {
                //Check if we hit an interactable
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                //If we did set it as our focus
                if (interactable != null)
                {
                    SetFocus(interactable);
                }
            }
        }
    }

    //Creates a setFocus function that takes in a variable that derives off the Interactable class
    void SetFocus(Interactable newFocus)
    {
        //If we focus on a new object we DeFocus on the old object and follow the new object
        if (newFocus != focus)
        {
            if (focus != null)
            {
                //Defocuses on our target
                focus.OnDeFocused();
            }

            //Sets our newFocus
            focus = newFocus;
            //Follows our newFocus
            motor.FollowTarget(newFocus);
        }

        //Focuses on the objects position
        newFocus.OnFocused(transform);
    }

    //Removes our focus
    void RemoveFocus()
    {
        if (focus != null)
        {
            focus.OnDeFocused();
        }

        focus = null;
        motor.StopFollowingTarget();
    }
}

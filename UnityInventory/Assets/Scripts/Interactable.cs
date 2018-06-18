using UnityEngine;

public class Interactable : MonoBehaviour
{
    //Variables
    public float radius = 3.0f;
    public Transform interactionTransform;

    bool isFocus = false;
    bool hasInteracted = false;
    Transform player;

    public virtual void Interact()
    {
        //This virtual method is overwritten by all deriving classes
        //Deriving Classes can modify their own version of this function
    }

    void Update()
    {
        //If we are focused on we have not interacted with the object
        if (isFocus && !hasInteracted)
        {
            //Checks the distance between the player and the objects position
            float distance = Vector3.Distance(player.position, interactionTransform.position);

            if (distance <= radius)
            {
                Interact(); //Calls the virtual function
                hasInteracted = true;
            }
        }
    }

    public void OnFocused(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        //When we focus on an object we set hasInteract to false
        hasInteracted = false;
    }

    public void OnDeFocused()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;
    }

    void OnDrawGizmosSelected()
    {
        if (interactionTransform == null)
        {
            interactionTransform = transform;
        }

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}

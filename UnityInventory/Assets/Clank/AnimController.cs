using UnityEngine;

public class AnimController : MonoBehaviour {

    Animator m_Animator;
    //int m_AnimState = 0;
    int AnimState;

    // Use this for initialization
    void Start () {
        
        m_Animator = GetComponent<Animator>(); // gets animator component

        //m_Animator.SetInteger(m_AnimState, 0); //sets state to 0 at beginning

        //AnimState = m_Animator.GetInteger(AnimState);
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {

            m_Animator.SetInteger("AnimState", 0);

        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {

            m_Animator.SetInteger("AnimState", 1);

        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {

            m_Animator.SetInteger("AnimState", 2);

        }

    }
}

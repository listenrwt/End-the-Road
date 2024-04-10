using UnityEngine;

public class End_Color : MonoBehaviour {

    private Animator Ani;
    private bool Active_End;
    private bool Active_Error;

    private End_Manager EM;

    void Start()
    {
        EM = GameObject.Find("End").GetComponent<End_Manager>();
        Ani = GetComponent<Animator>();
    }

    void Update()
    {
        Ani.SetBool("Active_End", Active_End);
        Ani.SetBool("Active_Error", Active_Error);

        if (!EM.ActiveEnd)
        {
            Active_End = false;
        }else
        {
            Active_Error = false;
            Active_End = true;
        }
    }

	void OnMouseEnter()
    {
        if (EM.ActiveEnd)
        {
            Active_Error = false;
        }else
        {
            Active_Error = true;
        }                  
    }

    void OnMouseExit()
    {       
        Active_Error = false;
    }

}

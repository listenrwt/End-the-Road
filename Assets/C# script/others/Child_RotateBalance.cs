using UnityEngine;

public class Child_RotateBalance : MonoBehaviour {

    public bool text;
    public bool mask;

    private Road_Color RC;
    private float rotateSpeed;


    void Start()
    {
        RC = GetComponentInParent<Road_Color>();
        rotateSpeed = RC.RotateSpeed;
    }

    void Update()
    {
        if (text)
        {
            transform.Rotate(0, 0, -rotateSpeed);
        }

        if (mask)
        {
            transform.Rotate(0, 0, -rotateSpeed * 2f);
        }
    }
}

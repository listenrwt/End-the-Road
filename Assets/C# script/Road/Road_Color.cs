using UnityEngine;

public class Road_Color : MonoBehaviour {

    [Header("Color")]
    public Color EnterColor;
    public Color DownColor;
    public Color DisableColor;
    [Header("Rotate")]
    public float RotateSpeed_Max;
    public float RotateSpeed_Min;
    [HideInInspector]
    public float RotateSpeed;

    private Color Ori_Color;

    private bool EnableRoad;

    private SpriteRenderer SR;


    void Awake()
    {
        GetRotateSpeed();
    }

    void GetRotateSpeed()
    {
        do
        {
            RotateSpeed = Random.Range(-RotateSpeed_Max, RotateSpeed_Max);

        } while (RotateSpeed < RotateSpeed_Min && RotateSpeed > -RotateSpeed_Min);

    }

    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        Ori_Color = SR.color;    
    }

    void Update()
    {
        IdleRotating();
    }

   
    void IdleRotating()
    {
        transform.Rotate(0, 0, RotateSpeed);
    }

    private bool _DisableRoad()
    {
        return gameObject.GetComponent<Road_Sender>().DisableRoad;
    }

   void OnMouseOver()
    {
        if (_DisableRoad())
        {
            SR.color = DisableColor;
        }else
        {
            SR.color = EnterColor;
        }          
        
    }

    void OnMouseDown()
    {
        if (_DisableRoad())
            return;
        SR.color = DownColor;
    }
    void OnMouseUp()
    {
        if (_DisableRoad())
            return;
        SR.color = Ori_Color;
    }

   void OnMouseExit()
    {
        SR.color = Ori_Color;
    }

}

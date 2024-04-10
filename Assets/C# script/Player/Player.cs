using UnityEngine;

public class Player : MonoBehaviour {

    public float Speed;
    public Transform Starting_Point;
    public float Detect_Range = 195f;

    public GameObject Portal_Par;

    [HideInInspector]
    public bool isMoving = false;
    [HideInInspector]
    public Transform Road;

    private bool isPortalRoad;

    void Start()
    {
        if (Starting_Point == null)            
            return;
        Road = Starting_Point;
        transform.position = Road.position;
    }

    void Update()
    {
        if (isMoving)
        {
            Moving();
        }
       
    }

    void Moving()
    {
        if (Road.GetComponent<Road_Sender>())
        {
            if (GetPortalRoad && isPortalRoad)
            {
                Portal_Moving();

            } else
            {
                Normal_Moving();
            }
        } else
        {
            Normal_Moving();
        }


        if (Vector2.Distance(transform.position, Road.position) <= 0.01f)
        {
            transform.position = Road.position;
            isMoving = false;
        }
    }

    void Normal_Moving()
    {
        transform.position = Vector2.MoveTowards(transform.position, Road.position, Speed * Time.deltaTime);
    }

    void Portal_Moving()
    {
        Instantiate(Portal_Par, transform.position, Quaternion.identity);
        Instantiate(Portal_Par, Road.position, Quaternion.identity);
        transform.position = Road.position;
    }

    private bool GetPortalRoad
    {
        get
        {
            return Road.GetComponent<Road_Sender>().Portal_Road;
        }
        
    }

    public void GetRoad(Transform _Road)
    {     
        if(Road != null)
        {
            isPortalRoad = GetPortalRoad;
            ChangeRoadIndex();

        }

        Road = _Road;
        isMoving = true;
        
    }
    
    void ChangeRoadIndex()
    {
        Road_Index R_Index = Road.GetComponent<Road_Index>();
        R_Index.DecreaseRoadIndex();
    }
    

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Detect_Range);
    }
   
}

using UnityEngine;

public class End_Manager : MonoBehaviour {

    private GameObject Player;
    private Player player;

    private Transform[] Roads;

    
    public static int TotalIndex;

    void Start()
    {
        TotalIndex = 0;

        Player = GameObject.FindGameObjectWithTag("Player");
        player = Player.GetComponent<Player>();

        Roads = RoadsManager.Roads;
        for (int i = 0; i < Roads.Length; i++)
        {
            TotalIndex += Roads[i].GetComponent<Road_Index>().Index;
        }       
    }
    
    private bool isCollided
    {
        get
        {
            return Vector2.Distance(transform.position, Player.transform.position) <= player.Detect_Range;
        }
    }

    private bool Connect_index1()
    {
        if (isCollided)
        {
            return checkConnectRoad();

        }else
        {
            return false;
        }
    }

    private bool checkConnectRoad()
    {
        bool enableEnd = true;

        foreach (Transform Road in Roads)
        {
            if (Road == null)
                continue;

            bool isCR = Road.GetComponent<Road_Sender>().Connect_Road;
            if (!isCR)
            {
                enableEnd = false;
                break;
            }
           
        }

        GameObject[] C_Roads = GameObject.FindGameObjectsWithTag("Connect_Road");

        foreach (GameObject C_Road in C_Roads)
        {
            int index = C_Road.GetComponent<Road_Index>().currentIndex;

            if (index != 1)
            {
                enableEnd = false;
                break;
            }
                                       
        }

        return enableEnd;

    }

    public bool ActiveEnd
    {
        get
        {

            return (TotalIndex == 1 || Connect_index1()) && isCollided && !player.isMoving;
                                
        }     
    }


}

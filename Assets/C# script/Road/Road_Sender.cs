using UnityEngine;

public class Road_Sender : MonoBehaviour {

    public bool Portal_Road;
    public bool Connect_Road;

    private GameObject Player;
    private Player player;
   
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        player = Player.GetComponent<Player>();

        Connect_Road = isConnectRoad;
    }

    private bool isConnectRoad
    {
        get
        {
            return gameObject.tag == "Connect_Road";
        }
    }

    void OnMouseDown()
    {
        if (DisableRoad)
            return;
        player.GetRoad(gameObject.transform);
        Audio_Manager.instance.PlaySound("Road_select");
    }

    private bool isCollided
    {
        get
        {
            if (Portal_Road && player.Road.GetComponent<Road_Sender>().Portal_Road)
            {
                return true;
            }
            else
            {
                return Vector2.Distance(transform.position, Player.transform.position) <= player.Detect_Range;
            }
        }
    }

    private bool Connect_Road_Error()
    {
        bool player_Road = player.Road.GetComponent<Road_Sender>().Connect_Road;

        if (!Connect_Road || !player_Road)
        {
            return false;

        } else
        {
            int currentIndex = gameObject.GetComponent<Road_Index>().currentIndex;

            if(currentIndex == 1)
            {
                return true;
            }else
            {
                return false;
            }
        }
    }
    

    public bool DisableRoad
    {
        get
        {
            return player.isMoving || player.Road == gameObject.transform || isCollided == false || Connect_Road_Error();
        }
    }

}

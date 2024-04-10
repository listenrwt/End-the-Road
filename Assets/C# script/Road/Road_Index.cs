using UnityEngine;
using UnityEngine.UI;

public class Road_Index : MonoBehaviour {

    public int Index;
    [HideInInspector]
    public int currentIndex;

    public GameObject LoseIndex_Par;
    public GameObject Destroy_Par;

    private Player player;
    private bool isConnectRoad;


    //UI
    private Text IndexText;

    void Start()
    {
        currentIndex = Index;
        IndexText = gameObject.GetComponentInChildren<Text>();
        isConnectRoad = GetComponent<Road_Sender>().Connect_Road;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        if (currentIndex == 0 && !player.isMoving)
        {
            Destroy();
        }           
        IndexText.text = currentIndex.ToString();
    }

    public void DecreaseRoadIndex()
    {
        if (!isConnectRoad)
        {
            DecreaseSingleIndex();
        }else
        {
            DecreaseMultiIndex();
        }
           
    }

    void DecreaseSingleIndex()
    {
        currentIndex--;
        if (currentIndex != 0)
        {
            Instantiate(LoseIndex_Par, transform.position, Quaternion.identity);
        }

        End_Manager.TotalIndex--;
    }
  
    void DecreaseMultiIndex()
    {
        GameObject[] ConnectRoads = GameObject.FindGameObjectsWithTag("Connect_Road");

        foreach (GameObject Road in ConnectRoads)
        {
            Road.GetComponent<Road_Index>().DecreaseSingleIndex();
        }

    }

    void Destroy()
    {
        Instantiate(Destroy_Par, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}

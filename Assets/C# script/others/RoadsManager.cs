using UnityEngine;
using System.Collections.Generic;

public class RoadsManager : MonoBehaviour {

    [Header("Imfo")]
    public bool Auto_Generate = false;
    public float Grid_const = 190f;

    [Header("Prefabs")]
    public GameObject NormalRoad;
    public GameObject PortalRoad;
    public GameObject ConnectRoad;
    public GameObject PCRoad;

    private Dictionary<string, GameObject> RoadPrefab = new Dictionary<string, GameObject>();

    [Header("Data")]
    public Vector2 startingPoint;
    public Level_blueprint[] Level_blueprint;  

    public static Transform[] Roads;
    private Player player;

    void Awake()
    {
        inputDictory();

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        if (Auto_Generate)
        {
            generateRoad();
        }      
        CountRoad();
    }

    private void inputDictory()
    {
        RoadPrefab.Add("Normal", NormalRoad);
        RoadPrefab.Add("Portal", PortalRoad);
        RoadPrefab.Add("Connect", ConnectRoad);
        RoadPrefab.Add("Portal_Connect", PCRoad);
    }

    private void generateRoad()
    {
        foreach (Level_blueprint bp in Level_blueprint)
        {
            GameObject prefab = RoadPrefab[bp.roadType.ToString()];
            Vector2 position = bp.position * Grid_const;

            GameObject road = (GameObject)Instantiate(prefab, position, Quaternion.identity);
            road.transform.parent = gameObject.transform;

            road.GetComponent<Road_Index>().Index = bp.index;

            if (bp.position == startingPoint)
                player.Starting_Point = road.transform;
        }
    }


    private void CountRoad()
    {
        Roads = new Transform[transform.childCount];

        for (int i = 0; i < Roads.Length; i++)
        {
            Roads[i] = transform.GetChild(i);
        }
    }

}


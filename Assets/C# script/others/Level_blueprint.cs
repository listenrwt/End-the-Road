using UnityEngine;

[System.Serializable]
public class Level_blueprint {

    public enum TypeOfRoad
    {
        Normal, Portal, Connect, Portal_Connect
    }
    public TypeOfRoad roadType;

    public Vector2 position;
    public int index;

	
}

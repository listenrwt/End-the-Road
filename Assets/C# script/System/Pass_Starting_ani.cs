using UnityEngine;

public class Pass_Starting_ani : MonoBehaviour {

    public float delayTime;

    SceneLoader SL;
    


    void Start()
    {
       SL  = GetComponent<SceneLoader>();

        Invoke("Pass", delayTime);
    }

    void Pass()
    {
        SL.LoadScene(1);
    }

}

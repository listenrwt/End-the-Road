using UnityEngine;

public class Particle_Rotate : MonoBehaviour {

    public float Rotate_Speed;



    void Update()
    {
        transform.Rotate(0, 0, Rotate_Speed * Time.deltaTime);
    }

}

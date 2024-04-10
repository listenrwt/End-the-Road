using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShowLevel : MonoBehaviour {

    private const int constIndex = -2;

	void Start()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        int level = index + constIndex;

        GetComponent<Text>().text = "Level " + level;
    }
    
}

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour {

    public GameObject Win_Par;
    public GameObject LC_UI;
    public float WaitForActive;

    private End_Manager EM;
    private Transform Player;
    private Player player;

    private bool applyOnce = true;
    [HideInInspector]
    public bool Won = false;

    void Start()
    { 
        
        EM = gameObject.GetComponent<End_Manager>();
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        player = Player.GetComponent<Player>();
    }

    void OnMouseDown()
    {
        if (!EM.ActiveEnd)
            return;
        player.GetRoad(gameObject.transform);
        Audio_Manager.instance.PlaySound("Road_select");
    }

    void Update()
    {
        if (transform.position == Player.position && applyOnce)
        { 
            Win();
            applyOnce = false;
        }
    }

	void Win()
    {
        Audio_Manager.instance.PlaySound("Win");
        Won = true;
        Instantiate(Win_Par, transform.position, Quaternion.identity);
        StartCoroutine(Active_LCUI());
        UnlockNewLevel();
    }

    void UnlockNewLevel()
    {
        int LevelReached = PlayerPrefs.GetInt("LevelReached");
        int currentLevel = SceneManager.GetActiveScene().buildIndex - 2;

        if(LevelReached <= currentLevel)
        {
            PlayerPrefs.SetInt("LevelReached", currentLevel + 1);
        }

    }

    IEnumerator Active_LCUI()
    {
        yield return new WaitForSeconds(WaitForActive);
        LC_UI.SetActive(true);
    }

}

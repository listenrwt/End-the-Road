using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu_Manager : MonoBehaviour {

    public GameObject[] buttons;
    private Button RestartButton;

    public float Time_to_active;
    public GameObject MenuCanvas;

    void Awake()
    {
        MenuCanvas.SetActive(false);
    }

    void Start()
    {
        RestartButton = buttons[0].GetComponent<Button>();
        Invoke("ActiveMenuCanvas", Time_to_active);

    }

    void Update()
    {
        int levelReached = PlayerPrefs.GetInt("LevelReached", 1);
        if(levelReached > 1)
        {
            RestartButton.interactable = true;
        }else
        {
            RestartButton.interactable = false;
        }
    }

    private void ActiveMenuCanvas()
    {
        MenuCanvas.SetActive(true);
    }

	public void Quit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        PlayerPrefs.SetInt("LevelReached", 1);
    }

    public void Deactivate()
    {
        foreach(GameObject button in buttons)
        {
            button.SetActive(false);
        }
    }


}

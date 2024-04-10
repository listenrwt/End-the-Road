using UnityEngine;
using UnityEngine.UI;

public class Next_Level_UI : MonoBehaviour {

    [HideInInspector]
    public bool isActive = false;
    public GameObject Pause_UI;

    public Button NextLevelButton;
    public bool LastLevel = false;

	void Start()
    {
        isActive = true;
        Pause_UI.SetActive(false);
        Time.timeScale = 0f;
    }

    void Update()
    {
        if(!LastLevel)
            return;
        NextLevelButton.interactable = false;
    }

    public void Disable_LCUI()
    {

        Audio_Manager.instance.PlaySound("Button_over");

        gameObject.SetActive(false);
    }



}

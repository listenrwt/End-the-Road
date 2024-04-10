using UnityEngine;
using UnityEngine.UI;

public class Level_Manager : MonoBehaviour {

    public static GameObject ButtonSelected;
    private int levelindex = 1;

    public Button[] Buttons;

    private SceneLoader SL;

    void Awake()
    {
        for (int i = 0; i < Buttons.Length; i++)
        {
            Buttons[i].GetComponentInChildren<Text>().text = (i + 1).ToString();
        }
    }

    void Start()
    {
        SL = GetComponent<SceneLoader>();
        ButtonSelected = null;
    }

    void Update()
    {
        checkInteract();

        if(ButtonSelected != null)
        {
            SL.LoadScene(LevelIndex());
            ButtonSelected = null;
        }
    }
   
    private void checkInteract()
    {
        int levelReached = PlayerPrefs.GetInt("LevelReached", 1);

        for (int i = 0; i < Buttons.Length; i++)
        {
            if (i + 1 > levelReached)
            {
                Buttons[i].interactable = false;
            }
            else
            {
                Buttons[i].interactable = true;
            }
        }
   }

    private int LevelIndex()
    {
        for (int i = 0; i < Buttons.Length; i++)
        {
            if(Buttons[i].gameObject == ButtonSelected)
            {
                levelindex = i + 1;
                break;
            }

        }
        return levelindex;
    }

}

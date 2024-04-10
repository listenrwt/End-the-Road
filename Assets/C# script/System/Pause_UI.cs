using UnityEngine;

public class Pause_UI : MonoBehaviour {

    public GameObject PasueUI;
    public Next_Level_UI LCUI;
    private End end;

    private bool isPause = false;

    private SceneLoader SL;

    void Start()
    {
        SL = GameObject.FindGameObjectWithTag("GM").GetComponent<SceneLoader>();
        end = GameObject.Find("End").GetComponent<End>();
    }

	void Update()
    {
            if (Input.GetKeyDown(KeyCode.Escape) && !SL.CorotineRunning && !end.Won)
            {
                if (isPause)
                {
                    UnActive_Pause();
                }
                else
                {
                    Active_Pause();
                }
            }

    }

    public void Active_Pause()
    {
        Audio_Manager.instance.PlaySound("Button_select");

        isPause = true;
        Time.timeScale = 0f;
        PasueUI.SetActive(true);

    }

    public void UnActive_Pause()
    {
        Audio_Manager.instance.PlaySound("Button_select");

        isPause = false;
        Time.timeScale = 1f;
        PasueUI.SetActive(false);
        
    }

}

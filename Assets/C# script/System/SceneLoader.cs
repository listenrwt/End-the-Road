using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;


public class SceneLoader : MonoBehaviour {

    // Fade
    public Image fade_Panel;
    public AnimationCurve fade_Curve;

    public float FadeTime;


    [HideInInspector]
    public bool CorotineRunning;

    void Start()
    {
        CorotineRunning = true;
        fade_Panel.gameObject.SetActive(true);
        StartCoroutine(Fade_In());       
    }

    //Transfer in specific scene
    public void Load_Specific_Scene(int buildIndex)
    {
        CorotineRunning = true;
        Time.timeScale = 1f;     
        StartCoroutine(Fade_Out(buildIndex));
    }

    //next level
    public void LoadScene(int ConstantBuildIndex)
    {
        CorotineRunning = true;
        Time.timeScale = 1f;
        StartCoroutine(Fade_Out(SceneManager.GetActiveScene().buildIndex + ConstantBuildIndex));
    }

    IEnumerator Fade_In()
    {
        float Time_c = FadeTime;
        while (Time_c > 0)
        {
            float alpha = fade_Curve.Evaluate(Time_c);
            fade_Panel.color = new Color(0, 0, 0, alpha);
            Time_c -= Time.deltaTime;

            yield return new WaitForSeconds(0);
        }

        CorotineRunning = false;
    }

    IEnumerator Fade_Out(int buildIndex)
    {
        float Time_c = 0f;
        while (Time_c < FadeTime)
        {
            float alpha = fade_Curve.Evaluate(Time_c);
            fade_Panel.color = new Color(0, 0, 0, alpha);
            Time_c += Time.deltaTime;

            yield return new WaitForSeconds(0);
        }
        SceneManager.LoadScene(buildIndex);
    }

}

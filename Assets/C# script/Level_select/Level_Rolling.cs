using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Level_Rolling : MonoBehaviour {

    public Transform Panels;
    public float transformDistance = 1360f;
    public float rollSpeed;
    public float mae = 0.1f;

    public Button left;
    public Button right;

    private bool rolling = false;

    void Start()
    {
        int levelreached = PlayerPrefs.GetInt("LevelReached",1);
        Vector3 Pos = new Vector3(-transformDistance, 0, 0);


        if(levelreached >= 1 && levelreached <= 8)
        {
            Panels.localPosition = Pos * 0f;
        }else if(levelreached >= 9 && levelreached <= 16)
        {
            Panels.localPosition = Pos * 1f;
        }
        else if(levelreached >= 17 && levelreached <= 24)
        {
            Panels.localPosition = Pos * 2f;
        }
        else
        {
            Panels.localPosition = Pos * 3f;
        }

    }

    private bool leftLimit
    {
        get
        {
            return Panels.localPosition.x > -mae && Panels.localPosition.x < mae;
        }
    }

    private bool rightLimit
    {
        get
        {
            float limit = -transformDistance * 2f;
            return Panels.localPosition.x > limit - mae && Panels.localPosition.x < limit + mae;
        }
    }

    public void Left()
    {
        if (rolling || leftLimit)
            return;

        StartCoroutine(Rolling(1));
    }

    public void Right()
    {
        if (rolling || rightLimit)
            return;

        StartCoroutine(Rolling(-1));
    }

    IEnumerator Rolling(float Mag)
    {
        rolling = true;

        float displacement = 0f;
        Vector3 oriPos = Panels.position;

        while(Mathf.Abs(displacement) < transformDistance)
        {
            float moveX = rollSpeed * Time.deltaTime * Mag;
            displacement += moveX;

            Panels.position += new Vector3(moveX, 0f, 0f);

            yield return new WaitForSeconds(0);
        }

        Panels.position = oriPos + new Vector3(transformDistance * Mag, 0f, 0f);
        rolling = false;
    }

}

using UnityEngine;

public class ButtonSoundFunction : MonoBehaviour {

    public void ButtonOver()
    {
        Audio_Manager.instance.PlaySound("Button_over");
    }

    public void ButtonSelect()
    {
        Audio_Manager.instance.PlaySound("Button_select");
    }
}


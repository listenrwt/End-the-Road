using UnityEngine;

public class Button_Sender : MonoBehaviour {
    
    public void SendButton()
    {
        Level_Manager.ButtonSelected = this.gameObject;
        
        Audio_Manager.instance.PlaySound("Button_select");
    
}

}

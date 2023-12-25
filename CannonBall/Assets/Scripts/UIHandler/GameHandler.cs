using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public UIHandler uiModule;
    public static GameHandler GameInstance;

    private void Awake()
    {
        GameInstance = this;
    }
}
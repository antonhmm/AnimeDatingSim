using UnityEngine;

public class Provider : MonoBehaviour
{
    public void ChangeScene(int scene)
    {
        GameController.instance.ChangeScene(scene);
    }

    public void ExitGame()
    {
        GameController.instance.ExitGame();
    }
}

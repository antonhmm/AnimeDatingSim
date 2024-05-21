using UnityEngine;

public class TitleLoader : MonoBehaviour
{
    private void Start()
    {
        SaveLoadManager.instance.GirlsToShowCalculation();
    }
}

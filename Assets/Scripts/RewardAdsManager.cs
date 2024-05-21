using UnityEngine;
using YG;

public class RewardAdsManager : MonoBehaviour
{
    [SerializeField] private YandexGame _yg;

    public void AdButton()
    {
        _yg._RewardedShow(1);
    }
}

using UnityEngine;
using UnityEngine.UI;

public class GirlCollection : MonoBehaviour
{
    [SerializeField] private GameObject _unlockPanel;
    private GirlScriptableObject _mySO;
    private GirlsShop _girlsShop;

    private void Start()
    {
        _girlsShop = FindObjectOfType<GirlsShop>();
    }

    public void SetSO(GirlScriptableObject so)
    {
        _mySO = so;
        SetIcon();
    }

    public void SelectGirl()
    {
        _girlsShop.SelectGirl(_mySO);
    }

    private void SetIcon()
    {
        GetComponentInChildren<Button>().gameObject.GetComponent<Image>().sprite = _mySO.GirlIcon;
    }
}

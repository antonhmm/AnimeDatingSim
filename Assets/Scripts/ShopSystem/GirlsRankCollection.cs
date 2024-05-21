using System.Collections.Generic;
using UnityEngine;

public class GirlsRankCollection : MonoBehaviour
{
    [SerializeField] private GameObject _holder, _detailsButton;
    [SerializeField] private GirlsShop _shop;
    [SerializeField] private int _myRank;
    private List<GameObject> _frames = new();
    private List<GirlScriptableObject> _girlsMyRank = new();
    private bool _firstOpen = false;

    private void Start()
    {
        _girlsMyRank = _shop.SeparateGirlRanks(_myRank);
        FramesCollector();
        _holder.GetComponent<ScrollerSizeController>().SetGirlsCount(_girlsMyRank.Count);
    }

    public void LoadCollection()
    {
        _detailsButton.SetActive(false);
        if (_girlsMyRank.Count > 0)
        {
            _shop.SelectGirl(_girlsMyRank[0]);
            _detailsButton.SetActive(true);
        }

        if (_firstOpen == false)
        {
            _firstOpen = true;

            for (int i = 0; i < _frames.Count; i++)
            {
                _frames[i].SetActive(false);
            }

            for (int i = 0; i < _girlsMyRank.Count; i++)
            {
                
                _frames[i].SetActive(true);
                _frames[i].GetComponent<GirlCollection>().SetSO(_girlsMyRank[i]);
            }
        }
    }

    private void FramesCollector()
    {
        for (int i = 0; i < _holder.transform.childCount; i++)
        {
            _frames.Add(_holder.transform.GetChild(i).gameObject);
        }
    }
}

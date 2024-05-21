using System.Collections.Generic;
using UnityEngine;

public class GirlsShop : MonoBehaviour
{
    [SerializeField] private Girl _girlCard;
    private List<GirlScriptableObject> _girlsToShow = new();
    private GirlScriptableObject _selectedGirl;
    
    private void Start()
    {
        _girlsToShow = SaveLoadManager.instance.GirlsToShow;
    }

    public List<GirlScriptableObject> SeparateGirlRanks(int rank)
    {
        List<GirlScriptableObject> girlNeedRank = new();

        for (int i = 0; i < _girlsToShow.Count; i++)
        {
            if (_girlsToShow[i].GirlRank == rank)
            {
                girlNeedRank.Add(_girlsToShow[i]);
            }
        }

        return girlNeedRank;
    }

    public void SelectGirl(GirlScriptableObject girl)
    {
        _selectedGirl = girl;
    }

    public void ShowSelectedGirl()
    {
        _girlCard.SetGirlSO(_selectedGirl);
    }
}

using System.Collections.Generic;
using UnityEngine;

public class SaveLoadManager : MonoBehaviour
{
    public static SaveLoadManager instance;

    private string _saveDataPath;
    private int _currentGold;
    private Dictionary<string, bool> _unlockChar;
    private List<string> _unlockGirlCollection = new();
    private List<GirlScriptableObject> _allGirls, _girlsToShow = new();
    private bool _girlsToShowFirstTime = false;

    public int Gold { get => _currentGold; }
    public Dictionary<string, bool> UnlockChar { get => _unlockChar; }
    public List<string> UnlockGirlCollection { get => _unlockGirlCollection; }
    public List<GirlScriptableObject> AllGirls { get => _allGirls; }
    public List<GirlScriptableObject> GirlsToShow { get => _girlsToShow; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        _saveDataPath = $"{Application.persistentDataPath}/SaveData.json";
        Load();

        GirlScriptableObject[] allGirls = Resources.LoadAll<GirlScriptableObject>("");
        _allGirls = new List<GirlScriptableObject>(allGirls);
    }

    public void Load()
    {
        var data = SaveLoad.Load<SaveData>(_saveDataPath);

        _currentGold = data.gold;
        _unlockChar = data.charMatrix.unlockCharacterMatrix;
        _unlockGirlCollection = data.girlCollectionUnlock;
    }

    public void Save()
    {
        SaveLoad.Save(_saveDataPath, GetSave());
    }

    public void SaveGold(int gold)
    {
        _currentGold = gold;
        Save();
    }

    public void SaveUnlockChar(Dictionary<string, bool> charData)
    {
        _unlockChar = charData;
        Save();
    }

    public void SaveGirlCollection(List<string> girlCol)
    {
        _unlockGirlCollection = girlCol;
        Save();
    }

    private SaveData GetSave()
    {
        var data = new SaveData()
        {
            gold = _currentGold,
            charMatrix = new()
            {
                unlockCharacterMatrix = _unlockChar
            },

            girlCollectionUnlock = _unlockGirlCollection
        };

        return data;
    }

    public void GirlsToShowCalculation()
    {
        if (_girlsToShowFirstTime)
        {
            _girlsToShow.Clear();
            _girlsToShow.TrimExcess();
        }

        _girlsToShowFirstTime = true;

        for (int i = 0; i < _unlockGirlCollection.Count; i++)
        {
            for (int j = 0; j < _allGirls.Count; j++)
            {
                if (_unlockGirlCollection[i] == _allGirls[j].GirlEngName)
                {
                    _girlsToShow.Add(_allGirls[j]);
                }
            }
        }
    }
}

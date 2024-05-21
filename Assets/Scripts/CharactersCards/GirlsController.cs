using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlsController : MonoBehaviour
{
    [SerializeField] private Girl _currentGirl;
    private List<GirlScriptableObject> _allGirls;
    private bool _canSpawn = true;
    private List<GirlScriptableObject> _spawnedGirls = new();
    private List<GirlScriptableObject> _availableGirls = new();
    private List<int> _possibleGirlSpawnRank = new();
    private List<string> _unlockGirlCollection = new();

    public Girl CurrentGirl { get => _currentGirl; }

    private void Awake()
    {
        _allGirls = SaveLoadManager.instance.AllGirls;
        _unlockGirlCollection = SaveLoadManager.instance.UnlockGirlCollection;
    }

    private void Start()
    {
        PossibleGirlSpawnRank();
        AvailableGirlsList();
        StartCoroutine(SpawnNewGirl());
    }
    public void GirlSpawn()
    {
        if (_canSpawn)
        {
            StartCoroutine(SpawnNewGirl());
        }
    }

    public bool CanSpawn()
    {
        return _canSpawn;
    }

    public void SaveGirlCollection()
    {
        SaveLoadManager.instance.SaveGirlCollection(_unlockGirlCollection);
    }

    private IEnumerator SpawnNewGirl()
    {
        _canSpawn = false;

        if (_availableGirls.Count == 0)
        {
            for (int i = 0; i < _spawnedGirls.Count; i++)
            {
                _availableGirls.Add(_spawnedGirls[i]);
            }
            yield return new WaitForSeconds(0.5f);
            _spawnedGirls.Clear();
            _spawnedGirls.TrimExcess();
        }

        int rand = Random.Range(0, _availableGirls.Count);
        _currentGirl.UpdateGirl(_availableGirls[rand]);
        AddGirlToUnlock(_availableGirls[rand]);
        _spawnedGirls.Add(_availableGirls[rand]);

        yield return new WaitForSeconds(0.5f);
        _availableGirls.RemoveAt(rand);
        _canSpawn = true;
    }

    private void PossibleGirlSpawnRank()
    {
        for (int i = 0; i < Player.instance.PlayerSO.PossibleGirlRank.Count; i++)
        {
            _possibleGirlSpawnRank.Add((int)Player.instance.PlayerSO.PossibleGirlRank[i]);
        }
    }

    private void AvailableGirlsList()
    {
        for (int i = 0; i < _allGirls.Count; i++)
        {
            for (int j = 0; j < _possibleGirlSpawnRank.Count; j++)
            {
                if (_allGirls[i].GirlRank == _possibleGirlSpawnRank[j])
                {
                    _availableGirls.Add(_allGirls[i]);
                }
            }
        }
    }

    private void AddGirlToUnlock(GirlScriptableObject girl)
    {
        if (_unlockGirlCollection.Count == 0)
        {
            _unlockGirlCollection.Add(girl.GirlEngName);
        }
        else
        {
            for (int i = 0; i < _unlockGirlCollection.Count; i++)
            {
                if (_unlockGirlCollection[i] == girl.GirlEngName)
                {
                    return;
                }
            }
            _unlockGirlCollection.Add(girl.GirlEngName);
        }
    }
}

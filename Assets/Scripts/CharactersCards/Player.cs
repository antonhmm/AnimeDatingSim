using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    [SerializeField] private BoysScriptableObject _playerSO;
    public BoysScriptableObject PlayerSO { get => _playerSO; private set => _playerSO = value; }
    private int _gold;
    public delegate void OnGoldChanged(int gold);
    public event OnGoldChanged onGoldChanged;

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
    }

    private void Start()
    {
        if (SaveLoadManager.instance != null)
        {
            _gold = SaveLoadManager.instance.Gold;
        }
    }

    public void ChooseCharacter(BoysScriptableObject selectCharacter)
    {
        PlayerSO = selectCharacter;
    }

    public void AddGold(int value)
    {
        _gold += value;
        onGoldChanged?.Invoke(_gold);
        SaveLoadManager.instance.SaveGold(_gold);
    }

    public void RemoveGold(int value) 
    {
        if (_gold - value < 0)
        {
            return;
        }

        _gold -= value;

        if (_gold <= 0)
        {
            _gold = 0;
        }

        SaveLoadManager.instance.SaveGold(_gold);
        onGoldChanged?.Invoke(_gold);
    }
}

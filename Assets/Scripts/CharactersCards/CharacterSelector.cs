using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
    [SerializeField] private List<BoysScriptableObject> _characters = new();
    [SerializeField] private PlayerFeatureDisplay _displayPlayer;
    [SerializeField] private GameObject _closePanel, _buttonBuy, _buttonChoose;
    [SerializeField] private TextMeshProUGUI _priceText;
    [SerializeField] private List<GameObject> _difficultTables = new();
    [SerializeField] private GoldDisplay _gDisplay;
    private Dictionary<string, bool> _unlockCharacters;
    private int _currentIndex = 0;
    private BoysScriptableObject _currentBoy;

    private void Start()
    {
        _unlockCharacters = SaveLoadManager.instance.UnlockChar;
        _currentBoy = _characters[_currentIndex];
        _displayPlayer.DisplayPlayerCard(_currentBoy);
        _priceText.text = _currentBoy.BoyPrice.ToString();
        UpdateDiffucult();
    }

    public void Left()
    {
        if (_currentIndex == 0)
        {
            _currentBoy = _characters[^1];
            _currentIndex = _characters.Count - 1;
            _displayPlayer.DisplayPlayerCard(_currentBoy);
            _priceText.text = _currentBoy.BoyPrice.ToString();
            UpdateDiffucult();
            UnlockCharacterChecker();
        }
        else
        {
            _currentIndex--;
            _currentBoy = _characters[_currentIndex];
            _displayPlayer.DisplayPlayerCard(_currentBoy);
            _priceText.text = _currentBoy.BoyPrice.ToString();
            UpdateDiffucult();
            UnlockCharacterChecker();
        }
    }

    public void Right() 
    {
        if (_currentIndex == _characters.Count - 1)
        {
            _currentIndex = 0;
            _currentBoy = _characters[_currentIndex];
            _displayPlayer.DisplayPlayerCard(_currentBoy);
            _priceText.text = _currentBoy.BoyPrice.ToString();
            UpdateDiffucult();
            UnlockCharacterChecker();
        }
        else
        {
            _currentIndex++;
            _currentBoy = _characters[_currentIndex];
            _displayPlayer.DisplayPlayerCard(_currentBoy);
            _priceText.text = _currentBoy.BoyPrice.ToString();
            UpdateDiffucult();
            UnlockCharacterChecker();
        }
    }

    public void UnlockCharacter()
    {
        if (SaveLoadManager.instance.Gold >= _currentBoy.BoyPrice)
        {
            Player.instance.RemoveGold(_currentBoy.BoyPrice);
            _unlockCharacters[_currentBoy.BoyEngName] = true;
            SaveLoadManager.instance.SaveUnlockChar(_unlockCharacters);
            _closePanel.SetActive(false);
            _buttonBuy.SetActive(false);
            _buttonChoose.SetActive(true);
        }
        else
        {
            _gDisplay.NoGoldAnimation();
        }
    }

    public void SelectCharacter()
    {
        Player.instance.ChooseCharacter(_currentBoy);
    }

    public void DisplayPlayerDetails()
    {
        _displayPlayer.DisplayPlayerDetails(_currentBoy);
    }

    private void UpdateDiffucult()
    {
        if (_currentBoy.BoyDifficult == "Easy")
        {
            _difficultTables[0].SetActive(true);
            _difficultTables[1].SetActive(false);
            _difficultTables[2].SetActive(false);
        }
        else if (_currentBoy.BoyDifficult == "Medium")
        {
            _difficultTables[0].SetActive(false);
            _difficultTables[1].SetActive(true);
            _difficultTables[2].SetActive(false);
        }
        else
        {
            _difficultTables[0].SetActive(false);
            _difficultTables[1].SetActive(false);
            _difficultTables[2].SetActive(true);
        }
    }    

    private void UnlockCharacterChecker()
    {
        foreach (var name in _unlockCharacters)
        {
            if (name.Key == _currentBoy.BoyEngName)
            {
                if (name.Value)
                {
                    _closePanel.SetActive(false);
                    _buttonBuy.SetActive(false);
                    _buttonChoose.SetActive(true);
                }
                else
                {
                    _closePanel.SetActive(true);
                    _buttonBuy.SetActive(true);
                    _buttonChoose.SetActive(false);
                }
            }
        }
    }
}

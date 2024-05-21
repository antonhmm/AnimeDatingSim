using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerFeatureDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _playerNameText, _playerDescriptionText, _playerAgeText, _playerHeigthText, _loveAgeText, _loveHeightText, _playerDetailsName;
    [SerializeField] private Image _playerIcon, _playerZodiac, _playerBackground, _playerRankIcon;
    [SerializeField] private GameObject _ageHolder, _heightHolder, _zodiacsHolder, _playerZodiacHolder, _playerHobbiesHolder;
    [SerializeField] private List<Image> _loveZodiac, _loveHairColors, _loveEyeColors;
    [SerializeField] private List<Sprite> _hairColorsIcons, _eyeColorsIcons, _hairLengthIcons, _zodiacIcons, _rankIcons, _cardBackgrounds;
    [SerializeField] private List<GameObject> _hobbieHolders, _possibleRanks, _loveZodiacHolders, _stars, _particles;

    private void Start()
    {
        BoysScriptableObject playerStat = Player.instance.PlayerSO;
        DisplayPlayerCard(playerStat);
        DisplayPlayerDetails(playerStat);
    }

    public void DisplayPlayerCard(BoysScriptableObject playerSO)
    {
        _playerNameText.text = playerSO.BoyName + ",";
        _playerDescriptionText.text = playerSO.BoyDescription;
        _playerAgeText.text = playerSO.BoyAge.ToString();
        _playerHeigthText.text = playerSO.BoyHeight.ToString();
        _playerIcon.sprite = playerSO.BoyIcon;
        _playerBackground.sprite = _cardBackgrounds[playerSO.BoyRank];
        _playerRankIcon.sprite = _rankIcons[playerSO.BoyRank];

        for (int i = 0; i < _particles.Count; i++)
        {
            _particles[i].SetActive(false);
        }
        _particles[playerSO.BoyRank].SetActive(true);

        for (int i = 0; i < _stars.Count; i++)
        {
            _stars[i].SetActive(false);
        }

        for (int i = 0; i < playerSO.BoyRank + 1; i++)
        {
            _stars[i].SetActive(true);
        }

        for (int i = 0; i < _hobbieHolders.Count; i++)
        {
            _hobbieHolders[i].SetActive(false);
        }

        _playerHobbiesHolder.SetActive(false);

        if (playerSO.BoyRank >= 4)
        {
            _playerHobbiesHolder.SetActive(true);
            HobbiesSetter(playerSO);
        }
    }

    public void DisplayPlayerDetails(BoysScriptableObject playerSO)
    {
        _playerDetailsName.text = playerSO.BoyName;
        PossibleRankSetter(playerSO);
        HairColorsSetter(playerSO);
        EyeColorsSetter(playerSO);
        _ageHolder.SetActive(false);
        _heightHolder.SetActive(false);
        _playerZodiacHolder.SetActive(false);
        _zodiacsHolder.SetActive(false);

        if (playerSO.BoyRank >= 1)
        {
            _ageHolder.SetActive(true);
            _loveAgeText.text = playerSO.MinGirlAge.ToString() + " - " + playerSO.MaxGirlAge.ToString();

            if (playerSO.BoyRank >= 2)
            {
                _heightHolder.SetActive(true);
                _loveHeightText.text = playerSO.MinGirlHeight.ToString() + " - " + playerSO.MaxGirlHeight.ToString();

                if (playerSO.BoyRank >= 3)
                {
                    _playerZodiacHolder.SetActive(true);

                    for (int i = 0; i < _zodiacIcons.Count; i++)
                    {
                        if (_zodiacIcons[i].name == playerSO.BoyZodiac)
                        {
                            _playerZodiac.sprite = _zodiacIcons[i];
                        }
                    }

                    _zodiacsHolder.SetActive(true);
                    LoveZodiacSetter(playerSO);
                }
            }
        }
    }

    private void HairColorsSetter(BoysScriptableObject playerSO)
    {
        foreach (var item in _loveHairColors)
        {
            item.gameObject.SetActive(false);
        }
        for (int i = 0; i < playerSO.LoveHairColor.Count; i++)
        {
            _loveHairColors[i].gameObject.SetActive(true);

            for (int j = 0; j < _hairColorsIcons.Count; j++)
            {
                if (playerSO.LoveHairColor[i].ToString() == _hairColorsIcons[j].name)
                {
                    _loveHairColors[i].sprite = _hairColorsIcons[j];
                }
            }
        }
    }

    private void EyeColorsSetter(BoysScriptableObject playerSO)
    {
        foreach (var item in _loveEyeColors)
        {
            item.gameObject.SetActive(false);
        }
        for (int i = 0; i < playerSO.LoveEyeColor.Count; i++)
        {
            _loveEyeColors[i].gameObject.SetActive(true);

            for (int j = 0; j < _eyeColorsIcons.Count; j++)
            {
                if (playerSO.LoveEyeColor[i].ToString() == _eyeColorsIcons[j].name)
                {
                    _loveEyeColors[i].sprite = _eyeColorsIcons[j];
                }
            }
        }
    }

    private void LoveZodiacSetter(BoysScriptableObject playerSO)
    {
        foreach (var item in _loveZodiacHolders)
        {
            item.SetActive(false);
        }
        for (int i = 0; i < playerSO.LoveZodiacSign.Count; i++)
        {
            _loveZodiacHolders[i].SetActive(true);

            for (int j = 0; j < _zodiacIcons.Count; j++)
            {
                if (playerSO.LoveZodiacSign[i].ToString() == _zodiacIcons[j].name)
                {
                    _loveZodiac[i].sprite = _zodiacIcons[j];
                }
            }
        }
    }

    private void PossibleRankSetter(BoysScriptableObject playerSO)
    {
        foreach (var item in _possibleRanks)
        {
            item.SetActive(false);
        }
        for (int i = 0; i < playerSO.PossibleGirlRank.Count; i++)
        {
            for (int j = 0; j < _possibleRanks.Count; j++)
            {
                if (playerSO.PossibleGirlRank[i].ToString() == _possibleRanks[j].name)
                {
                    _possibleRanks[j].SetActive(true);
                }
            }
        }
    }

    private void HobbiesSetter(BoysScriptableObject playerSO)
    {
        foreach (var item in _hobbieHolders)
        {
            item.SetActive(false);
        }
        for (int i = 0; i < playerSO.BoyHobbies.Count; i++)
        {
            _hobbieHolders[i].SetActive(true);
            _hobbieHolders[i].GetComponentInChildren<TextMeshProUGUI>().text = playerSO.BoyHobbies[i].ToString();
        }
    }
}

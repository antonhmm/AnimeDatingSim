using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Girl : MonoBehaviour
{
    private GirlScriptableObject _girlSO;
    public GirlScriptableObject GirlSO { get => _girlSO; private set => _girlSO = value; }

    [SerializeField] private TextMeshProUGUI _girlNameText, _girlDescriptionText, _girlAgeText, _girlHeightText;
    [SerializeField] private Image _girlIcon, _zodiacIcon, _girlBackground, _girlRankLetterIcon;
    [SerializeField] private GameObject _hobbiesHolder, _zodiacHolder;
    [SerializeField] private List<Sprite> _cardBackgrounds;
    [SerializeField] private List<Sprite> _rankIcons;
    [SerializeField] private List<Sprite> _zodiacIcons;
    [SerializeField] private List<GameObject> _particles;
    [SerializeField] private List<GameObject> _stars;
    private bool _firstStart = false;

    private void Start()
    {
        ShowGirl();
        _firstStart = true;
    }

    private void OnEnable()
    {
        if (_firstStart)
        {
            ShowGirl();
        }
    }

    public void UpdateGirl(GirlScriptableObject girlSO)
    {
        SetGirlSO(girlSO);
        ShowGirl();
    }

    public void SetGirlSO(GirlScriptableObject girlSO)
    {
        GirlSO = girlSO;
    }

    private void ShowGirl()
    {
        if (_girlSO == null)
        {
            return;
        }
        _girlNameText.text = _girlSO.GirlName + ",";
        _girlIcon.sprite = _girlSO.GirlIcon;
        _girlDescriptionText.text = _girlSO.GirlDescription;
        _girlBackground.sprite = _cardBackgrounds[_girlSO.GirlRank];
        _girlRankLetterIcon.sprite = _rankIcons[_girlSO.GirlRank];

        for (int i = 0; i < _particles.Count; i++)
        {
            _particles[i].SetActive(false);
        }
        _particles[_girlSO.GirlRank].SetActive(true);

        if (_girlSO.GirlRank >= 1)
        {
            _girlAgeText.gameObject.SetActive(true);
            _girlAgeText.text = _girlSO.GirlAge.ToString();
        }
        else
        {
            _girlAgeText.gameObject.SetActive(false);
        }

        if (_girlSO.GirlRank >= 2)
        {
            _girlHeightText.gameObject.SetActive(true);
            _girlHeightText.text = _girlSO.GirlHeight.ToString() + " см";
        }
        else
        {
            _girlHeightText.gameObject.SetActive(false);
        }

        if (_girlSO.GirlRank >= 3)
        {
            _zodiacHolder.SetActive(true);
            for (int i = 0; i < _zodiacIcons.Count; i++)
            {
                if (_zodiacIcons[i].name == _girlSO.GirlZodiacSign)
                {
                    _zodiacIcon.sprite = _zodiacIcons[i];
                }
            }
        }
        else
        {
            _zodiacHolder.SetActive(false);
        }

        if (_girlSO.GirlRank >= 4)
        {
            _hobbiesHolder.SetActive(true);
        }
        else
        {
            _hobbiesHolder.SetActive(false);
        }

        foreach (var item in _stars)
        {
            item.SetActive(false);
        }
        for (int i = 0; i < _girlSO.GirlRank + 1; i++)
        {
            _stars[i].SetActive(true);
        }
    }
}

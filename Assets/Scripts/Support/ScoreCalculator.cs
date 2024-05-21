using TMPro;
using UnityEngine;

public class ScoreCalculator : MonoBehaviour
{
    [SerializeField] private Comparer _comparer;
    [SerializeField] private ComboCalculator _comboCalculator;
    [SerializeField] private GirlsController _girlsController;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private int _scoreRewardMulti = 2, _rankScore = 2;
    private GirlScriptableObject _currentGirlSO;
    private float _score = 0;


    [HideInInspector] public int match = 0, dontMatch = 0;

    private void Start()
    {
        _scoreText.text = "0";
    }
    public void CalculateScore(int button)
    {
        //button: 0 - like, 1 - dislike

        if (_girlsController.CanSpawn())
        {
            _currentGirlSO = _girlsController.CurrentGirl.GirlSO;

            if (button == 0)
            {
                if (_comparer.ComparePlayerAndGirl(Player.instance.PlayerSO, _girlsController.CurrentGirl.GirlSO))
                {
                    if (_currentGirlSO.GirlRank >= 4)
                    {
                        if (_comparer.CompareHobbies(Player.instance.PlayerSO, _girlsController.CurrentGirl.GetComponentInChildren<HobbiesCalculator>().CurrentHobbies))
                        {
                            PlusScore(_comboCalculator.CalculateComboScore(RankScore()));
                            match++;
                        }
                        else
                        {
                            MinusScore(_currentGirlSO.GirlRank + 1);
                        }
                    }
                    else
                    {
                        PlusScore(_comboCalculator.CalculateComboScore(RankScore()));
                        match++;
                    }
                }
                else
                {
                    MinusScore(_currentGirlSO.GirlRank + 1);
                }
            }
            else if (button == 1)
            {
                if (_comparer.ComparePlayerAndGirl(Player.instance.PlayerSO, _currentGirlSO))
                {
                    if (_currentGirlSO.GirlRank >= 4)
                    {
                        if (_comparer.CompareHobbies(Player.instance.PlayerSO, _girlsController.CurrentGirl.GetComponentInChildren<HobbiesCalculator>().CurrentHobbies))
                        {
                            MinusScore(_currentGirlSO.GirlRank + 1);
                        }
                        else
                        {
                            PlusScore(_comboCalculator.CalculateComboScore(RankScore()));
                            dontMatch++;
                        }
                    }
                    else
                    {
                        MinusScore(_currentGirlSO.GirlRank + 1);
                    }
                }
                else
                {
                    PlusScore(_comboCalculator.CalculateComboScore(RankScore()));
                    dontMatch++;
                }
            }
        }
    }

    private void PlusScore(float value)
    {
        _score += value;
        _scoreText.text = ((int)_score).ToString();
        _comboCalculator.CalculateCombo(true);
    }

    private void MinusScore(float value) 
    {
        _score -= value;
        if (_score <= 0)
        {
            _score = 0;
        }
        _scoreText.text = ((int)_score).ToString();
        _comboCalculator.CalculateCombo(false);
    }

    private int RankScore()
    {
        int calcScore = _currentGirlSO.GirlRank * _rankScore + 1;

        return calcScore;
    }

    public int EndGameScore()
    {
        Player.instance.AddGold((int)_score);
        return (int)_score;
    }

    public int EndGameScoreAdMultu()
    {
        int finalScore = (int)_score * _scoreRewardMulti;
        Player.instance.AddGold(finalScore - (int)_score);
        return finalScore;
    }
}

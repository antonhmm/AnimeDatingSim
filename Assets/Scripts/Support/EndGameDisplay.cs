using TMPro;
using UnityEngine;

public class EndGameDisplay : MonoBehaviour
{
    [SerializeField] private GirlsController _gC;
    [SerializeField] private ScoreCalculator _scoreCalculator;
    [SerializeField] private TextMeshProUGUI _finalScoreText, _match, _dontMatch, _goldText;
    [SerializeField] private GameObject _adsText, _adsButton;

    private void OnEnable()
    {
        int score = _scoreCalculator.EndGameScore();
        if (score == 0)
        {
            _adsText.SetActive(false);
            _adsButton.SetActive(false);
        }
        _finalScoreText.text = score.ToString();
        _goldText.text = "+ " + score.ToString();
        _match.text = _scoreCalculator.match.ToString();
        _dontMatch.text = _scoreCalculator.dontMatch.ToString();
        _gC.SaveGirlCollection();
    }
    
    public void GoldMultiReward()
    {
        _goldText.text = "+ " + _scoreCalculator.EndGameScoreAdMultu().ToString();
    }

}

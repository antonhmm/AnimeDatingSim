using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HobbiesCalculator : MonoBehaviour
{
    [SerializeField] List<GameObject> _hobbiesPanels = new();
    [SerializeField] List<TextMeshProUGUI> _hobbiesTexts = new();
    List<string> _hobbiesNames = new() { "прогулки", "путешествия", "музыка", "игры", "кулинария", "кино", "сериалы", "спорт", "юмор", "флористика", "айти", "книги", "рисование", "танцы" };
    List<string> _currentHobbies = new();
    public List<string> CurrentHobbies { get => _currentHobbies; private set => _currentHobbies = value; }
    private int rand;

    private void Start()
    {
        rand = Random.Range(0, 3);
        CalculateHobbies();
    }

    private void OnEnable()
    {
        rand = Random.Range(0, 4);
        CurrentHobbies.Clear();
        CalculateHobbies();
    }

    private void CalculateHobbies()
    {
        foreach (var item in _hobbiesPanels)
        {
            item.SetActive(false);
        }
        for (int i = 0; i < rand; i++)
        {
            _hobbiesPanels[i].SetActive(true);
            int randHobbie = Random.Range(0, _hobbiesNames.Count);
            if (CurrentHobbies != null)
            {
                for (int j = 0; j < CurrentHobbies.Count; j++)
                {
                    if (_hobbiesNames[randHobbie] == CurrentHobbies[j])
                    {
                        CalculateHobbies();
                        return;
                    }
                }
            }
            _hobbiesTexts[i].text = _hobbiesNames[randHobbie];
            CurrentHobbies.Add(_hobbiesNames[randHobbie]);
        }
    }
}

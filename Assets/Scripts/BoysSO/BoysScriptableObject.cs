using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BoySO", menuName = "ScriptableObjects/BoySO", order = 1)]
public class BoysScriptableObject : ScriptableObject
{
    [SerializeField] private BoyRanks _boyRank;
    [SerializeField] private Sprite _boyIcon;
    [SerializeField] private string _boyName;
    [SerializeField] private string _boyEngName;
    [SerializeField] private int _boyPrice;
    [SerializeField] private Difficult _boyDifficult;
    [SerializeField][TextArea] private string _boyDescription;
    [SerializeField] private int _boyAge;
    [SerializeField] private float _boyHeight;
    [SerializeField] private ZodiacSigns _boySign;
    [SerializeField] private int _minGirlAge, _maxGirlAge;
    [SerializeField] private float _minGirlHeight, _maxGirlHeight;
    [SerializeField] private List<LoveHairColors> _loveHairColors;
    [SerializeField] private List<LoveEyeColors> _loveEyeColors;
    [SerializeField] private List<ZodiacSigns> _loveZodiacSigns;
    [SerializeField] private List<PossibleGirlRanks> _possibleGirlRanks;
    [SerializeField] private List<Hobbies> _boyHobbies;

    public enum LoveHairColors { Red, Green, Blue, Brown, Black, White, Ginger, Violet, Pink, Yellow }
    public enum LoveEyeColors { Red, Green, Blue, Black, Yellow, Pink, Violet }
    public enum ZodiacSigns { Aries, Taurus, Gemini, Cancer, Leo, Virgo, Libra, Scorpio, Sagittarius, Capricorn, Aquarius, Pisces }
    public enum PossibleGirlRanks { D, C, B, A, S, SS }
    public enum BoyRanks { D, C, B, A, S, SS }
    public enum Hobbies { прогулки, путешествия, музыка, игры, кулинария, кино, сериалы, спорт, юмор, флористика, айти, книги, рисование, танцы }
    public enum Difficult { Easy, Medium, Hard }

    public int BoyRank { get => (int)_boyRank; }
    public Sprite BoyIcon { get => _boyIcon; }
    public string BoyName { get => _boyName; }
    public string BoyEngName { get => _boyEngName; }
    public int BoyPrice { get => _boyPrice; }
    public string BoyDifficult { get => _boyDifficult.ToString(); }
    public string BoyDescription { get => _boyDescription; }
    public int BoyAge { get => _boyAge; }
    public float BoyHeight { get => _boyHeight; }
    public string BoyZodiac { get => _boySign.ToString(); }
    public int MinGirlAge { get => _minGirlAge; }
    public int MaxGirlAge { get => _maxGirlAge; }
    public float MinGirlHeight { get => _minGirlHeight; }
    public float MaxGirlHeight { get => _maxGirlHeight; }
    public List<LoveHairColors> LoveHairColor { get => _loveHairColors; }
    public List<LoveEyeColors> LoveEyeColor { get => _loveEyeColors; }
    public List<ZodiacSigns> LoveZodiacSign { get => _loveZodiacSigns; }
    public List<PossibleGirlRanks> PossibleGirlRank { get => _possibleGirlRanks; }
    public List<Hobbies> BoyHobbies { get => _boyHobbies; }
}

using UnityEngine;

[CreateAssetMenu(fileName = "GirlSO", menuName = "ScriptableObjects/GirlSO", order = 0)]
public class GirlScriptableObject : ScriptableObject
{
    [SerializeField] private GirlRanks _girlRank;
    [SerializeField] private int _girlPrice;
    [SerializeField] private Sprite _girlIcon;
    [SerializeField] private string _girlName;
    [SerializeField] private string _girlEngName;
    [SerializeField] [TextArea] private string _girlDescription;
    [SerializeField] private int _girlAge;
    [SerializeField] private float _girlHeight;
    [SerializeField] private GirlHairColors _girlHairColor;
    [SerializeField] private GirlEyeColors _girlEyeColor;
    [SerializeField] private GirlZodiacSigns _girlZodiacSign;

    private enum GirlHairColors { Red, Green, Blue, Brown, Black, White, Ginger, Violet, Pink, Yellow }
    private enum GirlEyeColors { Red, Green, Blue, Black, Yellow, Pink, Violet }
    private enum GirlZodiacSigns { Aries, Taurus, Gemini, Cancer, Leo, Virgo, Libra, Scorpio, Sagittarius, Capricorn, Aquarius, Pisces}
    private enum GirlRanks { D, C, B, A, S, SS }

    public int GirlRank { get => (int)_girlRank; }
    public int GirlPrice { get => _girlPrice; }
    public Sprite GirlIcon { get => _girlIcon; }
    public string GirlName { get => _girlName; }
    public string GirlEngName { get => _girlEngName; }
    public string GirlDescription { get => _girlDescription; }
    public int GirlAge { get => _girlAge; }
    public float GirlHeight { get => _girlHeight; }
    public string GirlHairColor { get => _girlHairColor.ToString(); }
    public string GirlEyeColor { get => _girlEyeColor.ToString(); }
    public string GirlZodiacSign { get => _girlZodiacSign.ToString(); }
}

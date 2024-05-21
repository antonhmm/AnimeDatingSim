using System.Collections.Generic;

[System.Serializable]
public class SaveData
{
    public int gold;

    public CharacterUnlockMatrix charMatrix = new();

    public List<string> girlCollectionUnlock = new();

    [System.Serializable]
    public class CharacterUnlockMatrix
    {
        public Dictionary<string, bool> unlockCharacterMatrix = new();

        public CharacterUnlockMatrix()
        {
            unlockCharacterMatrix.Add("Amano", false);
            unlockCharacterMatrix.Add("Izuga", false);
            unlockCharacterMatrix.Add("Kuro", false);
            unlockCharacterMatrix.Add("Mihoshi", false);
            unlockCharacterMatrix.Add("Shimo", false);
            unlockCharacterMatrix.Add("Takashi", true);
        }
    }
}
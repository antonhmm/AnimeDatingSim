using System.Collections.Generic;
using UnityEngine;

public class Comparer : MonoBehaviour
{
    public bool ComparePlayerAndGirl(BoysScriptableObject player, GirlScriptableObject girl)
    {
        bool compare = false;

        //Ranks - 0 = D, 1 = C, 2 = B, 3 = A

        if (CompareHairColors(player, girl))
        {
            if (CompareEyeColors(player, girl))
            {
                if (girl.GirlRank == 0)
                {
                    compare = true;
                    return compare;
                }
                else
                {
                    if (player.MinGirlAge <= girl.GirlAge & player.MaxGirlAge >= girl.GirlAge)
                    {
                        if (girl.GirlRank == 1)
                        {
                            compare = true;
                            return compare;
                        }
                        else
                        {
                            if (player.MinGirlHeight <= girl.GirlHeight & player.MaxGirlHeight >= girl.GirlHeight)
                            {
                                if (girl.GirlRank == 2)
                                {
                                    compare = true;
                                    return compare;
                                }
                                else
                                {
                                    if (CompareZodiac(player, girl))
                                    {
                                        if (girl.GirlRank >= 3)
                                        {
                                            compare = true;
                                            return compare;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        return compare;
    }

    private bool CompareHairColors(BoysScriptableObject player, GirlScriptableObject girl)
    {
        bool compare = false;

        for (int i = 0; i < player.LoveHairColor.Count; i++)
        {
            if (player.LoveHairColor[i].ToString() == girl.GirlHairColor)
            {
                compare = true;
            }
        }

        return compare;
    }

    private bool CompareEyeColors(BoysScriptableObject player, GirlScriptableObject girl)
    {
        bool compare = false;

        for (int i = 0; i < player.LoveEyeColor.Count; i++)
        {
            if (player.LoveEyeColor[i].ToString() == girl.GirlEyeColor)
            {
                compare = true;
            }
        }

        return compare;
    }

    private bool CompareZodiac(BoysScriptableObject player, GirlScriptableObject girl)
    {
        bool compare = false;

        for (int i = 0; i < player.LoveZodiacSign.Count; i++)
        {
            if (player.LoveZodiacSign[i].ToString() == girl.GirlZodiacSign)
            {
                compare = true;
            }
        }

        return compare;
    }

    public bool CompareHobbies(BoysScriptableObject player, List<string> girlCurrentHobbies)
    {
        bool compare = false;

        for (int i = 0; i < player.BoyHobbies.Count; i++)
        {
            for (int j = 0; j < girlCurrentHobbies.Count; j++)
            {
                if (player.BoyHobbies[i].ToString() == girlCurrentHobbies[j])
                {
                    compare = true;
                    return compare;
                }
            }
        }
        return compare;
    }
}

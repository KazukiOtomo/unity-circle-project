using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI;

public class SelectRepository : MonoBehaviour
{
    private static readonly int images = 8;
    public Sprite[] attackers = new Sprite[images];
    public Sprite[] defenders = new Sprite[images];
    public static int[] attackers_num = new int[images];
    public static int[] defenders_num = new int[images];

    void Awake()
    {
        for (var i = 0; i < images; i++)
        {
            attackers_num[i] = -1;
            defenders_num[i] = -1;
        }
    }


    /// <summary>
    /// return empty character. 
    /// </summary>
    /// <param name="origin">search origin of loop</param>
    /// <param name="player">player number</param>
    /// <param name="orientation">orientation of search</param>
    /// <returns>image</returns>
    public Sprite GetAttackers(int player,int orientation)
    {
        int n = 0;
        int origin = 0;
        for (var i = 0; i < attackers_num.Length; i++)
        {
            if (attackers_num[i] == player)
            {
                origin = i;
                attackers_num[i] = -1;
                break;
            }
        }
        for (int i = 0; i < images; i++)
        {
            n += orientation;
            if (attackers_num[ExMod(origin + n,images)] == -1)
            {
                attackers_num[ExMod(origin + n,images)] = player;
                break;
            }
        }
        
        return attackers[ExMod(origin + n,images)];
    }

    public Sprite GetDefenders(int player, int orientation)
    {
        int n=0;
        int origin=0;
        for (var i = 0; i < defenders_num.Length; i++)
        {
            if (defenders_num[i] == player)
            {
                origin = i;
                defenders_num[i] = -1;
                break;
            }
        }
        Debug.LogWarning(origin + "was owd -1.");
        for (int i = 0; i < images; i++)
        {
            n += orientation;
            if (defenders_num[ExMod(origin + n,images)] == -1)
            {
                defenders_num[ExMod(origin + n,images)] = player;
                break;
            }
        }

        return defenders[ExMod(origin + n,images)];
    }

    private int ExMod(int n, int d)
    {
        if (n > 0) return n % d;
        while (n < 0)
        {
            n += d;
        }

        return n;
    }
}

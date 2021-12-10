using System.Collections.Generic;
using System.Reflection;
using UnityEngine.UI;

/// <summary>
/// トグルグループ拡張
/// </summary>
public static class ToggleGroupExtensions
{
    /// <summary>
    /// ToggleGroupがもつToggleのFieldInfo
    /// </summary>
    private static FieldInfo _togglesFieldInfo = null;


    static ToggleGroupExtensions()
    {
        _togglesFieldInfo = typeof(ToggleGroup).GetField("m_Toggles", BindingFlags.Static | BindingFlags.Instance | BindingFlags.NonPublic);

        if (_togglesFieldInfo == null)
        {
            throw new System.Exception("Not compatible with the current version of ToggleGroup.");
        }
    }

    /// <summary>
    /// トグル一覧を取得
    /// </summary>
    /// <param name="self"></param>
    /// <returns></returns>
    public static IEnumerable<Toggle> GetToggles(this ToggleGroup self)
    {
        return (_togglesFieldInfo.GetValue(self) as List<Toggle>);
    }
}
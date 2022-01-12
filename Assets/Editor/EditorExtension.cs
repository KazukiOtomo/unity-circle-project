using UnityEngine;
using UnityEditor;


public class EditorExtentsion : EditorWindow
{

    private Vector2 _scroll;


    [MenuItem("Custom/Static Class Window")]
    static void ShowWindow()
    {
    }

    private void Update()
    {
        // 変数が更新された時に即座に表示をアップデート
        Repaint();
    }

}
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class TargetIndicator : MonoBehaviour
{
    [SerializeField]
    private Transform target = default;
    [SerializeField]
    private Image arrow = default;

    private Camera mainCamera;
    private RectTransform rectTransform;

    private void Start() {
        mainCamera = Camera.main;
        rectTransform = GetComponent<RectTransform>();
    }

    private void LateUpdate() {
        var center = 0.5f * new Vector3(Screen.width, Screen.height);

        // （画面中心を原点(0,0)とした）ターゲットのスクリーン座標を求める
        var pos = mainCamera.WorldToScreenPoint(target.position) - center;

        var halfSize = 0.5f * rectTransform.sizeDelta;
        float d = Mathf.Max(
            Mathf.Abs(pos.x / (center.x - halfSize.x)),
            Mathf.Abs(pos.y / (center.y - halfSize.y))
        );

        // ターゲットのスクリーン座標が画面外なら、画面端になるよう調整する
        bool isOffscreen = (pos.z < 0f || d > 1f);
        if (isOffscreen) {
            pos.x /= d;
            pos.y /= d;
        }
        rectTransform.anchoredPosition = pos;
        
        arrow.enabled = isOffscreen;
        if (isOffscreen) {
            arrow.rectTransform.eulerAngles = new Vector3(
                0f, 0f,
                Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg
            );
        }
    }
}
using UnityEngine;

public class Ghost : MonoBehaviour
{
    private void Start()
    {
        var renderer = GetComponentInChildren<SkinnedMeshRenderer>();
        var material = renderer.material;

        // URP Transparent 設定
        material.SetFloat("_Surface", 1); // Transparent
        material.SetFloat("_Blend", 0);   // Alpha blending
        material.SetFloat("_ZWrite", 0);  // 深度書き込みオフ

        // 半透明
        material.SetColor("_BaseColor", new Color(1f, 1f, 1f, 0.5f));

        // キーワードも有効化（重要）
        material.EnableKeyword("_SURFACE_TYPE_TRANSPARENT");
        material.EnableKeyword("_ALPHAPREMULTIPLY_ON");
        material.DisableKeyword("_SURFACE_TYPE_OPAQUE");

        // 描画キュー設定
        material.renderQueue = (int)UnityEngine.Rendering.RenderQueue.Transparent;
    }
}
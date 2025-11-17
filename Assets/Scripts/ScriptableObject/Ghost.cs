using UnityEngine;

public class Ghost : MonoBehaviour
{
    [SerializeField] private float _alpha;

    private void Start()
    {
        var renderer = GetComponentInChildren<SkinnedMeshRenderer>();
        var material = renderer.material;

        // SurfaceType を Transparent
        material.SetFloat("_Surface", 1);

        // ブレンドモード（Alpha）
        material.SetFloat("_Blend", 0);

        // 深度書き込みオフ
        material.SetFloat("_ZWrite", 0);

        // 半透明カラー
        material.SetColor("_BaseColor", new Color(1f,1f,1f,_alpha));

        // RenderQueue を Transparent に
        material.renderQueue = (int)UnityEngine.Rendering.RenderQueue.Transparent;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInEffect : MonoBehaviour
{
    public float fadeInDuration = 2.0f; // 淡入持續時間 (秒)
    private Renderer objectRenderer;
    private Material[] originalMaterials; // 儲存原始材質
    private Material[] fadeMaterials; // 儲存實例化的、用於淡入的材質

    void Start()
    {
        objectRenderer = GetComponent<MeshRenderer>();
        if (objectRenderer == null)
        {
            Debug.LogError("此 GameObject 上找不到 MeshRenderer 元件！");
            enabled = false; // 禁用此腳本
            return;
        }

        // 獲取原始材質列表
        originalMaterials = objectRenderer.sharedMaterials; // 使用 sharedMaterials 避免一開始就實例化

        // 創建材質實例，避免修改原始材質資源
        fadeMaterials = new Material[originalMaterials.Length];
        for (int i = 0; i < originalMaterials.Length; i++)
        {
            // 為每個原始材質創建一個實例
            fadeMaterials[i] = new Material(originalMaterials[i]);

            // **** 重要：確保材質已設為 Fade 或 Transparent 模式 ****
            // 如果你沒有手動在編輯器中設定，可以在這裡用代碼嘗試設定 (但手動設定更可靠)
            //TrySetMaterialToFadeMode(fadeMaterials[i]);

            // 初始化為完全透明
            Color color = fadeMaterials[i].color;
            color.a = 0f;
            fadeMaterials[i].color = color;
        }

        // 將渲染器的材質替換為我們創建的實例
        objectRenderer.materials = fadeMaterials; // 注意這裡是 .materials (複數)

        // 開始淡入協程
        StartCoroutine(FadeIn());
    }

    // 嘗試將 Standard Shader 材質設置為 Fade 模式 (如果尚未設定)
    void TrySetMaterialToFadeMode(Material mat)
    {
        // Standard Shader 使用 _Mode 屬性來控制渲染模式
        // 0: Opaque, 1: Cutout, 2: Fade, 3: Transparent
        if (mat.HasProperty("_Mode") && mat.GetFloat("_Mode") == 0f) // 如果是 Opaque
        {
            mat.SetFloat("_Mode", 2f); // 設為 Fade
            mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            mat.SetInt("_ZWrite", 0);
            mat.DisableKeyword("_ALPHATEST_ON");
            mat.EnableKeyword("_ALPHABLEND_ON");
            mat.DisableKeyword("_ALPHAPREMULTIPLY_ON");
            mat.renderQueue = (int)UnityEngine.Rendering.RenderQueue.Transparent;
        }
        // 注意：對於 URP 或 HDRP 的 Shader，屬性名稱和設定方式會不同
    }


    IEnumerator FadeIn()
    {
        float elapsedTime = 0f;
        bool materialsSet = false; // 確保只設置一次

        while (elapsedTime < fadeInDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Clamp01(elapsedTime / fadeInDuration); // 計算當前 alpha 值 (從 0 到 1)

            // 更新所有材質的 alpha 值
            foreach (Material mat in fadeMaterials)
            {
                if (mat.HasProperty("_Color")) // Standard Shader 的主顏色屬性通常是 _Color
                {
                    Color color = mat.color;
                    color.a = alpha;
                    mat.color = color;
                }
                else
                {
                    // 如果你的 Shader 使用不同的顏色屬性名稱 (例如 _BaseColorMap), 需要修改這裡
                    Debug.LogWarning($"材質 {mat.name} 可能沒有 _Color 屬性，請檢查 Shader。");
                }
            }

            yield return null; // 等待下一幀
        }

        // 確保最終完全不透明
        foreach (Material mat in fadeMaterials)
        {
            if (mat.HasProperty("_Color"))
            {
                Color color = mat.color;
                color.a = 1f;
                mat.color = color;
            }
            // 可選：淡入完成後，如果不需要保持透明模式，可以考慮改回 Opaque 模式以獲得更好的效能
            // TrySetMaterialToOpaqueMode(mat);
        }
    }

    // (可選) 清理創建的材質實例
    void OnDestroy()
    {
        if (fadeMaterials != null)
        {
            foreach (Material mat in fadeMaterials)
            {
                // 銷毀運行時創建的材質實例
                if (mat != null) Destroy(mat);
            }
        }
    }
}
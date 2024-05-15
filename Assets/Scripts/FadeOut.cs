using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    public float fadeDuration = 2.0f; // 物件完全消失所需時間
    private Material material;
    private Color originalColor;

    void Start()
    {
        // 獲取物件的材質
        material = GetComponent<Renderer>().material;
        // 獲取原始顏色
        originalColor = material.color;        
    }

    IEnumerator FadeOutRoutine()
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(originalColor.a, 0, elapsedTime / fadeDuration);
            material.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            yield return null;
        }
        // 最終設置為完全透明
        material.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0);
        // 可以選擇在物件完全消失後進行其他操作，例如銷毀物件
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            // 開始淡出效果
            StartCoroutine(FadeOutRoutine());
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    public float fadeDuration = 2.0f; // ���󧹥������һݮɶ�
    private Material material;
    private Color originalColor;

    void Start()
    {
        // ������󪺧���
        material = GetComponent<Renderer>().material;
        // �����l�C��
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
        // �̲׳]�m�������z��
        material.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0);
        // �i�H��ܦb���󧹥�������i���L�ާ@�A�Ҧp�P������
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            // �}�l�H�X�ĪG
            StartCoroutine(FadeOutRoutine());
        }
    }
}


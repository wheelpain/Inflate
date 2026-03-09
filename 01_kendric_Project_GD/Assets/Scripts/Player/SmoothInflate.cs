using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothInflate : MonoBehaviour
{
    public SkinnedMeshRenderer smr;
    public string shapeName = "Inflate";
    public float duration = 2.0f;
    private int shapeIndex;

    void Start()
    {
        // Find index by name to avoid errors if the list changes
        shapeIndex = smr.sharedMesh.GetBlendShapeIndex(shapeName);
    }

    public void StartInflation()
    {
        StartCoroutine(AnimateInflation(0, 100)); // Inflate to 100%
    }

    IEnumerator AnimateInflation(float start, float end)
    {
        float elapsed = 0;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float currentWeight = Mathf.Lerp(start, end, elapsed / duration);
            smr.SetBlendShapeWeight(shapeIndex, currentWeight);
            yield return null;
        }
        smr.SetBlendShapeWeight(shapeIndex, end);
    }
}

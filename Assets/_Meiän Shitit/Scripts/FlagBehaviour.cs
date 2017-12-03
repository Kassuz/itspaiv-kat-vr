using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagBehaviour : MonoBehaviour {

 public float glitchChance = 0.1f;

    private Renderer hologramRenderer;
    private WaitForSeconds glitchLoopWait = new WaitForSeconds(.1f);
    private WaitForSeconds glitchDuration = new WaitForSeconds(.1f);

    void Awake()
    {
        hologramRenderer = GetComponent<Renderer>();
    }

    IEnumerator Start()
    {
        while (true)
        {
            float glitchTest = Random.Range(0f, 5f);
            if (glitchTest <= glitchChance)
            {
                StartCoroutine(Glitch());
            }
            yield return glitchLoopWait;
        }
    }

    IEnumerator Glitch()
    {
        glitchDuration = new WaitForSeconds(Random.Range(.05f, .25f));
        float strenghtVal = Random.Range(-0.01f, 0.01f);
        hologramRenderer.material.SetFloat("_WaveStrength", Mathf.Clamp01( hologramRenderer.material.GetFloat("_WaveStrength") + strenghtVal));
        hologramRenderer.material.SetFloat("_WaveSpeed", hologramRenderer.material.GetFloat("_WaveSpeed") + strenghtVal);
        // hologramRenderer.material.SetFloat("_Speed", Random.Range(1, 10));
        yield return glitchDuration;
    }
}

using UnityEngine;

public class ColorFader : MonoBehaviour
{
    private Color _color;
    private float _startAlpha;
    private float _fadeTime;

    public void SetStartParams(Color color, float fadeTime)
    {
        _color = color;
        _startAlpha = color.a;
        _fadeTime = fadeTime;
    }

    public Color GetIntermediateColor(float timeToErase)
    {
        return new Color(_color.r, _color.g, _color.b, Mathf.Lerp(_startAlpha, 0, timeToErase / _fadeTime));
    }
}
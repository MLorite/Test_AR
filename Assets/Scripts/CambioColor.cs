using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioColor: MonoBehaviour
{
    public TextMesh _text;
    public Material _material;

   public void PressedButton()
    {
        SetSurfaceColor(_pressedButtonColor);
        SetTextColor(_pressedTextColor);
    }
    public void ReleasedButton()
    {
        SetSurfaceColor(_normalButtonColor);
        SetTextColor(_normalTextColor);
    }
    private void Start()
    {
        SetSurfaceColor(_normalButtonColor);
        SetTextColor(_normalTextColor);
    }
    private void SetSurfaceColor(Color color)
    {
        _material.SetColor("_SurfaceColor", color);
    }
    private void SetTextColor(Color color)
    {
        _text.color = color;
    }

    [SerializeField]
    private Color _normalButtonColor = new Color(0.8f, 0.5f, 0.3f, 1f);
    [SerializeField]
    private Color _pressedButtonColor = new Color(0.42f, 0.26f, 0.16f, 1f);
    [SerializeField]
    private Color _normalTextColor = new Color(0.85f, 0.85f, 085f, 1f);
    [SerializeField]
    private Color _pressedTextColor = new Color(0.15f, 0.15f, 0.15f, 1f);
}

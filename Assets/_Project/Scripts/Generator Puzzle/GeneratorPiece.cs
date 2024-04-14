using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneratorPiece : MonoBehaviour
{
    [SerializeField] private Vector2Int piecePosition;
    [SerializeField] private PieceGrid grid;
    [SerializeField] private bool n, e, s, w;
    [SerializeField] private RectTransform rTransform;
    [SerializeField] private Image image;

    public bool N => n;
    public bool E => e;
    public bool S => s;
    public bool W => w;
    public RectTransform RTransform => rTransform;

    private void Awake()
    {
      grid.pieceGrid[piecePosition.x,piecePosition.y] = this;
    }

    public void SetColorBack()
    {
      image.color = Color.white;
    }

    public void SetColorPowered()
    {
      image.color = Color.green;
    }


}

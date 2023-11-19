using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Range(0f, 1f)] // �������� �� 0 �� 1
    public float AlphaLevel = 1f; // ����������� �������� �����-������, ������� ������ ����� ����� ��������, �� ������� ������� ������, ����� ������������ �������
    private Image btImage; // �������� ����� ������ � Image � �� � Button

    [SerializeField] private GameObject buttonStroke;
    [SerializeField] private Color hoverColor;
    private Image btStImage;
    private Color normalColor;

    private void Start()
    {
        btImage = gameObject.GetComponent<Image>();
        btImage.alphaHitTestMinimumThreshold = AlphaLevel; // �������� alphaHitTestMinimumThreshold ��� ��� � �������� �� ��, ����� ����������� ������� ������������ ������ ���� � ����� ��������, ����� ��� ����� ���������� �������.

        btStImage = buttonStroke.GetComponent<Image>();
        normalColor = btStImage.color;
    }



    public void OnPointerEnter(PointerEventData eventData)
    {
        btStImage.color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        btStImage.color = normalColor;
    }

    public void SetNormalColor()
    {
        btStImage.color = normalColor;
    }
}
using UnityEngine;
using UnityEngine.Events;


public class Player : MonoBehaviour
{
    [SerializeField] public int maxHealth;
    private int _health;
    private int _points;

    public UnityEvent<int> OnSetMaxHealth; // ��������� ������������� ���������� ������
    public static UnityAction<int> OnHealthOver; // ����� ����� �����������

    public UnityEvent<int> OnHealthChange; // ����� ���-�� ������ ���������� (�������� ����� ���������� ������)
    public UnityEvent<int> OnGetPoints; // ����� ���-�� ����� ���������� (�������� ����� ���������� �����)

    public UnityEvent<int> OnGetSlowedBonus; // ����� ������� ����� ���������� (�������� ����� ����������)
    public UnityEvent<int> OnGetX2Bonus; // ����� ������� ����� �2 (�������� ����� �2)

    private void OnEnable()
    {
        GameController.OnStartGame += StartGame;
    }

    private void OnDisable()
    {
        GameController.OnStartGame -= StartGame;
    }

    public void StartGame() // ��������� ������������� ��� ������ ���� (����� ������� ����� �� ������ ������ ����)
    {
        OnSetMaxHealth?.Invoke(maxHealth);
        _health = maxHealth;
    }

    public void TakeDamage(int value)
    {
        _health -= value;
        OnHealthChange?.Invoke(_health);

        if (_health <= 0)
        {
            OnHealthOver?.Invoke(_points);
        }
    }

    public void AddPoints(int points) // ��� ��������� �����
    {
        _points += points;
        OnGetPoints?.Invoke(_points);
    }

    public void AddSlowedBonus(int time) // ��� ��������� ������ ����������
    {
        // ����� ������ ����������

        OnGetSlowedBonus?.Invoke(time);
    }

    public void AddX2Bonus(int time)
    {
        // ����� ������ �������� �����

        OnGetX2Bonus?.Invoke(time);
    }
    public void Update()
    {
        AddPoints(1);
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("dfslskdjflsdk");
        if (other.CompareTag("Bonus"))
        {

        }
        else
        {
            TakeDamage(20);
            Destroy(other.gameObject);
        }
    }
}

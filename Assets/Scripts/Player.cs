using UnityEngine;

public class User
{
    // ���� - ����������,  protected ��� private
    private string _name = "Alex";
    private int _age = 28;

    [SerializeField] // �������� ���� � unity
    private int _count = 0;

    // �������� - ������� �������������� � ������� ��������
    public string Name { get; set; } // ��� ����� ������, ��� ����� ������ !!!!!!--------
    public string NameRead { get; } // ������ ��� ������
    public string NameReadProtected { get; protected set; } // ������ ��� ������

    // ���� "����-��������"
    private int _health = 5;
    public int Health
    {
        get => _health;
        set
        {
            if (value <= 0)
            {
                Debug.Log("�������� ������ 0");
            }
            else
            {
                _health = value;
            }
        }
    }

    // ������ - �������
    public void PrintUser() => Debug.Log($"Name: {_name}\nAge: {_age}");


    // ����������� - �������, ������� ���������� 1 ��� ��� �������� �������
    public User(string name, int age, int health)
    {
        _name = name; // �� ���������, name ����� ���� ������
        _age = age; // �� ���������, ������� ����� ���� �������������
        Health = health; // ���������, �.�. ����� ��������� �������� ��������
    }
}



public class Player : MonoBehaviour
{
    [SerializeField]
    private int count = 0;

    private void Start()
    {
        var user = new User("Ded", 15, 18);
        var user2 = new User("Denis", 20, 50);


        user.PrintUser();
        user2.PrintUser();
    }
}

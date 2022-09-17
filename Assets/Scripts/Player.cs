using UnityEngine;

public class User
{
    // поля - переменные,  protected или private
    private string _name = "Alex";
    private int _age = 28;

    [SerializeField] // связываю поле с unity
    private int _count = 0;

    // свойства - сопособ взаимодействия с другими классами
    public string Name { get; set; } // все могут читать, все могут менять !!!!!!--------
    public string NameRead { get; } // только для чтения
    public string NameReadProtected { get; protected set; } // только для чтения

    // пара "поле-свойство"
    private int _health = 5;
    public int Health
    {
        get => _health;
        set
        {
            if (value <= 0)
            {
                Debug.Log("Здоровье меньше 0");
            }
            else
            {
                _health = value;
            }
        }
    }

    // методы - функции
    public void PrintUser() => Debug.Log($"Name: {_name}\nAge: {_age}");


    // конструктор - функция, которая вызывается 1 раз при создании объекта
    public User(string name, int age, int health)
    {
        _name = name; // не безопасно, name может быть пустым
        _age = age; // не безопасно, возраст может быть отрицательным
        Health = health; // безопасно, т.к. будет проведена проверка значения
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

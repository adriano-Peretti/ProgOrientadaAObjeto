using UnityEngine;

public class SystemManager : MonoBehaviour
{
    private Character _player1;
    private Character _player2;

    void Start()
    {
        var longSword = new Weapon("LongSword", 10);
        var shortSword = new Weapon("ShortSword", 5);

        var armorGold = new Armor("Gold Armor", 30);
        var armorSilver = new Armor("Silver Armor", 20);

        _player1 = new Character("Adriano", 100, longSword, armorSilver);
        _player2 = new Character("Alan", 100, shortSword, armorGold);
    }

    void Update()
    {
        Player1Commands();
        Player2Commands();
    }


    public void Player1Commands()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _player1.Attack(_player2);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _player1.SharpenWeapon();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _player1.UnequipWeapon();
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            _player1.EquipWeapon(new Weapon("Random Weapom", Random.Range(5, 10)));
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            _player1.UnequipArmor();
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            _player1.EquipArmor(new Armor("Random Armor", Random.Range(5, 30)));
        }
    }

    public void Player2Commands()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _player2.Attack(_player1);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            _player2.SharpenWeapon();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            _player2.UnequipWeapon();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            _player2.EquipWeapon(new Weapon("Random Weapom", Random.Range(5, 10)));
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            _player2.UnequipArmor();
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            _player2.EquipArmor(new Armor("Random Armor", Random.Range(5, 30)));
        }
    }
}
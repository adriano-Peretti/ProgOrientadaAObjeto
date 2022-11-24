using UnityEngine;
public class Character
{
    public string Name { get; private set; }
    public int Life { get; private set; }
    public Weapon Weapon { get; private set; }
    public Armor Armor { get; private set; }
    public bool IsAlive { get => Life > 0; }

    public Character(string name, int life, Weapon weapon, Armor armor)
    {
        Name = name;
        Life = life;
        Weapon = weapon;
        Armor = armor;
    }

    //Attack Enemy
    public void Attack(Character enemy)
    {
        if (!CheckAlive()) return;

        if (!enemy.IsAlive)
        {
            Debug.Log($"{enemy.Name} está morto.");
            return;
        }

        if (!HasWeapon()) return;

        Debug.Log($"{Name} atacou {enemy.Name} com sua {Weapon.Name}.");
        enemy.DealDamage(Weapon.Damage);
    }

    //Sharp weapon
    public void SharpenWeapon()
    {
        if (!CheckAlive()) return;

        if (!HasWeapon()) return;

        Debug.Log($"{Name} afiou sua {Weapon.Name}.");
        Weapon.Sharpen();
    }

    //Unequip weapon
    public void UnequipWeapon()
    {
        if (!CheckAlive()) return;

        if (!HasWeapon()) return;

        Debug.Log($"{Name} desequipou sua {Weapon.Name}.");
        Weapon = null;
    }

    //Equip weapon
    public void EquipWeapon(Weapon weapon)
    {
        if (!CheckAlive()) return;

        if (Weapon != null)
        {
            Debug.Log($"{Name} já está com uma {Weapon.Name} equipada.");
        }
        else
        {
            Weapon = weapon;
            Debug.Log($"{Name} equipou uma {Weapon.Name} (Dano: {Weapon.Damage} - Rank: {Weapon.Rank}).");
        }
    }

    //Unequip Armor
    public void UnequipArmor()
    {
        if (!CheckAlive()) return;
        if (!HasArmor()) return;

        Debug.Log($"{Name} retirou sua {Armor.Name}.");
        Armor = null;
    }

    //Equip Armor
    public void EquipArmor(Armor armor)
    {
        if (!CheckAlive()) return;
        if (Armor != null)
        {
            Debug.Log($"{Name} já está com uma {Armor.Name} equipada.");
        }
        else
        {
            Armor = armor;
            Debug.Log($"{Name} equipou uma {Armor.Name} (Proteção: {Armor.Protection} - Rank: {Armor.Rank}).");
        }
    }

    //Deal Damage to the enemy
    private void DealDamage(int ammount)
    {
        if (Armor != null)
        {
            Armor.TakeDamage(ammount);
            // If the armor is broken and there is still damage to be taken
            if (Armor.Protection < 0)
            {
                Life += Armor.Protection;
                UnequipArmor();
            }
            else if (Armor.Protection <= 0)
            {
                UnequipArmor();
            }

            int armorProtect = Armor == null ? 0 : Armor.Protection;

            Debug.Log($"{Name} tomou {ammount} de dano. \n" +
            $"A vida atual {Name} é de: {Life}" +
            $"E sua armadura atual é de: {armorProtect}");
        }
        else
        {
            Life -= ammount;
            Debug.Log($"{Name} tomou {ammount} de dano. \n" +
            $"A vida atual {Name} é de: {Life}");
        }

        CheckAlive();
    }

    //Check if the player is still alive
    private bool CheckAlive()
    {
        if (!IsAlive)
        {
            Debug.Log($"{Name} já está morto.");
        }

        return IsAlive;
    }

    //Check if has a weapon equiped
    private bool HasWeapon()
    {
        if (Weapon == null)
        {
            Debug.Log($"{Name} não está com nenhuma arma equipada.");
        }

        return Weapon != null;
    }

    //Check if has a armor equiped
    private bool HasArmor()
    {
        if (Armor == null)
        {
            Debug.Log($"{Name} não está com nenhuma armadura equipada.");
        }

        return Armor != null;
    }
}
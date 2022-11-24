public class Armor
{
    public string Name { get; private set; }
    public int Protection { get; private set; }
    public char Rank { get; private set; }

    public Armor(string name, int protection)
    {
        Name = name;
        Protection = protection;
        Rank = GetRank(protection);
    }

    public void TakeDamage(int damage)
    {
        Protection -= damage;
    }

    public static char GetRank(int damage)
    {
        if (damage >= 30)
        {
            return 'S';
        }
        else if (damage >= 20)
        {
            return 'A';
        }
        else if (damage >= 10)
        {
            return 'B';
        }

        return 'C';
    }
}
using System;


public interface IInventory
{
    void Equip();
}


public abstract class Hero
{
    public abstract void Display();
}


public class Warrior : Hero
{
    public override void Display()
    {
        Console.WriteLine("Воїн");
    }
}

public class Mage : Hero
{
    public override void Display()
    {
        Console.WriteLine("Маг");
    }
}

public class Paladin : Hero
{
    public override void Display()
    {
        Console.WriteLine("Паладин");
    }
}


public class Weapon : IInventory
{
    public void Equip()
    {
        Console.WriteLine("Озброюємося зброєю");
    }
}

public class Armor : IInventory
{
    public void Equip()
    {
        Console.WriteLine("Одягаємо броню");
    }
}

public class Artifact : IInventory
{
    public void Equip()
    {
        Console.WriteLine("Одягаємо артефакт");
    }
}


public class MultiInventory : IInventory
{
    private readonly IInventory _inventory1;
    private readonly IInventory _inventory2;

    public MultiInventory(IInventory inventory1, IInventory inventory2)
    {
        _inventory1 = inventory1;
        _inventory2 = inventory2;
    }

    public void Equip()
    {
        _inventory1.Equip();
        _inventory2.Equip();
    }
}

class Program
{
    static void Main(string[] args)
    {
        
        Hero warrior = new Warrior();
        Hero mage = new Mage();
        Hero paladin = new Paladin();

        
        IInventory weapon = new Weapon();
        IInventory armor = new Armor();
        IInventory artifact = new Artifact();

       
        Console.WriteLine("Екіпіруємо Воїна:");
        weapon.Equip();
        armor.Equip();
        Console.WriteLine();

        Console.WriteLine("Екіпіруємо Мага:");
        weapon.Equip();
        artifact.Equip();
        Console.WriteLine();

        Console.WriteLine("Екіпіруємо Паладина:");
        armor.Equip();
        artifact.Equip();
        Console.WriteLine();

       
        Console.WriteLine("Воїн екіпірує кілька предметів:");
        IInventory multiInventory1 = new MultiInventory(weapon, armor);
        multiInventory1.Equip();
        Console.WriteLine();

        Console.WriteLine("Маг екіпірує кілька предметів:");
        IInventory multiInventory2 = new MultiInventory(weapon, artifact);
        multiInventory2.Equip();
        Console.WriteLine();

        Console.WriteLine("Паладин екіпірує кілька предметів:");
        IInventory multiInventory3 = new MultiInventory(armor, artifact);
        multiInventory3.Equip();
    }
}

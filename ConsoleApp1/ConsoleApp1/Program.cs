
Temp t = new Temp();

Console.WriteLine(t.num);

class Temp
{

    public int num = 2;

    public Temp() { num++; }

    ~Temp() { num++; }

}


//Лабораторная 11 Вариант 22

try
{
    Console.Write("Введите фамилию: ");
    string lastName = Console.ReadLine()!;
    Console.Write("Введите самооценку: ");
    double selfEsteem = double.Parse(Console.ReadLine()!);
    Console.Write("Введите оценку другими людьми: ");
    double gradePeople = double.Parse(Console.ReadLine()!);
    Console.Write("Введите оценку потомками: ");
    double gradeDescendants = double.Parse(Console.ReadLine()!);

    Leader leader = new Leader(lastName, selfEsteem, gradePeople);

    Console.WriteLine();
    Console.WriteLine("Объекты класса 1 уровня:");
    Console.WriteLine($"Q = {leader.Calc()}");
    leader.Print();
    Console.WriteLine();
    BestLeader bestLeader = new BestLeader(lastName, selfEsteem, gradePeople, gradeDescendants);

    Console.WriteLine("Объекты класса 2 уровня:");
    Console.WriteLine($"Q = {bestLeader.Calc()}");
    bestLeader.Print();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
class Leader
{
    protected string lastName;
    protected double selfEsteem;
    protected double gradePeople;

    public Leader(string lastName, double selfEsteem, double gradePeople)
    {
        this.lastName = lastName;
        this.selfEsteem = selfEsteem;
        this.gradePeople = gradePeople;
    }
    public virtual double Calc()
    {
        return gradePeople / selfEsteem;
    }
    public virtual void Print()
    {
        Console.WriteLine($"Фамилия: {lastName}, самооценка: {selfEsteem}, самооценка людьми: {gradePeople}");
    }
}
class BestLeader : Leader
{
    protected double gradeDescendants;
    public BestLeader(string lastName, double selfEsteem, double gradePeople, double gradeDescendants) : base(lastName, selfEsteem, gradePeople)
    {
        this.gradeDescendants = gradeDescendants;
    }
    public override double Calc()
    {
        double baseCalc = base.Calc();
        return 0.3 * baseCalc + 0.7 * gradeDescendants;
    }
    public override void Print()
    {
        base.Print();
        Console.WriteLine($"Оценка потомками: {gradeDescendants}");
    }
}
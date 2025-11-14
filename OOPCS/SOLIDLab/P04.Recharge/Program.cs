namespace P04.Recharge
{
    class Program
    {
        static void Main()
        {
            var robot = new Robot("id1",100);
            robot.CurrentPower = 20;
            robot.Work(5);

            robot.Recharge();
        }
    }
}

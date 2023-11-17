namespace TeamDataDragons
{
    internal class Program
    {
        static void Main(string[] args)
        {

            App appStart = new App();
            appStart.LogInPage();


            Bank bank = new Bank();

            // Lägg till nya konton
            bank.AddNewAccount(1000);
            bank.AddNewAccount(500);

            // Gör några överföringar och loggar resultaten
            bank.accounts[0].TransferMoney(bank.accounts[1], 200);
            bank.TransferLog();

            Console.ReadLine();



        }
    }
}
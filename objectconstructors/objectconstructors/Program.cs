

public class CurrencyConverter
{
    // Example conversion rates (These are updated)
    private const double USDToEURRate = 0.95; // 1 USD to EUR
    private const double EURToUSDRate = 1.05; // 1 EUR to USD

    private const double USDToSEKRate = 10.98; // 1 USD to SEK
    private const double SEKToUSDRate = 0.091; // 1 SEK to USD

    private const double EURToSEKRate = 11.52; // 1 EUR to SEK
    private const double SEKToEURRate = 0.087; // 1 SEK to EUR

    public double Convert(double amount, Currency fromCurrency, Currency toCurrency)
    {
        if (fromCurrency == toCurrency)
        {
            return amount; // No conversion needed
        }

        // Convert to USD as an intermediary
        double amountInUSD = amount;

        switch (fromCurrency)
        {
            case Currency.EUR:
                amountInUSD /= EURToUSDRate;
                break;
            case Currency.SEK:
                amountInUSD /= SEKToUSDRate;
                break;
        }

        // Now convert from USD to the target currency
        switch (toCurrency)
        {
            case Currency.EUR:
                return amountInUSD * USDToEURRate;
            case Currency.SEK:
                return amountInUSD * USDToSEKRate;
            default: // Assuming target is USD
                return amountInUSD;
        }
    }
}
public enum Currency
{
    USD,
    EUR,
    SEK
}


 
namespace CurrencyConverterApp
{
    class Program
    {
        static void Main(string[] args)
        {
            CurrencyConverter converter = new CurrencyConverter();

            Console.WriteLine("Currency Converter");
            Console.Write("Enter amount: ");
            double amount = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Select from currency (0: USD, 1: EUR, 2: SEK): ");
            Currency fromCurrency = (Currency)Enum.Parse(typeof(Currency), Console.ReadLine());

            Console.WriteLine("Select to currency (0: USD, 1: EUR, 2: SEK): ");
            Currency toCurrency = (Currency)Enum.Parse(typeof(Currency), Console.ReadLine());

            double convertedAmount = converter.Convert(amount, fromCurrency, toCurrency);
            Console.WriteLine($"Converted Amount: {convertedAmount}");
        }
    }

}
public class Account
{
    public int Id { get; set; }        // Account ID
    public decimal Balance { get; set; } // Account Balance

    // Constructor
    public Account(int id, decimal initialBalance)
    {
        Id = id;
        Balance = initialBalance;
    }

    // Method to deposit money
    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Deposit amount must be positive.");
        }
        Balance += amount;
    }

    // Method to withdraw money
    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Withdrawal amount must be positive.");
        }
        if (amount > Balance)
        {
            throw new InvalidOperationException("Insufficient funds.");
        }
        Balance -= amount;
    }

    // Method to get account details
    public override string ToString()
    {
        return $"Account ID: {Id}, Balance: {Balance:C}";
    }
}

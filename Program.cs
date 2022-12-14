using System;

public class cardHolder
{
    String cardNum;
    int pin;
    String firstName;
    String lastName;
    double balance;

    public cardHolder(String cardNum, int pin, String firstName, String lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    public String getNum()
    {
        return cardNum;
    }

    public int getPin()
    {
        return pin;
    }

    public String getfirstName()
    {
        return firstName;
    }

    public String getlastName()
    {
        return lastName;
    }

    public double getBalance()
    {
        return balance;
    }

    public void setNum(String newCardNum)
    {
        cardNum = newCardNum;
    }

    public void setPin(int newPin)
    {
        pin = newPin;
    }

    public void setFirstName(String newFirstName)
    {
        firstName = newFirstName;
    }

    public void setLastName(String newLastName)
    {
        lastName = newLastName;
    }

    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }

    public static void Main(String[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose from one of the following options...");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show balance");
            Console.WriteLine("4. Exit");
        }

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much money would you like to deposit? ");
            double deposit = double.Parse(Console.ReadLine());
            currentUser.setBalance(currentUser.getBalance() + deposit);
            Console.WriteLine("Thank you for your deposit your new balance is: " + currentUser.getBalance());
        }

        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much money would you like to withdraw? ");
            double withdrawal = double.Parse(Console.ReadLine());
            // check if user has enough money
            if(currentUser.getBalance() < withdrawal)
            {
                Console.WriteLine("Insifficient funds");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdrawal);
                Console.WriteLine("Your withdrawal is complete, your new balance is: " + currentUser.getBalance());
            }
        }

        void balance(cardHolder currentUser)
        {
            Console.WriteLine("Current balance: " + currentUser.getBalance());
        }

        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("36747873279278932", 1234, "Chandler", "James", 2091.00));
        cardHolders.Add(new cardHolder("36764573279278932", 5678, "Martin", "Gina", 91.00));
        cardHolders.Add(new cardHolder("53247873279278932", 9123, "Dwayne", "Johnson", 20.00));
        cardHolders.Add(new cardHolder("42447873279278932", 4567, "LeBronn", "James", 101.00));
        cardHolders.Add(new cardHolder("90647873279278932", 8913, "Dak", "Prescott", 2090.00));

        // Prompt user
        Console.WriteLine("Welcome to the ATM");
        Console.WriteLine("Please insert debt card");
        String debitCardNum = " ";
        cardHolder currentUser;

        while(true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if(currentUser != null) { break; }
                else { Console.WriteLine("Card not recongized please try again"); }
            }
            catch { Console.WriteLine("Card not recongized please try again"); }
        }

        Console.WriteLine("Please enter yout pin: ");
        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                if (currentUser.getPin() == userPin) { break; }
                else { Console.WriteLine("Incorrect pin please try again"); }
            }
            catch { Console.WriteLine("Incorrect pin please try again"); }
        }

        Console.WriteLine("Welcome " + currentUser.getfirstName());
        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch { }
            if(option == 1) { deposit(currentUser);  }
            else if(option == 2) { withdraw(currentUser);  }
            else if(option == 3) { balance(currentUser);  }
            else if(option == 4) { break; }
            else { option = 0; }
        }
        while (option != 4);
        Console.WriteLine("Thank you for banking with us, have a nice day!");
    }
}

using System;

public class cardHolder
{
    String cardNum;
    int pin;
    String firstName;
    String lastName;
    double balance;

    public cardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
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
    public String getFirstName()
    {
        return firstName;
    }
     public String getLastName()
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
            System.Console.WriteLine("Please choose from one of the following options..");
            System.Console.WriteLine("1. Deposit");
            System.Console.WriteLine("2. Withdraw");
            System.Console.WriteLine("3. Show Balance");
            System.Console.WriteLine("4. Exit");

        }

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to deposit? ");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setBalance(currentUser.getBalance() + deposit);    
            Console.WriteLine("Thank you for your $$. Your new balance is: " + currentUser.getBalance());   

        }

        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to withdraw: ");
            double withdrawal = Double.Parse(Console.ReadLine());
            if(currentUser.getBalance() < withdrawal)
            {
                Console.WriteLine("Insufficient balance :");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance()-withdrawal);
                Console.WriteLine("You're good to go! Thank you");
            }


        }

        void balance(cardHolder currentUser)
        {
            Console.WriteLine("Current balance: " + currentUser.getBalance());
        }

        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("1368075367987765", 1234, "Rano", "Jaan", 280.00));
        cardHolders.Add(new cardHolder("3468075367987765", 5657, "mathu", "san", 455.00));
        cardHolders.Add(new cardHolder("1368067367987765", 3545, "vithu", "san", 760.60));
        cardHolders.Add(new cardHolder("0987545367987765", 1824, "antony", "wade", 1280.32));
        cardHolders.Add(new cardHolder("4568075367987765", 5634, "Ann", "Mary", 580.00));

        //prompt user
        Console.WriteLine("Welcome to SimpleATM");
        Console.WriteLine("Please insert your debit card: ");
        String debitCardNum = "";
        cardHolder currentUser;

        while(true)
        {
          try
            {
                debitCardNum = Console.ReadLine();
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if (currentUser != null) { break; }
                else { Console.WriteLine("card not recognized. Please try again"); }
            }
            catch { Console.WriteLine("card not recognized. Please try again"); }
        }

        Console.WriteLine("Please enter your pin: ");
        int userPin = 0;
        while (true)
        {
            try
            {
                userPin =int.Parse(Console.ReadLine());
                if (currentUser.getPin() == userPin) { break; }
                else { Console.WriteLine("Incorrect pin. Please try again"); }
            }
            catch { Console.WriteLine("Incorrect pin. Please try again"); }
        }

        Console.WriteLine("Welcome " + currentUser.getFirstName());
        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch { }
            if (option == 1) { deposit(currentUser); }
            else if (option == 2) { withdraw(currentUser); }
            else if (option == 3) { balance(currentUser); }
            else if (option == 4) { break; }
            else { option = 0; }
        }
        while (option != 4);
        Console.WriteLine("Thank you! have a nice day");

    }




}



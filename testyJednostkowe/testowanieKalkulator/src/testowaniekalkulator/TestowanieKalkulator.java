package testowaniekalkulator;

import java.util.Scanner;


public class TestowanieKalkulator {

    public static double addition(double firstNumber, double secondNumber)
    {
        return firstNumber + secondNumber;
    }
    
    public static double subtraction(double firstNumber, double secondNumber)
    {
        return firstNumber - secondNumber;
    }
    
    public static double multiplication(double firstNumber, double secondNumber)
    {
        return firstNumber * secondNumber;
    }
    
    public static double division(double firstNumber, double secondNumber)
    {
        return firstNumber / secondNumber;
    }
    
    public static double percentages(double firstNumber, double secondNumber)
    {
        if(secondNumber == 0)
        {
            return 0;
        }
        else
        {
            secondNumber = secondNumber / 100;
            return firstNumber * secondNumber;
        }
    }
    
    public static void printMenu()
    {
        System.out.println("1. Dodawanie");
        System.out.println("2. Odejmowanie");
        System.out.println("3. Mnożenie");
        System.out.println("4. Dzielenie");
        System.out.println("5. Procenty z liczby");
    }
    
    public static void menu(int number,double firstNumber,double secondNumber)
    {
        switch(number)
        {
            case 1:
                System.out.println("Wynik dodawania: "+addition(firstNumber,secondNumber));
                break;
            case 2:
                System.out.println("Wynik odejmowania: "+subtraction(firstNumber,secondNumber));
                break;
            case 3:
                System.out.println("Wynik mnożenia: "+multiplication(firstNumber,secondNumber));
                break;
            case 4:
                System.out.println("Wynik dzielenia: "+division(firstNumber,secondNumber));
                break;
            case 5:
                System.out.println("Wynik procentow z liczby: "+percentages(firstNumber,secondNumber));
                break;
        }
        
                System.out.println("Zakończyć? tak/nie");
    }
    
    public static double getNumber(String name)
    {
        System.out.println("Podaj " + name);
        Scanner scan = new Scanner(System.in);
        return scan.nextDouble();
    }
    
    public static boolean ifEnd(String choice)
    {
        Scanner scan = new Scanner(System.in);
        
        while(true)
        {
            if(choice.equals("tak"))
                return true;
            else if(choice.equals("nie"))
                return false;
            else
            {
                System.out.println("Zakończyć? tak/nie");
                choice = scan.next();
            }
        }
    }
    
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        
        do
        {
            printMenu();
            menu(scan.nextInt(),getNumber("pierwsza liczba"),getNumber("druga liczba"));
        }while(ifEnd(scan.next()) == false);
    }
    
}

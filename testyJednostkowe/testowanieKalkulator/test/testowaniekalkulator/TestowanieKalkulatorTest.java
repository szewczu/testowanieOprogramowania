package testowaniekalkulator;

import com.oracle.jrockit.jfr.ValueDefinition;
import java.util.Scanner;
import org.junit.After;
import org.junit.AfterClass;
import org.junit.Before;
import org.junit.BeforeClass;
import org.junit.Test;
import static org.junit.Assert.*;
import org.junit.runners.Parameterized;

public class TestowanieKalkulatorTest {
    TestowanieKalkulator testKalkulator = new TestowanieKalkulator();
    
    @Test
    public void testMain() {
    }
    
    @Test
    public void additionTest()
    {
        double firstNumber = 123;
        double secondNumber = 321;
        
        assertEquals(firstNumber + secondNumber, testKalkulator.addition(firstNumber, secondNumber),0);
    }

    @Test
    public void subtractionTest()
    {
        double firstNumber = 2;
        double secondNumber = 2;
        
        assertEquals(firstNumber - secondNumber, testKalkulator.subtraction(firstNumber, secondNumber),0);
    }
    
    @Test
    public void multiplicationTest()
    {
        double firstNumber = 2;
        double secondNumber = 2;
        
        assertEquals(firstNumber * secondNumber, testKalkulator.multiplication(firstNumber, secondNumber),0);
    }
    
    @Test
    public void divisionTest()
    {
        double firstNumber = 2;
        double secondNumber = 2;
        
        assertEquals(firstNumber / secondNumber, testKalkulator.division(firstNumber, secondNumber),0);
    }
    
    @Test
    public void divisionBy0Test()
    {
        double firstNumber = 2;
        double secondNumber = 0;
        double result = Double.POSITIVE_INFINITY;
        
        assertEquals(result, testKalkulator.division(firstNumber, secondNumber),0);
    }
    
    @Test
    public void percentagesBy0Test()
    {
        double firstNumber = 100;
        double secondNumber = 0;
        double result = 0;
        
        assertEquals(result, testKalkulator.percentages(firstNumber, secondNumber),0);
    }
    
    @Test
    public void percentagesTest()
    {
        double firstNumber = 100;
        double secondNumber = 10;
        double result = 10;
        
        assertEquals(result, testKalkulator.percentages(firstNumber, secondNumber),0);
    }
    
    @Test
    public void ifEndTrueTest()
    {
        String choice = "tak";
        assertTrue(TestowanieKalkulator.ifEnd(choice));
    }
    
    @Test
    public void ifEndFalseTest()
    {
        String choice = "nie";
        assertFalse(TestowanieKalkulator.ifEnd(choice));
    }
    
//    @Test
//    public void ifEndFalse2Test()
//    {
//        String result = "Zakończyć? tak/nie\n";
//        assertEquals(result,TestowanieKalkulator.ifEnd("s"));
//    }
    
    @Test
    public void menuCaseTest()
    {
        int choice1 = 1;
        int choice2 = 2;
        int choice3 = 3;
        int choice4 = 4;
        int choice5 = 5;
        int choice6 = 6;
        double firstNumber = 100;
        double secondNumber = 10;
        
        testKalkulator.menu(choice1,firstNumber,secondNumber);
        testKalkulator.menu(choice2,firstNumber,secondNumber);
        testKalkulator.menu(choice3,firstNumber,secondNumber);
        testKalkulator.menu(choice4,firstNumber,secondNumber);
        testKalkulator.menu(choice5,firstNumber,secondNumber);
        testKalkulator.menu(choice6,firstNumber,secondNumber);
        
    }
    
    @Test
    public void printMenuTest()
    {
        testKalkulator.printMenu();
    }
    
    @Test
    public void getNumber()
    {
        testKalkulator.getNumber("");
    }
}

import java.util.Scanner;
import java.math.*;

public class ElectronicWatch 
{

	public static void main(String[] args) 
	{
		System.out.println("Enter number of seconds: "); 
		Scanner scanner = new Scanner(System.in); 
		int seconds = scanner.nextInt();
		System.out.println("Seconds: " + seconds); 
		
		int hours = seconds / 3600;
		
		double minutes = ((double)seconds / 3600) % 1;
		
		double second = ((double)minutes*60) % 1;
		
		System.out.println((hours == 24 ? "00" : hours) + ":" + ((int)(minutes*60) == 0 ? "00" : (int)(minutes*60)) 
							+ ":" + (((int)(Math.round(second*60)) == 60 || (int)(Math.round(second*60)) == 0)  ? "00" : (int)(Math.round(second*60)))); 
	}

}

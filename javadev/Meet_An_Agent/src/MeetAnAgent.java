import java.util.Scanner;

public class MeetAnAgent 
{
	public final static int PASSWORD = 999;
	
	public static void main(String[] args) 
	{
		System.out.print("Enter secret code: ");
		Scanner scanner = new Scanner(System.in);
		int inputPassword = scanner.nextInt();
		if (PASSWORD == inputPassword) System.out.print("Welcome, Agent");
		else System.out.print("Access denied");
	}

}

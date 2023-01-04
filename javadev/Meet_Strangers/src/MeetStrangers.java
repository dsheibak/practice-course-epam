import java.util.Scanner;

public class MeetStrangers {

	public static void main(String[] args) 
	{
		System.out.print("Enter number of strangers to meet: ");
		Scanner scanner = new Scanner(System.in);
		int numberOfStrangers = scanner.nextInt();
		
		if (numberOfStrangers == 0) System.out.print("Oh, it looks like there is no one here!"); 
		else if (numberOfStrangers < 0) System.out.print("Seriously? Why so negative?");
		else
		{
			String Names[] = new String[numberOfStrangers];
			
			System.out.println("Enter names: ");
			
			scanner.nextLine();
			
			for (int i = 0; i < numberOfStrangers; i++)
			{
				Names[i] = scanner.nextLine();
			}
			
			for (int i = 0; i < numberOfStrangers; i++)
			{
				System.out.println("Hello, " + Names[i]);
			}
			
		}
	
		
	}

}

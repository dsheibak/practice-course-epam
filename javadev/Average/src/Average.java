import java.util.ArrayList;
import java.util.Scanner;

public class Average 
{

	public static void main(String[] args) 
	{
		System.out.println("Enter number sequence: "); 
		Scanner scanner = new Scanner(System.in); 
		int currentValue, averageValue = 0;
		ArrayList<Integer> arrayList = new ArrayList<Integer>();
		
		while (true)
		{
			currentValue = scanner.nextInt(); 		
			if (currentValue == 0) break;
			
			arrayList.add(currentValue);
		}
		
		if (arrayList.size() == 0)
		{
			System.out.println("The sequence is empty"); 
			return;
		}
		
		for (Integer s : arrayList) 
		{
			   System.out.println(s);
			   averageValue += s;
		}
		
		System.out.println("Average: " + averageValue/arrayList.size()); 
	}

}

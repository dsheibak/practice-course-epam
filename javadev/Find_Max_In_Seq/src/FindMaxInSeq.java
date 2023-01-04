import java.util.*;

public class FindMaxInSeq {

	public static void main(String[] args) 
	{
		System.out.println("Enter number sequence: "); 
		Scanner scanner = new Scanner(System.in); 
		float currentValue;
		ArrayList<Float> arrayList = new ArrayList<Float>();
		
		while (true)
		{
			currentValue = scanner.nextFloat(); 		
			if (currentValue == 0) break;
			
			arrayList.add(currentValue);
		}
		
		for (Float s : arrayList) 
		{
			   System.out.println(s);
		}
		
		float maxValue = arrayList.get(0);
		for (Float s : arrayList) 
		{
			   if (s >= maxValue) maxValue = s;
		}
		System.out.println("Maximum: " + maxValue);
	}

}

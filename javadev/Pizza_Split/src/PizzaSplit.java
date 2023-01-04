import java.util.Scanner;

public class PizzaSplit 
{

	public static void main(String[] args) 
	{
		
		Scanner scanner = new Scanner(System.in);
		
        int people = scanner.nextInt();
        int pizzaPieces = scanner.nextInt();
        
        if (people <=0 || pizzaPieces<=0) return;
        
        int pizza = 1;
        int coutPizzaPieces = pizzaPieces;

        while(people > 0) 
        {
        	pizzaPieces = coutPizzaPieces;
        	pizzaPieces *= pizza;
        	
            if (pizzaPieces % people == 0) break;
            
            pizza++;
        }
        
        System.out.println(pizza);
        
        scanner.close();
	}

}

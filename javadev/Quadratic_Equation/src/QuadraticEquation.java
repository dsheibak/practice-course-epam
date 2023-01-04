import java.util.Scanner;
import static java.lang.Math.sqrt;
import static java.lang.Math.pow;

public class QuadraticEquation 
{
	//1, -8, 12 => корни 2 и 6
	//1, -6, 9 => один корень 3
	//5, 3, 7 => нет корней
	
	public static void main(String[] args) 
	{
		Scanner scanner = new Scanner(System.in);
        double a = scanner.nextDouble();
        double b = scanner.nextDouble();
        double c = scanner.nextDouble();

        double D = Math.pow(b, 2) - 4 * a * c;
        
        if (D > 0) 
        {
            double x1 = (-b - Math.sqrt(D)) / (2 * a);
            double x2 = (-b + Math.sqrt(D)) / (2 * a);
            System.out.println(x1 + " " + x2);
        }
        else if (D == 0) 
        {
            double x = -b / (2 * a);
            System.out.println(x);
        }
        else 
        {
            System.out.println("Quadratic equation has no roots");
        }
	}

}

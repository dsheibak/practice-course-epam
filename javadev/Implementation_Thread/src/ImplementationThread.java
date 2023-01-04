import java.util.Scanner;

public class ImplementationThread {

	public static void main(String[] args) 
	{
		Thread mainThread = Thread.currentThread();
		System.out.println("Current thread: " + mainThread.getName());
		
		mainThread.setName("CatThread");
		System.out.println("\nNew tread name: " + mainThread.getName());
		
		System.out.println("Current thread: " + mainThread); //имя - приоритет - имя группы
		
		System.out.println("Main thread started...");
	   for(int i=1; i < 6; i++)
	       new JThread("JThread " + i).start();
	    System.out.println("Main thread finished...");
		
		System.out.println("Main thread started...");
	    JThread t= new JThread("JThread ");
	    t.start();
	    try
	    {
	        t.join(); //поток main будет ожидать завершения потока t
	    }
	    catch(InterruptedException e)
	    {
	     
	        System.out.printf("%s has been interrupted", t.getName());
	    }
	    System.out.println("Main thread finished...");
	    
	}

}

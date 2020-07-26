package exceptions;

public class Example {

    public static void main(String [] args) {
        try {String[] arr = { "A" , "B" , "C" , "D" };
            //convert("" );
        }
        catch (IllegalArgumentException e) {
            e.printStackTrace();
        }
        catch (RuntimeException e) { //Line 14
            System.out .println(e.getMessage()); //Line 15
        } //Line 16
        catch (Exception e) {
            e.printStackTrace();
        }
    }

}

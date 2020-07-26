package reflection;

public class Service {

    private final Feature service;

    public Service() {
        this.service = new Feature();
    }

    public void run() {
        System.out.println(getClass().getName());
        service.execute();
    }

}

import java.util.Arrays;
import java.util.Comparator;

public class SearchFunction {

    public static Product linearSearch(Product[] products, String name) {

        for (Product p : products) {
            if (p.productName.equalsIgnoreCase(name)) {
                return p;
            }
        }
        return null;
    }

    public static Product binarySearch(Product[] products, String name) {

        int left = 0;
        int right = products.length - 1;

        while (left <= right) {

            int mid = (left + right) / 2;

            int result =
                    products[mid].productName.compareToIgnoreCase(name);

            if (result == 0)
                return products[mid];

            if (result < 0)
                left = mid + 1;
            else
                right = mid - 1;
        }

        return null;
    }

    public static void main(String[] args) {

        Product[] products = {
                new Product(101, "Laptop", "Electronics"),
                new Product(102, "Phone", "Electronics"),
                new Product(103, "Shoes", "Fashion"),
                new Product(104, "Watch", "Accessories")
        };

        Product found = linearSearch(products, "Phone");

        if (found != null)
            System.out.println("Linear Search Found : " + found.productName);

        Arrays.sort(products,
                Comparator.comparing(p -> p.productName));

        found = binarySearch(products, "Watch");

        if (found != null)
            System.out.println("Binary Search Found : " + found.productName);
    }
}
public class FinancialForecast {

    public static double futureValue(double amount,
                                     double growthRate,
                                     int years) {

        if (years == 0) {
            return amount;
        }

        return futureValue(
                amount * (1 + growthRate),
                growthRate,
                years - 1);
    }

    public static void main(String[] args) {

        double currentValue = 10000;
        double growthRate = 0.10;
        int years = 5;

        double result = futureValue(
                currentValue,
                growthRate,
                years);

        System.out.println(
                "Future Value after "
                + years
                + " years = "
                + result);
    }
}
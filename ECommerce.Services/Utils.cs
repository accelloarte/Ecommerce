namespace ECommerce.Services;

public static class Utils
{
    public static int GetTotalPages(int total, int rows)
    {
        if (total < 0) return 0;

        var totalPages = total / rows;
        if (total % rows > 0)
            totalPages++;

        return totalPages;
    }
}
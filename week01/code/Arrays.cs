public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // To get the numbers of multiples you define an empty fixed array the size of the length variable
        // You then create a for loop that runs/loops the amount of times equal to the length variable.
        // Your iterator varaible (e.g. i) will start at 0.
        // The incrementer value plus one (e.g. i + 1) will accurately represent the number of iterated loops. 
        // During the loop you will multiply the number by the index/counter (e.g. i) of the loop.
        // You take the resulting number and push/add/assign it the array that stores your multiples.
        // (e.g. multiples[i] = multipleResult)
        // At the end of the entire for loop you will return the array of multiples as your result.

        double[] multiples = new double[length];

        for (int i = 0; i < length; i++)
            multiples[i] = number * (i + 1);

        return multiples; // replace this return statement with your own
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // The amount should be reassigned into a remainder of the length. (OPTIONAL)
        // (This handles cases where amount is greater than length)
        // First get the length/count of the data variable and minus it by the amount variable.
        // Use the result as the index of where to get the data variable/list into two parts.
        // Append/combine the two parts of the list with the ordering of the parts reversed.
        // (The first/beginning part of the list becomes the end and the second becomes the beginning.)
        // This result should be assigned to and permanently modify the data variable/list.

        int length = data.Count;
        amount %= length;

        int index = length - amount;

        // Concat makes it a generic enumerable, so we make sure its back to a list with ToList().
        List<int> rotatedData = data.Skip(index)
                                    .Concat(data.Take(index))
                                    .ToList();

        data.Clear();
        data.AddRange(rotatedData);
    }
}

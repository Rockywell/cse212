using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Dequeue an entire queue of mulitple items in different positions with matching priorities.
    // Expected Result: The whole queue should dequeue in the order of highest priority to lowest priority and also order of first to last in the queue.
    // Defect(s) Found: Priority queue doesn't have a Length property, which makes the test very hard to debug.
    // this also makes PriorityQueue depend on the internal/private variable queue count.
    // Assert.AreEqual failed. Expected: Second-VIP and got First-VIP
    // this is probably because PriorityQueue.Dequeue() doesn't actually remove the item from the queue.
    // Assert.AreEqual failed. Expected: Second-VIP and got Second-Regular
    // this is probably because the Dequeue() method excludes the last item in the queue when searching for the highest priority item to remove.
    // Assert.AreEqual failed. Expected: First-VIP and got Second-VIP
    // this is probably because the Dequeue() method removes the last item with the highest priority, instead of the first.
    // This test now passes with no issues.

    public void TestPriorityQueue_DequeueOrdering()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("First-Regular", 5);
        priorityQueue.Enqueue("First-VIP", 10);
        priorityQueue.Enqueue("Second-Regular", 5);
        priorityQueue.Enqueue("Second-VIP", 10);

        string[] expectedResult = ["First-VIP", "Second-VIP", "First-Regular", "Second-Regular"];

        int i = 0;
        while (priorityQueue.Length > 0)
        {
            if (i >= expectedResult.Length)
            {
                Assert.Fail("Queue should have ran out of items by now.");
            }

            var priorityItemValue = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i], priorityItemValue);
            i++;
        }
    }

    [TestMethod]
    // Scenario: Try to dequeue from an empty priority queue.
    // Expected Result: The proper InvalidOperationException should be thrown, with the message "The queue is empty."
    // Defect(s) Found: This test passes with no issues, even if the previous PriorityQueueTests used the _queue.Count property to check which isn't the best. (not a bug but not ideal)
    public void TestPriorityQueue_Empty()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                 string.Format("Unexpected exception of type {0} caught: {1}",
                                e.GetType(), e.Message)
            );
        }
    }

    // Add more test cases as needed below.
}
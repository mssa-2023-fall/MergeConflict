// array of size input array
// if k+target and k-target is valid place average in that spot in array
// else place -1

/*
static int[] KAverage(int[] input, int i, int k) {
    int[] aryToReturn = new int[input.Length];
    int curIndex = 0;

    while (curIndex < i) {
        aryToReturn[curIndex] = -1;
        curIndex++;
    }

    for (int j = curIndex; j < input.Length-k; j++) {
        aryToReturn[curIndex] = (int)input[(j - i)..(j + 1)].Average();
    }

    for (int j = curIndex; j < input.Length;)

    return aryToReturn;
}
*/


using System.Collections.Generic;
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
static void Main() {
    Solution.MergeKLists(new ListNode[] { new ListNode(2) });
}
public class Solution {
    public static ListNode MergeKLists(ListNode[] lists) {

        // check for empty list
        var list = new List<ListNode>(lists);
        if (list.Count == 0) { return null; }

        // create head node
        ListNode head = new ListNode();

        // make curr node head
        ListNode currNode = head;

        // clean list
        for (int i = 0; i < list.Count; i++) {
            if (list[i] == null) {
                list.RemoveAt(i);
            }
        }

        // iterate through list
        // while list
        while (list.Count > 0) {

            // take first from list
            currNode = list[0];

            // if first.next == null then remove from list
            if (currNode.next == null) { list.RemoveAt(0); } 
            else { list[0] = list[0].next; }

            // order list
            list = new List<ListNode>(list.OrderBy(x => x.val));
        }

        // return head.next
        return head.next;

    }
}
public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null) {
        this.val = val;
        this.next = next;
    }
}
// check for empty list
// create head node
// make curr node head
// clean list
// iterate through list
// while list
// take first from list
// if first.next == null then remove from list
// order list
// return head.next






// create dictionary of lists
// create head node
// make curr node head
// iterate through dictionary values, keeping track of key with smallest num
// add smallest node to curr node
// make node at that key node.next
// continue until dictionary is empty

/*
public static ListNode MergeKLists(ListNode[] lists) {
    // create dictionary of lists
    // create head node
    // make curr node head
    Dictionary<int, ListNode> allNodes = new();
    ListNode head = new ListNode();
    ListNode currNode = head;

    for (int i = 0; i < lists.Length; i++) {
        allNodes.Add(i, lists[i]);
    }

    // iterate through dictionary values, keeping track of key with smallest num
    // continue until dictionary is empty
    while (allNodes.Count > 0) {
        // index, value
        int currMinIndex = int.MaxValue;

        foreach (var item in allNodes) {
            if (currMinIndex == null) {
                currMinIndex = item.Key;
            } else if (item.Value.val < currMinIndex) {
                currMinIndex = item.Key;
            }
        }

        // add smallest node to curr node
        currNode.next = allNodes[(int)currMinIndex];
        currNode = currNode.next;

        // make node at that key node.next
        if (allNodes[(int)currMinIndex].next.Equals(null)) {
            allNodes.Remove((int)currMinIndex);
        } else {
            allNodes[(int)currMinIndex] = allNodes[(int)currMinIndex].next;
        }
    }

    return head.next == null ? head : head.next;
*/
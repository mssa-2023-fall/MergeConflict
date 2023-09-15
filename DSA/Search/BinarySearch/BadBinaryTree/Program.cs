using BadBinaryTree;

Main();

static void Main() {
    //var testAry = new int[] { 1, 2, 3, 4, 5 };
    //var testAry = new int[] { 8, 10, 15, 16, 17, 20, 25 };
    var testAry = new int[] { 0, 1, 2, 3, 4, 5, 5, 7, 8, 8, 9, 11, 12, 22, 33 };


    var ourTree = new BadTree(testAry);
    //var targetAry = new int[] { 3, 2, 4, 1, 5 };
    var targetAry = new int[] { 7, 3, 11, 1, 5, 8, 22, 0, 2, 4, 5, 8, 9, 12, 33 };


    Console.WriteLine(String.Join(", ", targetAry) + " | This is the target array.");

    var newAry = ourTree.ToArray();

    Console.WriteLine(String.Join(", ", newAry) + "| This is the new array.");

}

//  3
// 1 4
//2   5

//  3
// 2 4
//1   5

 //      16
 //    /    \
 //   10     20
 //  / \    /  \
 // 8  15  17  25
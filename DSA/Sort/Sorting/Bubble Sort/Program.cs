// bubble sort
// look at 2 elements at a time
// compare the 2 elements
// swap the 2 elements if left < right
// left and right pointer equal to 0 and 1 respectively
// every pass minus the amount of passes we have to make by 1
// array length = 10
// after first pass reduce array length target by 1

// if pass doesnt swap anything we are done sorting

int[] ourAry = new int[] { 12, 24, 3, 7, 2, 5, 43, 9, 20, 27, 18 };
bool doneSwapping = false;

while (!doneSwapping) {

    doneSwapping = true;

    for (int i = 1; i < ourAry.Length; i++) {
        if (ourAry[i] < ourAry[i - 1]) {
            (ourAry[i], ourAry[i - 1]) = (ourAry[i - 1], ourAry[i]);
            doneSwapping = false;
        }
    }

}

Console.WriteLine(String.Join(",", ourAry));


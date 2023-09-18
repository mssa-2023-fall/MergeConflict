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